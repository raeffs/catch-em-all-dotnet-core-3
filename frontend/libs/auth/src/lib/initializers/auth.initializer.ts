import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';

export function authInitializer(): () => Promise<void> {
    const oAuth = inject(OAuthService);
    const router = inject(Router);
    return async () => {
        // will handle callbacks from login
        await oAuth.loadDiscoveryDocumentAndTryLogin();
        // if a return url is set we navigate to that url
        const params = router.parseUrl(window.location.search).queryParamMap;
        if (params.has('returnUrl')) {
            await router.navigateByUrl(params.get('returnUrl'), {
                replaceUrl: true
            });
        }
    };
}
