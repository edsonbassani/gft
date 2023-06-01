# Restaurant Order Application - Client


This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 16.0.3.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.


![Show Case](https://raw.githubusercontent.com/edsonbassani/gft/main/roa-client/src/assets/showcase.png)


# Restaurant Order Application - API


## Introduction


## About this solution


## Getting Started

1. Clone this repository
2. Restore the packages by running: `dotnet restore`
3. Install the EF Core CLI by running: `dotnet tool install --global dotnet-ef`
4. Set the environment variable `ASPNETCORE_ENVIRONMENT` to `Local`
    - On Windows Command Prompt: `set ASPNETCORE_ENVIRONMENT=Local`
    - On Windows PowerShell: `$env:ASPNETCORE_ENVIRONMENT="Local"`
    - On Linux/MacOS: `export ASPNETCORE_ENVIRONMENT=Local`
5. Run the migrations on your local database
6. Run the API by navigating to the API Project and running `dotnet run`

7. dotnet tool install --global dotnet-ef

## EF Migrations

### Create Migration

``` powershell
dotnet ef migrations add <migration-name> --startup-project ./Roa.API/Roa.API.csproj --project ./Roa.Infrastructure/Roa.Infrastructure.csproj
```

### Run Migration

``` powershell
dotnet ef database update --startup-project ./Roa.API/Roa.API.csproj
```

### Generate Migration Script

``` powershell
dotnet ef migrations script --idempotent --startup-project ./Roa.API/Roa.API.csproj --project ./Roa.Infrastructure/Roa.Infrastructure.csproj --output <path/file-name.sql>
```

### Remove Migration

``` powershell
dotnet ef migrations remove --startup-project ./Roa.API/Roa.API.csproj -p ./Roa.Infrastructure/Roa.Infrastructure.csproj
```
![OAS3](https://raw.githubusercontent.com/edsonbassani/gft/main/roa-api/Assets/roa-api-swagger.png)

