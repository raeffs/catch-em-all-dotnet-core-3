import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiOptions, ApiOptionsToken } from '../api-options.interface';

export interface ApiRequestOptions {
    readonly params?: HttpParams | { [key: string]: string | string[] };
}

@Injectable({
    providedIn: 'root'
})
export class ApiClientService {

    constructor(
        @Inject(ApiOptionsToken) private readonly options: ApiOptions,
        private readonly http: HttpClient
    ) { }

    public get<T>(url: string, options?: ApiRequestOptions): Observable<T> {
        const { requestUrl, ...requestOptions } = this.prepare(url, options);
        return this.http.get<T>(requestUrl, requestOptions);
    }

    public delete<T>(url: string, options?: ApiRequestOptions): Observable<T> {
        const { requestUrl, ...requestOptions } = this.prepare(url, options);
        return this.http.delete<T>(requestUrl, requestOptions);
    }

    public post<T>(url: string, body: unknown | null, options?: ApiRequestOptions): Observable<T> {
        const { requestUrl, ...requestOptions } = this.prepare(url, options);
        return this.http.post<T>(requestUrl, body, requestOptions);
    }

    public put<T>(url: string, body: unknown | null, options?: ApiRequestOptions): Observable<T> {
        const { requestUrl, ...requestOptions } = this.prepare(url, options);
        return this.http.put<T>(requestUrl, body, requestOptions);
    }

    private prepare(url: string, options?: ApiRequestOptions): PreparedRequest {
        options = options ?? {};
        const requestUrl = `${this.options.apiEndpoint}/${url}`;
        const params = options.params instanceof HttpParams
            ? options.params : new HttpParams({ fromObject: options.params });
        return {
            requestUrl,
            params
        }
    }

}

interface PreparedRequest {
    readonly requestUrl: string;
    readonly params?: HttpParams;
}
