import { InjectionToken } from '@angular/core';

export const AuthOptionsToken: InjectionToken<AuthOptions> = new InjectionToken<AuthOptions>('AuthOptions');

export interface AuthOptions {
    readonly apiEndpoint: string;
    readonly issuer: string;
    readonly clientId: string;
    readonly redirectUri: string;
    readonly silentRedirectUri: string;
    readonly scope: string;
}
