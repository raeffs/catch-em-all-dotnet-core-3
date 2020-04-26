import { ModuleWithProviders, NgModule } from '@angular/core';
import { ApiOptions, ApiOptionsToken } from './api-options.interface';

@NgModule()
export class ApiModule {

    public static forRoot(options: ApiOptions): ModuleWithProviders<ApiModule> {
        return {
            ngModule: ApiModule,
            providers: [
                { provide: ApiOptionsToken, useValue: options }
            ]
        };
    }

}
