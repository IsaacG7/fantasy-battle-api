# fantasy-battle-api
# Fantasy Battle API

A RESTful API built with ASP.NET Core and Entity Framework Core as a learning project for backend web development. The API manages RPG characters with full CRUD support backed by a SQL Server database.

---

## Tech Stack

- **ASP.NET Core** — web API framework
- **Entity Framework Core** — ORM for database access
- **SQL Server Express** — database engine
- **Swashbuckle (Swagger)** — API documentation and testing UI

---

## Prerequisites

Before running this project you will need the following installed:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (select the **Express** edition)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) (optional, for browsing the database)

---

## Setup

### 1. Clone the repository

```bash
git clone https://github.com/IsaacG7/fantasy-battle-api.git
cd fantasy-battle-api
```

### 2. Configure the connection string

Open `FantasyBattleAPI/appsettings.json` and update the connection string to point at your local SQL Server instance:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=FantasyBattle;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
}
```

If your SQL Server instance has a different name, replace `localhost\\SQLEXPRESS` with your instance name. You can find this in SQL Server Configuration Manager or the SSMS connection dialog.

### 3. Apply the database migration

Open the **Package Manager Console** in Visual Studio (View → Other Windows → Package Manager Console) and run:

```
Update-Database
```

This creates the `FantasyBattle` database and the `Characters` table automatically. You do not need to create anything manually in SSMS.

### 4. Run the project

Press **F5** in Visual Studio or run:

```bash
dotnet run --project FantasyBattleAPI
```

The API will start and Swagger UI will be available at:

```
https://localhost:{port}/swagger
```

---

## Endpoints

All endpoints are prefixed with `/api/Characters`.

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/Characters` | Get all characters |
| GET | `/api/Characters/{id}` | Get a character by ID |
| POST | `/api/Characters` | Create a new character |
| PATCH | `/api/Characters/{id}` | Partially update a character |
| DELETE | `/api/Characters/{id}` | Delete a character |

---

## Request & Response Examples

### Create a character — `POST /api/Characters`

**Request body:**
```json
{
  "name": "Legolas",
  "race": "Elf",
  "characterClass": "Ranger",
  "level": 10,
  "hp": 120,
  "attack": 35,
  "defense": 20
}
```

**Response — 201 Created:**
```json
{
  "id": 1,
  "name": "Legolas",
  "race": "Elf",
  "characterClass": "Ranger",
  "level": 10,
  "hp": 120,
  "attack": 35,
  "defense": 20
}
```

---

### Partially update a character — `PATCH /api/Characters/{id}`

Only include the fields you want to change. Omitted fields are left unchanged.

**Request body:**
```json
{
  "hp": 80,
  "level": 11
}
```

**Response — 200 OK**

---

## Project Structure

```
fantasy-battle-api/
├── FantasyBattleAPI/
│   ├── Controllers/
│   │   └── CharactersController.cs   # HTTP endpoints
│   ├── Data/
│   │   └── AppDbContext.cs           # EF Core DbContext
│   ├── DTOs/
│   │   ├── CreateCharacterDto.cs     # POST request shape
│   │   └── PatchCharacterDto.cs      # PATCH request shape
│   ├── Models/
│   │   └── Character.cs             # Character entity
│   ├── Services/
│   │   └── CharacterServiceAgent.cs  # Data access layer
│   ├── Migrations/                   # EF Core generated migrations
│   ├── Program.cs                    # App configuration and DI setup
│   └── appsettings.json             # App settings and connection string
```

---

## Notes

- Character IDs are assigned automatically by the database — do not include an `id` field in POST request bodies.
- This project uses Windows Authentication for the database connection. No passwords are stored in configuration.
- Data persists to disk via SQL Server, so characters survive application restarts.
