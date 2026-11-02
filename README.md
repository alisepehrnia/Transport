# 🚐 Transport – Internal Transport Request Management

An **ASP.NET MVC 5** web application for managing **in‑organization transport requests** — essentially a private, internal “Uber” for employees.  
Users can submit transport requests, and managers can confirm or reject them through a role‑based hierarchy. The application includes user management, request tracking, and a seeding flow for default accounts.

> **Repository description:** *“private in-organization uber c# web application”* [reference:0]

---

## 📖 Overview

`Transport` is a **C# / ASP.NET MVC** web application built on **.NET Framework 4.8**.  
It implements a multi‑level approval workflow for internal transport: employees create requests, and higher‑level roles (MiddleManager, Manager) review, confirm, or reject them.  
An **Admin** role manages user accounts.  
The application uses **ASP.NET Identity** for authentication and role management, and **Entity Framework 6** (Code First with Migrations) for data access.

The repository follows a **layered architecture**:

- **`Transport.Core`** – domain entities, interfaces, enums, specifications, and permission services.
- **`Transport.Infrastructure`** – Entity Framework data access, repositories, queries, migrations, and logging.
- **`Transport.WebUI`** – MVC controllers, views, view models, and application startup (OWIN / Identity).
- **`tests/`** – Unit, Integration, and Functional test projects.

---

## ✨ Features

- **Role‑based transport requests** — create, view, confirm, and reject requests according to the user’s role level.
- **Approval hierarchy** — Manager and MiddleManager can confirm or reject requests from higher‑level users.
- **User management** — Admin can create new users through `/Account/Register`.
- **Default user seeding** — a single route (`~/Account/AddUsers`) seeds the database with five default accounts covering every role.
- **Request dashboard** — users see their own requests; managers see a confirmation queue.
- **Entity Framework Code First** — schema is managed via migrations in `Transport.Infrastructure/Migrations`.
- **Layered separation** — Core, Infrastructure, and WebUI are separate projects with clear dependencies.

---

## 👥 Roles & Permissions

The application defines five roles with numeric **role levels** (lower number = higher authority)[reference:1]:

| UserName | Password | Role Name | Role Level | Capabilities |
|----------|----------|-----------|------------|--------------|
| `admin` | `admin` | Admin | **-10** | Can create users |
| `manager` | `manager` | Manager | **10** | Can create requests & confirm/reject requests |
| `middlemanager` | `middlemanager` | MiddleManager | **20** | Can create requests & confirm/reject requests |
| `employee` | `employee` | Employee | **30** | Can create requests |
| `driver` | `driver` | Driver | **40** | Can see confirmed requests (not fully implemented yet) |

> **Note:** The driver role is present in the data model and seeding logic, but its “view confirmed requests” capability is marked as **not implemented yet** in the guide[reference:2].

---

## 🗂️ Repository Structure

```text
Transport/
├── src/
│   ├── Transport.Core/                 # Domain layer
│   │   ├── Constants/                  # Application constants
│   │   ├── Entities/                   # Transport and User entities
│   │   ├── Enums/                      # Role and status enums
│   │   ├── Extensions/                 # Extension methods
│   │   ├── Interfaces/                 # Repository and service contracts
│   │   ├── Services/                   # UserPremissionsCheckService
│   │   ├── Specifications/             # Query specifications
│   │   └── Transport.Core.csproj
│   ├── Transport.Infrastructure/       # Data access layer
│   │   ├── Data/
│   │   │   ├── DataAccess/             # DbContext / Identity context
│   │   │   ├── Queries/                # Query objects
│   │   │   └── Repositories/           # Repository implementations
│   │   ├── Logging/                    # Logging infrastructure
│   │   ├── Migrations/                 # EF Code First migrations
│   │   ├── Services/                   # Infrastructure services
│   │   └── Transport.Infrastructure.csproj
│   └── Transport.WebUI/                # Presentation layer (MVC)
│       ├── App_Start/                  # Identity / OWIN startup
│       ├── Assets/                     # Static assets
│       ├── Controllers/                # Account, Home, Manage, TransportRequests, Error
│       ├── ViewModels/                 # Account and Manage view models
│       ├── Views/                      # Razor views
│       ├── Global.asax                 # Application entry
│       ├── Startup.Auth.cs             # OWIN auth configuration
│       ├── Startup.cs                  # OWIN startup
│       └── Trasnsport.WebUI.csproj     # Web project file
├── tests/
│   ├── FunctionalTests/                # End-to-end tests
│   ├── IntegrationTests/               # Integration tests
│   └── UnitTests/                      # Unit tests
├── Guide.txt                           # Setup and usage guide
├── ToDo.txt                            # Known improvements / backlog
├── Transport.sln                       # Visual Studio solution
├── LICENSE                             # Apache License 2.0
└── README.me                           # Original README (note the typo in extension)
```

## 🛠️ Technologies

