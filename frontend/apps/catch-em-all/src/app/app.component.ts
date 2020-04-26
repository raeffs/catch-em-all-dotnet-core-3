import { Component } from '@angular/core';
import { NbMenuItem, NbSidebarService } from '@nebular/theme';
import { OAuthService } from 'angular-oauth2-oidc';
import { from, Observable, of } from 'rxjs';
import { catchError, filter, map, startWith, switchMap } from 'rxjs/operators';

@Component({
    selector: 'cea-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {

    public items: NbMenuItem[] = [
        {
            title: 'Search Queries',
            link: 'search-queries',
            icon: 'gift-outline'
        }
    ];

    public readonly user: Observable<UserInfo> = this.oAuth.events.pipe(
        filter(x => x.type === 'token_received'),
        startWith(0),
        switchMap(() => {
            if (!this.oAuth.hasValidAccessToken()) {
                return of({ loggedIn: false });
            }

            return from(this.oAuth.loadUserProfile()).pipe(
                map(x => ({
                    loggedIn: true,
                    email: x.email,
                    picture: `https://robohash.org/${encodeURIComponent(x.email)}2.png?set=set4`
                })),
                catchError(() => of({ loggedIn: false }))
            );
        })
    );

    constructor(
        private readonly sidebar: NbSidebarService,
        private readonly oAuth: OAuthService
    ) {
        this.oAuth.events.subscribe(console.warn);
    }

    public toggleSidebar(): void {
        this.sidebar.toggle(true);
    }

}

interface UserInfo {
    readonly loggedIn: boolean;
    readonly email?: string;
    readonly picture?: string;
}
