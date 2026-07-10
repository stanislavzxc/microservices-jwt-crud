# Microservices JWT CRUD Ecosystem

This is an educational project demonstrating a secure, scalable distributed architecture built with **ASP.NET Core (8.0/9.0)** and **PostgreSQL**. The project implements **JWT Authentication**, decoupled services, and clean repository-driven **CRUD Operations**.

## 📁 Project Structure

```text
./
├── Controllers/               # REST Endpoints (Auth, Cards, Users)
├── Data/                      # Database Layer
│   ├── Interfaces/            # Repository Abstractions
│   ├── Models/                # Database Entities (User, Card)
│   └── Repositories/          # EF Core Repository Implementations
├── Interfaces/                # Core Service Contracts (IJwtService)
├── Service/                   # Business Logic & Auth Implementations
├── Migrations/                # EF Core Database Migrations
├── Models/                    # DTOs & API Response Models
├── Program.cs                 # Application Entry Point & DI Configuration
├── Dockerfile                 # Application Container Specification
└── docker-compose.yaml        # Multi-container Orchestration
```

## 🚀 Key Features

* **JWT Authentication:** Custom stateless `JwtService` managing secure token generation and validation.
* **Generic Repository Pattern:** Abstracted Data Access Layer using decoupled Interfaces and EF Core repositories.
* **Database Migrations:** Automated schema management for PostgreSQL using EF Core Migrations.
* **Containerized Environment:** Fully production-ready multi-container setup running via Docker Compose.
* **Secure Environment Variables:** Zero hardcoded secrets; configuration is driven purely via environment variables.

---

## 🛠️ Technology Stack

* **Backend Framework:** ASP.NET Core (Web API)
* **Security:** Microsoft.AspNetCore.Authentication.JwtBearer, System.IdentityModel.Tokens.Jwt
* **Database:** PostgreSQL
* **Data Access:** Entity Framework Core
* **Containerization:** Docker & Docker Compose

---

## 🔧 Environment Configuration

The application uses environment variables for infrastructure bindings, matching double underscores (`__`) to map nested JSON fields in ASP.NET Core:

```env
POSTGRES_USER=dbuser
POSTGRES_PASSWORD=zxcursed
POSTGRES_DB=mydb
ConnectionStrings__DefaultConnection="Host=db;Port=5432;Database=mydb;Username=dbuser;Password=zxcursed"
Jwt__Key=1029384756Console.WriteLinezxcursed
```

---

## ⚡ Deployment with Docker Compose

To spin up the entire ecosystem (Web API + PostgreSQL Database) with a single command:

1. **Clone the repository:**
   ```bash
   git clone https://github.com
   cd microservices-jwt-crud
   ```

2. **Launch the containers:**
   ```bash
   docker compose up --build -d
   ```

3. **Verify the environment:**
   The Web API will be available at `http://localhost:5000` (or your configured Docker exposed port).
