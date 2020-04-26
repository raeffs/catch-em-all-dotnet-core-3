import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { OAuthStorage } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';
import { AuthOptions, AuthOptionsToken } from '../auth-options.interface';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(
        @Inject(AuthOptionsToken) private readonly options: AuthOptions,
        private readonly oAuth: OAuthStorage
    ) { }

    public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (!this.shouldIntercept(request)) {
            return next.handle(request);
        }

        const token = this.oAuth.getItem('id_token');
        const requestCopy = request.clone({
            setHeaders: {
                'Authorization': `Bearer ${token}`
            }
        });

        return next.handle(requestCopy);
    }

    private shouldIntercept(request: HttpRequest<any>): boolean {
        return request.url.startsWith(this.options.apiEndpoint);
    }

}
