import { CollectionViewer } from '@angular/cdk/collections';
import { DataSource } from '@angular/cdk/table';
import { Component } from '@angular/core';
import { ApiClientService } from '@cea/api';
import { Observable } from 'rxjs';

@Component({
    selector: 'cea-search-query-list',
    templateUrl: 'search-query-list.component.html',
    styleUrls: ['search-query-list.component.css']
})
export class SearchQueryListComponent {

    public readonly source: MyDataSource;

    public readonly columns: string[] = [
        'id',
        'name',
        'numberOfResults',
        'updated',
        'actions'
    ];

    constructor(
        private readonly client: ApiClientService
    ) {
        this.source = new MyDataSource(this.client);
    }

}


class MyDataSource implements DataSource<any> {

    constructor(
        private readonly api: ApiClientService
    ) { }

    public connect(collectionViewer: CollectionViewer): Observable<any[] | readonly any[]> {
        console.log('connect', collectionViewer);
        return this.api.get<any[]>('search-queries');
    }

    public disconnect(collectionViewer: CollectionViewer): void {
        console.log('disconnect', collectionViewer);
    }

}
