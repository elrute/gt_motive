# Renting Microservice Exercise

This folder contains the solution for the renting microservice exercise implemented on top of the provided hexagonal architecture template.

## References

- Exercise instructions: [InstruccionesPruebaTecnicaNET.pdf](./InstruccionesPruebaTecnicaNET.pdf)
- Base template: the original hexagonal solution is in the `hexagonal-architecture-doc-main` folder.
- Solution file: `hexagonal-architecture-doc-main\src\microservice.sln`

## What Was Implemented

The microservice supports:
- Creating vehicles in the fleet
- Listing available vehicles
- Renting a vehicle
- Returning a vehicle

Business rules implemented:
- One person cannot have more than one active rental at the same time
- Vehicles older than 5 years cannot be added to the fleet

## Architecture

The implementation keeps the template structure:
- `Domain`: entities, exceptions, repository interfaces
- `ApplicationCore`: use cases, input/output models, output ports
- `Infrastructure`: MongoDB repositories and service wiring
- `Api`: request DTOs, MediatR handlers, presenters, controller
- `Host`: runtime bootstrap and Swagger

## How To Run

Prerequisites:
- .NET 9 SDK
- Docker Desktop with modern `docker compose`

Start MongoDB (via Docker):

```powershell
docker compose up -d
```

Or use the helper script:

```powershell
powershell -ExecutionPolicy Bypass -File .\hexagonal-architecture-doc-main\scripts\start-local-deps.ps1
```

Open the solution:

```powershell
start .\hexagonal-architecture-doc-main\src\microservice.sln
```

Startup project:
- `GtMotive.Estimate.Microservice.Host`

Local URLs:
- `https://localhost:18969`
- `http://localhost:18970`

The application root redirects to Swagger, so pressing `F5` opens the API UI.

When running from Visual Studio, `F5` also triggers `hexagonal-architecture-doc-main\\scripts\\start-local-deps.ps1`, which starts MongoDB (via Docker) before launching the host.

## Local Mongo Configuration

Configured in:
- `hexagonal-architecture-doc-main\src\GtMotive.Estimate.Microservice.Host\appsettings.Development.json`

Defaults:
- Connection string: `mongodb://localhost:27017`
- Database: `gtmotive-estimate-dev`

## Endpoints

- `POST /vehicles`
- `GET /vehicles/available`
- `POST /vehicles/{vehicleId}/rent`
- `POST /vehicles/{vehicleId}/return`

## Tests

Example tests were added for the three requested levels:
- Infrastructure: host/model-validation request test
- Unit: isolated use case test
- Functional: integration flow excluding the host

Test projects:
- `hexagonal-architecture-doc-main\test\infrastructure\GtMotive.Estimate.Microservice.InfrastructureTests`
- `hexagonal-architecture-doc-main\test\unit\GtMotive.Estimate.Microservice.UnitTests`
- `hexagonal-architecture-doc-main\test\functional\GtMotive.Estimate.Microservice.FunctionalTests`

Notes:
- Unit and infrastructure tests do not require MongoDB (via Docker) running
- Functional tests require MongoDB (via Docker) running locally



