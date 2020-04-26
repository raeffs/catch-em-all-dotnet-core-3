import { CdkTableModule } from '@angular/cdk/table';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { NbButtonModule, NbCardModule, NbIconModule, NbInputModule } from '@nebular/theme';
import { CreateSearchQueryShortcutComponent } from './create-search-query-shortcut/create-search-query-shortcut.component';
import { SearchQueryListComponent } from './search-query-list/search-query-list.component';

const routes: Routes = [
    {
        path: '',
        component: SearchQueryListComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes),
        CommonModule,
        ReactiveFormsModule,
        CdkTableModule,
        NbCardModule,
        NbIconModule,
        NbButtonModule,
        NbInputModule,
    ],
    declarations: [
        SearchQueryListComponent,
        CreateSearchQueryShortcutComponent,
    ]
})
export class SearchQueriesModule { }
