# 🍽️ Talabat

A scalable and modular eCommerce backend system, built using **Onion Architecture** with .NET technologies. Designed to support clean code separation, extensibility, and maintainability.

## 📦 Architecture Overview

This solution adopts **Onion Architecture**, structured into clear layers:
Talabat.Solution/
│
├── Talabat.APIs # ASP.NET Core Web API layer
├── Talabat.Core # Domain entities & contracts
├── Talabat.Repository # Infrastructure: EF Core, Redis
├── Talabat.Services # Application services, business logic
└── AdminDashboard # (Optional) Admin web frontend or API consumer

### 🔁 Technologies & Tools

- **ASP.NET Core** - Web API
- **Entity Framework Core** - ORM
- **Redis** - Distributed caching
- **Twilio API** - SMS notification
- **AutoMapper** - DTO ↔ Entity mapping
- **Clean Separation** - via Onion Architecture principles

---

## ⚙️ Getting Started

### 🧰 Prerequisites

- [.NET SDK 7.0](https://dotnet.microsoft.com/en-us/download)
- SQL Server (or alternative EF-compatible DB)
- Redis server running locally or in the cloud
- Twilio account (with SID and AuthToken)

### 📥 Clone the Repo

```bash
git clone https://github.com/a7medsaber10/Talabat.Solution.git
cd Talabat.Solution
```

🔧 Configuration
Edit appsettings.json in Talabat.APIs:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Your_SQL_Connection_String"
},
"Redis": {
  "Connection": "localhost"
},
"Twilio": {
  "AccountSid": "your-sid",
  "AuthToken": "your-token",
  "FromPhone": "+1234567890"
}
```
