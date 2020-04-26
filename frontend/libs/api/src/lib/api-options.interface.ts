import { InjectionToken } from '@angular/core';

export const ApiOptionsToken: InjectionToken<ApiOptions> = new InjectionToken<ApiOptions>('ApiOptions');

export interface ApiOptions {
    readonly apiEndpoint: string;
}
