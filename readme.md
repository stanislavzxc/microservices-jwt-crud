# Microservices JWT CRUD Ecosystem

<p align="center">
  <img src="https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core">
  <img src="https://img.shields.io/badge/EF_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="EF Core">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/CRUD-28A745?style=for-the-badge&logo=databricks&logoColor=white" alt="CRUD">
  <img src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white" alt="JWT">
</p>

This is an educational project demonstrating a secure, scalable distributed architecture built with **ASP.NET Core (10.0)** and **PostgreSQL**. The project implements **JWT Authentication**, decoupled services, and clean repository-driven **CRUD Operations**.

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
├── DTOs/                      # Repository Abstractions.
│   ├── ResponseModels/        # DTOs & API Response Models
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
POSTGRES_USER=YOURDATA
POSTGRES_PASSWORD=YOURDATA
POSTGRES_DB=YOURDATA
ConnectionStrings__DefaultConnection="Host=db;Port=5432;Database=YOURDATA;Username=YOURDATA;Password=YOURDATA"
Jwt__Key=YOURDATA(32 SYMBOLS)
```

---

## ⚡ Deployment with Docker Compose

To spin up the entire ecosystem (Web API + PostgreSQL Database) with a single command:

1. **Clone the repository:**
   ```bash
   git clone https://github.com
   cd microservices_jwt_crud
   ```

2. **Launch the containers:**
   ```bash
   docker compose up --build -d
   ```

3. **Verify the environment:**
   The Web API will be available at `http://localhost:5000` (or your configured Docker exposed port).