|Item|Details|
|---|---|
|**Framework**|[ASP.NET](https://asp.net/) MVC 5|
|**Runtime**|.NET Framework **4.8**|
|**ORM**|Entity Framework **6.4.4** (Code First + Migrations)|
|**Authentication**|[ASP.NET](https://asp.net/) Identity **2.2.3** + OWIN **4.2.2**|
|**Database**|SQL Server (via `EntityFramework.SqlServer`)|
|**Front‑end**|Razor views, Bootstrap (bundled in `Assets`)|
|**Testing**|UnitTests, IntegrationTests, FunctionalTests projects|
|**License**|**Apache License 2.0**|

---
## 🚀 Getting Started

### Prerequisites

- **Visual Studio 2022** (or 2019) with the **[ASP.NET](https://asp.net/) and web development** workload.
- **.NET Framework 4.8** targeting pack.
- **SQL Server** (LocalDB is sufficient for development).
- **NuGet** package restore.

### 1. Configure the connection string

Open `src/Transport.Infrastructure/Web.config` (or `App.config`) and set:

```xml
<connectionStrings>
  <add name="TransportConnectionString"
       connectionString="YOUR_SQL_SERVER_CONNECTION_STRING"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 2. Apply Entity Framework migrations

Because the project uses **EF Code First with Migrations**, create or update the database using the Package Manager Console:

```powershell
Update-Database -ProjectName Transport.Infrastructure
```

Alternatively, enable automatic migrations if they are configured in the DbContext.
### 3. Seed default users

Run the application and navigate to:

```text
~/Account/AddUsers
```

This seeds the database with the five default accounts listed in the **Roles & Permissions** table above.[](https://raw.githubusercontent.com/alisepehrnia/Transport/main/Guide.txt)

### 4. Log in

Navigate to:

```text
~/Account/Login
```

Use any of the default accounts (e.g. `admin` / `admin`, or `employee` / `employee`) to sign in.[](https://raw.githubusercontent.com/alisepehrnia/Transport/main/Guide.txt)

### 5. Create a transport request

After logging in, go to:

```text
~/TransportRequests/Create
```

Fill in the request details and submit.[](https://raw.githubusercontent.com/alisepehrnia/Transport/main/Guide.txt)
### 6. View and confirm requests

- **All users:** view your own requests at `~/TransportRequests`.[](https://raw.githubusercontent.com/alisepehrnia/Transport/main/Guide.txt)
- **Manager / MiddleManager:** open `~/TransportRequests/Confirmation` to see, confirm, or reject requests from higher‑level users.[](https://raw.githubusercontent.com/alisepehrnia/Transport/main/Guide.txt)
- **Admin:** create new users via `~/Account/Register`.[](https://raw.githubusercontent.com/alisepehrnia/Transport/main/Guide.txt)

---
## 🧪 Tests

The solution includes three test projects:[](https://raw.githubusercontent.com/alisepehrnia/Transport/main/Transport.sln)

| Project              | Purpose                                              |
| -------------------- | ---------------------------------------------------- |
| **UnitTests**        | Tests domain logic and services in isolation.        |
| **IntegrationTests** | Tests data access, repositories, and EF integration. |
| **FunctionalTests**  | Tests end‑to‑end web flows.                          |

Run all tests from Visual Studio’s **Test Explorer**, or with the command line:

```bash
dotnet test Transport.sln
```

> Because this is a **.NET Framework** solution, `dotnet test` may require MSBuild‑compatible tooling; running tests from Visual Studio is the most reliable option.

---
## 🧠 How the Layers Fit Together

- **Core** defines the **entities** (`Transport`, `User`), **enums** (roles/statuses), **interfaces** (repository contracts), and **specifications** for querying.  
    It also contains `UserPremissionsCheckService`, which encapsulates role‑level permission logic.[](https://github.com/alisepehrnia/Transport/tree/main/src/Transport.Core/Services)
    
- **Infrastructure** implements the **data access layer**:
    - `DataAccess` contains the EF `DbContext` (and Identity context).
    - `Repositories` implement the Core interfaces.
    - `Queries` hold reusable query objects (e.g. `AppUserRoleLevelQueries`).
    - `Migrations` contains the EF Code First migration history.[](https://github.com/alisepehrnia/Transport/tree/main/src/Transport.Infrastructure)
- **WebUI** is the **MVC presentation layer**:
    - `AccountController` handles login, registration, and the `AddUsers` seeding route.
    - `TransportRequestsController` handles request creation, listing, and confirmation.
    - `CustomController` and `ManageController` provide shared behaviour and profile management.[](https://github.com/alisepehrnia/Transport/tree/main/src/Transport.WebUI/Controllers)

---
## 📝 Known Limitations & Backlog

Planned improvements:[](https://raw.githubusercontent.com/alisepehrnia/Transport/main/ToDo.txt)

1. **Transport Request Create:** add a validator ensuring the travel time is **greater than now**.
2. **Transport Request Confirmation:** design a better UI/UX after confirm/reject.
3. **Register Page:** add an input for **role selection**.
4. **Transport Request Create:** add a **ListBox** to include other users in a transport request.

The **Driver** role also has an unfinished capability: it can see confirmed requests, but this is “not implemented yet”.

6- Just As Admin: Create New Users Through ~/Account/Register Page
