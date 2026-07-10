# Microservices JWT CRUD Ecosystem

This is an educational project designed to demonstrate the implementation of a modern, secure, and scalable distributed system using **ASP.NET Core (8.0/9.0)**. The project focuses on combining **Microservices Architecture**, **JWT Authentication/Authorization**, and efficient **CRUD Operations**.

## 🚀 Key Features

* **Microservices Architecture:** Decoupled, autonomous services focused on specific business capabilities.
* **Stateless JWT Authentication:** Secure token-based access control with asymmetric/symmetric encryption via `JwtProvider`.
* **Role-Based Authorization:** Secure endpoints protected by standard dynamic attributes (`[Authorize(Roles = "...")]`).
* **Clean CRUD Operations:** Standardized, high-performance database interactions within individual service boundaries.
* **Best Practices:** Dependency Injection (DI) with scoped lifecycles, environment-based configurations, and clean code separation.

---

## 🏗️ Architecture Overview

The system is split into independent services communicating asynchronously or via lightweight HTTP protocols:

```text
               ┌────────────────────────┐
               │      Client / UI       │
               └───────────┬────────────┘
                           │  HTTP Requests
                           ▼
               ┌────────────────────────┐
               │      API Gateway       │ (Token Validation)
               └─────┬────────────┬─────┘
                     │            │
   ┌─────────────────┴─┐        ┌─┴─────────────────┐
   │   Auth Service    │        │   CRUD Service    │
   │   (JWT Issuer)    │        │ (Business Logic)  │
   └───────────────────┘        └───────────────────┘
```

* **Auth Service:** Validates user credentials and issues short-lived JWT Access Tokens.
* **CRUD Service(s):** Manages core business resources, fully protected and accessible only with a valid Bearer token.

---

## 🛠️ Technology Stack

* **Backend Framework:** ASP.NET Core (Web API)
* **Security:** Microsoft.AspNetCore.Authentication.JwtBearer, System.IdentityModel.Tokens.Jwt
* **Data Access:** Entity Framework Core (SQL Server / PostgreSQL)
* **Containerization:** Docker & Docker Compose (Planned/Implemented)

---

## 🔧 Getting Started

### Prerequisites
* [.NET SDK (8.0 or 9.0)](https://microsoft.com)
* [Git](https://git-scm.com)

### Installation & Run

1. **Clone the repository:**
   ```bash
   git clone https://github.com
   cd microservices-jwt-crud
   ```

2. **Configure environment settings:**
   Make sure to update `appsettings.json` in your services with a secure JWT Key:
   ```json
   "Jwt": {
     "Key": "YourSuperSecretBackEndKeyMustBeAtLeast32CharactersLong!",
     "Issuer": "MicroservicesAuth",
     "Audience": "MicroservicesClients",
     "ExpiryMinutes": "60"
   }
   ```

3. **Restore and run the project:**
   ```bash
   dotnet restore
   dotnet run --project src/YourMainServiceFolder
   ```

---

## 🔒 Security Configuration Example

Every token contains standard claims for identity tracking:
* `sub` — Unique User Identifier
* `email` — User Email Address
* `role` — Assigned Access Role (e.g., `Admin`, `User`)

Endpoints are securely protected with:
```csharp
[HttpGet("secure-data")]
[Authorize(Roles = "Admin")]
public IActionResult GetProtectedData() => Ok("Access Granted.");
```

```
./
├── appsettings.Development.json
├── appsettings.json
├── aspcorestudy.csproj
├── Controllers
│   ├── AuthController.cs
│   ├── CardController.cs
│   ├── Random.cs
│   └── UserController.cs
├── Data
│   ├── AppDbContext.cs
│   ├── Interfaces
│   │   └── DbRepository.cs
│   ├── Models
│   │   ├── CardModel.cs
│   │   └── UserModel.cs
│   └── Repositories
│       └── EfRepositiory.cs
├── docker-compose.yaml
├── Dockerfile
├── Interfaces
│   └── IJwtService.cs
├── Migrations
│   ├── 20260707133535_InitialCreate.cs
│   ├── 20260707133535_InitialCreate.Designer.cs
│   └── AppDbContextModelSnapshot.cs
├── Models
│   ├── RegistrationResponse.cs
│   └── ResponseModels
│       ├── CardResponse.cs
│       └── UserResponse.cs
├── Program.cs
├── Properties
│   └── launchSettings.json
├── readme.md
└── Service
    ├── AuthService.cs
    ├── JwtService.cs
    └── RandomService.cs
```
