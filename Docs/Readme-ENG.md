# SavaAPI

SavaAPI is a simple API that allows managing tasks through basic CRUD operations. It InMemory Entity Framework and is built with .NET 8 and Clean Architecture.

## Features:
- **Create requests**: Add new requests to the system.
- **Read requests**: Retrieve existing requests.
- **Read specific requests**: Get details of specific requests.
- **Update requests**: Modify existing requests.
- **Delete requests**: Remove requests from the system.

## Architecture:
- **Database**: he application uses InMemory Entity Framework for data storage. Data is available only during the application runtime and is cleared when the application is closed.

## Getting Started:
1. Clone the repository.
2. Open the solution `SavaAPI.sln` in Visual Studio.
3. Set `SavaAPI` as the startup project.
4. Build and run the application.

## Testing:
The project includes unit tests to check basic API functionality. The tests are located in the `SavaAPI-Test` project.

Tests can be run by right-clicking the `SavaAPI` project and selecting 'Run Tests', or by using the 'Test Explorer' functionality.

## Technologies:
- **ASP.NET 8**
- **Entity Framework Core**
- **InMemory Database**
