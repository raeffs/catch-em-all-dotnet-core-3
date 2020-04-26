import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiClientService } from '@cea/api';

@Component({
    selector: 'cea-create-search-query-shortcut',
    templateUrl: 'create-search-query-shortcut.component.html',
    styleUrls: ['create-search-query-shortcut.component.css']
})
export class CreateSearchQueryShortcutComponent {

    public readonly form: FormGroup;

    constructor(
        private readonly builder: FormBuilder,
        private readonly api: ApiClientService
    ) {
        this.form = this.builder.group({
            withAllTheseWords: [null]
        });
    }

    public handleSubmit(): void {
        console.log(this.form.getRawValue());

        const body = this.form.getRawValue();

        this.api.post(`search-queries`, { ...body, name: body.withAllTheseWords }).subscribe(console.log);
    }

}
