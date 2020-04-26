import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_INITIALIZER, ModuleWithProviders, NgModule } from '@angular/core';
import { AuthConfig, OAuthModule } from 'angular-oauth2-oidc';
import { AuthOptions, AuthOptionsToken } from './auth-options.interface';
import { authInitializer } from './initializers/auth.initializer';
import { AuthInterceptor } from './interceptors/auth.interceptor';

@NgModule()
export class AuthModule {

    public static forRoot(options: AuthOptions): ModuleWithProviders<AuthModule> {
        return {
            ngModule: AuthModule,
            providers: [
                OAuthModule.forRoot().providers,
                { provide: AuthOptionsToken, useValue: options },
                { provide: APP_INITIALIZER, useFactory: authInitializer, multi: true },
                { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
                {
                    provide: AuthConfig,
                    useValue: {
                        responseType: 'code',
                        issuer: options.issuer,
                        clientId: options.clientId,
                        redirectUri: options.redirectUri,
                        silentRefreshRedirectUri: options.silentRedirectUri,
                        scope: options.scope
                    }
                },
            ]
        };
    }

}
