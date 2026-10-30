# RestApiEshop

A small REST API for an eshop product catalog, written in ASP.NET Core on .NET 10. It lists products (v1 returns all of them, v2 pages them), returns one product by id and lets you update a product's description.

Built with ASP.NET Core Web API, EF Core 10 on SQL Server, Asp.Versioning, Swagger UI and xUnit.

## Projects

| Project | What's in it |
|---|---|
| `RestApiEshop` | Web API - controllers, versioning, Swagger, `Program.cs` |
| `RestApiEshop.Application` | `ProductService`, DTOs and the `IProductRepository` interface |
| `RestApiEshop.Domain` | The `Product` entity |
| `RestApiEshop.Infrastructure` | EF Core `DbContext`, migrations, seed data, SQL and mock repositories |
| `RestApiEshop.Tests` | Unit tests and API tests on mock data |

The application layer only knows `IProductRepository`, so switching between the database and the mock data doesn't touch the business logic.

## How to run

You need the .NET 10 SDK and, unless you run on mock data, SQL Server LocalDB (it comes with Visual Studio).

In Visual Studio open `RestApiEshop.slnx`, pick the `https` launch profile and press F5. Swagger UI opens at `https://localhost:7161/swagger`.

Or from the command line, then open the same URL:

```bash
dotnet run --project RestApiEshop --launch-profile https
```

### Database

The connection string is in `RestApiEshop/appsettings.Development.json` and points to LocalDB. In Development the app applies EF Core migrations on startup, so the first run creates the `RestApiEshop` database and seeds 30 products. For another SQL Server just change the connection string.

### Mock data

The app can also run without a database on 12 in-memory products from `RestApiEshop.Infrastructure/Mock/MockProductData.cs`. Use the `https-mock` launch profile, or set `UseMockData` to `true` in `appsettings.json` or as an environment variable. Changes are kept only until the app stops.

## API

The version is part of the URL, v1 and v2 are supported.

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/v1/products` | All products |
| `GET` | `/api/v2/products?pageNumber=1&pageSize=10` | One page of products (page size 10 by default, max 100) |
| `GET` | `/api/v{version}/products/{id}` | One product |
| `PATCH` | `/api/v{version}/products/{id}` | Update the description |

The PATCH body is just the new description:

```json
{ "description": "New description" }
```

`null` or an empty string removes it. Invalid input returns `400` and an unknown id `404`, both as problem details.

Swagger UI is at `/swagger` and there are sample requests in `RestApiEshop/RestApiEshop.http`.

## Tests

The tests run on the mock data, so no database is needed:

```bash
dotnet test
```
