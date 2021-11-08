# CodersLinkAssignment

This project is an experiment trying to create a solution template with for CodersLink Assignment requirements.



## Technologies and patterns used

- Backend
  - Minimal API with .NET 5
  - Clean Architecture
  - CQRS with MediatR
  - Validations with FluentValidation
  - AutoMapper
  - Entity Framework Core (But Open to extension, e.g. InMemoryRepositories)
  - Swagger
  -MediatR Pipeline Validation Behaviour
  -Standard Format Response Data
  -Standard exceptions


- Frontend
  - Simple CRUD and nothing more (under construction)


## Getting started

The easiest way to get started is using Visual Studio 2019+ or with `dotnet run` installing the .NET 5 SDK.

## Database Migrations

1- Set CodersLinkAssignment.WebApi as startup project.

2- Set a valid connection string in appsettings.json.

3- Manually delete the entire Migrations directory

4- Set CodersLinkAssignment.Persistence as default project in console and run the following commands

````bash
Add-Migration Initial
```

````bash
Update-Database
```


## Fronted under construction 🏗️🚧🏗️
