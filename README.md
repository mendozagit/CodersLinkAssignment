# CodersLinkAssignment

This project is an experiment trying to create a solution template with for CodersLink Assignment requirements.



## Technologies and patterns used

- Backend
  - Minimal API with .NET 5
  - Clean Architecture
  - CQRS with MediatR
  - Validations with FluentValidation
  - AutoMapper
  - Entity Framework Core (but ist open to extension, e.g. InMemoryRepositories)
  - Swagger
  - MediatR Pipeline Validation Behaviour
  - Standard Format Response Data
  - Standard exceptions
  - Paging


- Frontend
  - Angular Simple CRUD and nothing more (under construction)


## Getting started

The easiest way to get started is using Visual Studio 2019+ or with `dotnet run` installing the .NET 5 SDK.

## Database Migrations

1- Set ```CodersLinkAssignment.WebApi``` project as startUp project.

2- Set a valid connection string in appsettings.json.

3- Manually delete the entire Migrations directory

4- Set ```CodersLinkAssignment.Persistence``` project as default project in console and run the following commands

```bash
Add-Migration Initial
```
```bash
Update-Database
```


5- Go to ```CodersLinkAssignment.Aplication.Features.Customers.Commands.Seeder```, there is dummy data.json, there ready to copy and paste over it 
```/api/v{version}/Customer/{seed}``` endpoint, this will be useful for testing filters and paging. 


## Frontend is under construction 🏗️🚧🏗️
