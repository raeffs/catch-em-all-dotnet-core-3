import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { ApiModule } from '@cea/api';
import { AuthGuard, AuthModule } from '@cea/auth';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NbActionsModule, NbIconModule, NbLayoutModule, NbMenuModule, NbSidebarModule, NbThemeModule, NbUserModule } from '@nebular/theme';
import { environment } from '../environments/environment';
import { AppComponent } from './app.component';

export const routes: Routes = [
    {
        path: 'search-queries',
        loadChildren: () => import('./features/search-queries/search-queries.module').then(x => x.SearchQueriesModule),
        canActivate: [AuthGuard]
    }
];

@NgModule({
    imports: [
        // Angular
        BrowserModule,
        HttpClientModule,
        BrowserAnimationsModule,
        RouterModule.forRoot(routes),
        // Nebula
        NbThemeModule.forRoot({ name: 'corporate' }),
        NbLayoutModule,
        NbEvaIconsModule,
        NbIconModule,
        NbSidebarModule.forRoot(),
        NbMenuModule.forRoot(),
        NbUserModule,
        NbActionsModule,
        // Core
        AuthModule.forRoot({
            apiEndpoint: environment.apiEndpoint,
            issuer: environment.authIssuer,
            clientId: environment.authClientId,
            redirectUri: `${window.location.origin}`,
            silentRedirectUri: `${window.location.origin}/silent-refresh.html`,
            scope: 'openid profile email offline_access',
        }),
        ApiModule.forRoot({
            apiEndpoint: environment.apiEndpoint
        })
    ],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
