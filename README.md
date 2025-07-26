# JourneyMiles.API

A simple ASP.NET Core API to study and demonstrate **Clean Architecture** and **Domain-Driven Design (DDD)** principles.

The project structure separates concerns into `Domain`, `Application`, `Infrastructure`, and `API` layers.

## Tech Stack

- .NET 8
- ASP.NET Core
- Entity Framework Core
- Dapper
- FluentMigrator
- FluentValidation
- AutoMapper
- Swashbuckle (Swagger)

## How to Run

1.  **Prerequisites**: You will need the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) and a running SQL Server instance.

2.  **Configure**: Clone the project, then open the `appsettings.json` file and update the `DefaultConnection` string with your database credentials.

3.  **Run**: Open a terminal in the project's root folder and execute the following command:
    ```sh
    dotnet run
    ```

The application will start, and the database migrations will run automatically to create all the necessary tables. You can access the API and its Swagger documentation at the `localhost` address shown in the terminal.