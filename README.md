# 🍽️ Talabat

A scalable and modular eCommerce backend system, built using **Onion Architecture** with .NET technologies. Designed to support clean code separation, extensibility, and maintainability.

## 📦 Architecture Overview

This solution adopts **Onion Architecture**, structured into clear layers:
```bash
Talabat.Solution/
│
├── Talabat.APIs # ASP.NET Core Web API layer
├── Talabat.Core # Domain entities & contracts
├── Talabat.Repository # Infrastructure: EF Core, Redis
├── Talabat.Services # Application services, business logic
└── AdminDashboard # (Optional) Admin web frontend or API consumer
```

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

🛠️ Database Setup
Apply migrations and create the DB:

bash
Copy
Edit
cd Talabat.APIs
dotnet ef database update
▶️ Run the App
bash
Copy
Edit
dotnet run --project Talabat.APIs
Visit https://localhost:{port}/swagger for interactive API docs.

📚 Main Features
Module	Description
Products	CRUD for food items, categories, pricing
Baskets	Add/remove/update items with Redis caching
Orders	Place and track orders, assign delivery
Notifications	SMS alerts to customers using Twilio
Admin Tools	(Via AdminDashboard) Manage users, orders, and analytics

🔌 Key Patterns & Practices
Onion Architecture: Decouples domain logic from infrastructure and APIs

Repository Pattern: Clean EF Core data access

Service Layer: Centralized business operations

Caching: Redis used to improve performance of frequent reads

Mapping: AutoMapper for clean transformation between DTOs and entities

SMS Integration: Twilio for notifying customers in real-time

📦 Folder-by-Folder Breakdown
🧠 Talabat.Core
Entities (Product, Order, DeliveryMethod, etc.)

Interfaces (Repositories, IUnitOfWork)

📚 Talabat.Repository
EF Core context (StoreContext)

Repository Implementations

Redis caching logic

🧩 Talabat.Services
Business services (e.g., OrderService, BasketService)

DTOs and validators

🌐 Talabat.APIs
Controllers (ProductController, OrderController, etc.)

Swagger config

Middleware (error handling, logging)

📊 AdminDashboard
Optional frontend or separate UI project for Admins (may use Angular, Blazor, or Razor Pages)

Manages products, orders, and customers

Connects via API to the backend

✅ To-Do / Future Enhancements
 Add JWT Authentication & Role-based Authorization

 Add unit/integration tests

 Add Stripe payment integration

 Deploy to Azure / Docker container

 Implement Email notifications via SendGrid

🤝 Contributing
Contributions are welcome! Open an issue or submit a pull request to suggest improvements.

📜 License
This project is licensed under the MIT License.

👨‍💻 Author
Ahmed Saber
GitHub: @a7medsaber10
