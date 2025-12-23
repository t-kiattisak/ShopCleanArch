# ShopCleanArch

Clean Architecture e-commerce application built with .NET 9.0

## Tech Stack

- **.NET 9.0**
- **Entity Framework Core** with PostgreSQL
- **MediatR** for CQRS pattern
- **Minimal API** with Endpoints pattern

## Prerequisites

- .NET 9.0 SDK
- Docker & Docker Compose

## Getting Started

### 1. Start PostgreSQL and pgAdmin with Docker

```bash
docker-compose up -d
```

This will start:

- **PostgreSQL** on port `5432`
- **pgAdmin** on port `5050` (http://localhost:5050)

**pgAdmin Credentials:**

- Email: `admin@shop.com`
- Password: `admin`

### 2. Restore Packages

```bash
dotnet restore
```

### 3. Create Database Migration

```bash
dotnet ef migrations add InitialCreate --project src/Shop.Infrastructure --startup-project src/Shop.API
```

This command creates the initial migration file for the database schema.

### 4. Update Database

```bash
dotnet ef database update --project src/Shop.Infrastructure --startup-project src/Shop.API
```

This command applies the migration to the PostgreSQL database and creates the `Products` table.

### 5. Run the Application

```bash
dotnet run --project src/Shop.API
```

The API will be available at:

- HTTP: `http://localhost:5255`
- Swagger UI: `http://localhost:5255/swagger`

## Docker Commands

### Start services

```bash
docker-compose up -d
```

### Stop services

```bash
docker-compose down
```

### View logs

```bash
docker-compose logs -f postgres
```

### Remove volumes (clean database)

```bash
docker-compose down -v
```

## Database Connection

The connection string is configured in `appsettings.json`:

```
Host=localhost;Port=5432;Database=ShopDb;Username=postgres;Password=postgres
```

## EF Core Migration Commands

### Create a new migration

```bash
dotnet ef migrations add <MigrationName> --project src/Shop.Infrastructure --startup-project src/Shop.API
```

### Apply migrations to database

```bash
dotnet ef database update --project src/Shop.Infrastructure --startup-project src/Shop.API
```

### Remove last migration (if not applied)

```bash
dotnet ef migrations remove --project src/Shop.Infrastructure --startup-project src/Shop.API
```

### List all migrations

```bash
dotnet ef migrations list --project src/Shop.Infrastructure --startup-project src/Shop.API
```

## Project Structure

```
src/
├── Shop.API/              # Presentation Layer (Endpoints)
├── Shop.Application/       # Application Layer (Use Cases, DTOs)
├── Shop.Domain/           # Domain Layer (Entities, Models)
└── Shop.Infrastructure/   # Infrastructure Layer (DbContext, Repositories)
```

## API Endpoints

- `GET /products` - Get all products
- `GET /products/{id}` - Get product by ID
