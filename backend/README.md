# Catch'em all backend

The backend has several executable projects.

## Test App

The Test App can be started by running the App project.
It executes all pending database migrations.
In case of an error it deletes the database and recreates it.

## API

The API can be started by running the WebApi project.
It hosts the API on port 5000 and requires a local database with migrations already applied.

## Azure Functions

The Azure Functions can be executed by running the Functions project.
It contains several scheduled functions.

