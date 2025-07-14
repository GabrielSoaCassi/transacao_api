# Transacao.API

This project was developed as a study on logging, clean code practices, and building simple APIs using .NET.

## Project Structure

- **Transacao.API**: Main ASP.NET Core Web API project.
- **Transacao.Business**: Business logic and service layer.
- **Transacao.Domain**: Domain models and exceptions.
- **Transacao.Testes**: Unit tests for the solution.

## Goals

- Demonstrate clean code principles in a real-world API.
- Implement structured logging using [Serilog](https://serilog.net/).
- Explore OpenTelemetry for metrics and tracing.
- Provide a simple, maintainable API structure.

## Features

- RESTful API endpoints.
- Logging to console and file with Serilog.
- OpenTelemetry integration for observability.
- Unit tests with xUnit and Moq.

## Getting Started

1. Clone the repository.
2. Open `Transacao.API.sln` in Visual Studio or Rider.
3. Run the solution.
4. Access the API documentation at `/swagger` or `/openapi` endpoint.

## Logging

- Logs are written to the console and to `logs/minhaapi-log.txt` with daily rolling.
- Log context is enriched with application-specific properties.

## Clean Code

- Separation of concerns between API, business, and domain layers.
- Use of dependency injection and service registration.
- Readable, maintainable code structure.

## Testing

- Unit tests are located in the `Transacao.Testes` project.
- Run tests using your IDE's test runner or `dotnet test`.

---

This project is for educational purposes and experimentation with best practices in .NET API development.