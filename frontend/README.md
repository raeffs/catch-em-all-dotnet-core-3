# Catch'em all frontend

Start the frontend with `yarn start`, which launches dev server on port 4200.
It requires access to the backend on port 5000 and internet access for authentication with Auth0.

## Other dev commands

- Add a new component: `ng g c my-component --project=catch-em-all`
- Add a new library: `ng g @nrwl/angular:lib my-lib`

## Structure

### Core

Core features are extracted into separate libraries, to make imports into the app easier.

- auth: Wraps `angular-oauth2-oidc` and adds the required infrastructure for authentication.
- api: Provides easy access to the backend API.

### Features

Features are parts of the app that are lazy loaded once the user navigates to a part of the feature.

### Shell

The app shell is the part of the app that gets initially rendered, before any feature is loaded.
It contains the global layout, header, sidebar and so on.

## Libraries & Documentation

- Angular / Angular CLI: https://angular.io/docs
- Nx: https://nx.dev/angular/getting-started/why-nx
- RxJS: https://rxjs-dev.firebaseapp.com/guide/overview
- Nebular: https://akveo.github.io/nebular/docs/getting-started/what-is-nebular
- Eva Icons for Nebular: https://akveo.github.io/eva-icons
- Angular CDK: https://material.angular.io/cdk/categories
