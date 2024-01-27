# Task Management Project

This project is a task management system built using .NET 6.0. It consists of two main parts:

1. `TaskManagement.Api`: This is an ASP.NET Core Web API that serves as the backend of the system. It handles data operations and business logic.

2. `TaskManagement.Web`: This is a Blazor Server Side application that serves as the frontend of the system. It provides a user interface for interacting with the task management system.

## Tools and Libraries Used

- **.NET 6.0**: The latest version of .NET, used to build both the API and the web application.
- **ASP.NET Core**: A framework for building web applications, used to build the API.
- **Blazor Server Side**: A framework for building interactive web UIs using C# instead of JavaScript.
- **Entity Framework Core**: An object-database mapper for .NET, used to interact with the database.
- **Npgsql**: A .NET data provider for PostgreSQL.
- **MudBlazor**: A component library for Blazor applications.
- **Swashbuckle.AspNetCore**: A library for generating Swagger documents for ASP.NET Core Web API.

## How to Run

### Running the API

1. Navigate to the `TaskManagement.Api` directory.
2. Run the command `dotnet run`. This will start the API.

### Running the Web Application

1. Navigate to the `TaskManagement.Web` directory.
2. Run the command `dotnet run`. This will start the web application.

Please ensure that the API is running before starting the web application, as the web application depends on the API.

Note: You may need to update the `ApiUrl` in the `appsettings.json` file of the `TaskManagement.Web` project to match the URL where the API is running.