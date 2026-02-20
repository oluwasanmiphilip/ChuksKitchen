# 🍽️ Chuks Kitchen

Chuks Kitchen is a **Clean Architecture ASP.NET Core Web API** project built with **CQRS + MediatR, FluentValidation, EF Core, and Minimal APIs**. It provides a backend for a food ordering system with **user registration, OTP verification, referral codes, cart management, and order tracking**.

---

**Features**

**User Registration & Access Flow**
- Sign up using **Email or Phone Number**
- Optional **Referral Code** during signup
- **OTP verification via Email**
- Handles edge cases:
  - Abandoned signup (cleaned up by background service)
  - Invalid/expired referral code
  - Invalid/expired OTP
  - Duplicate email/phone number
  - Verification failure

**User Types**
- **Customer**
  - Browse food items
  - Add items to cart
  - Place orders
  - Track order status
- **Admin (Chuks Kitchen Team)**
  - Add/update food items
  - Update prices
  - Mark items unavailable
  - Manage orders

---

**Architecture**

The project follows **Clean Architecture** principles:

```
ChuksKitchen/
├── Domain/          # Core business entities (User, Food, Order, Cart)
├── Application/     # CQRS commands, queries, handlers, validators, interfaces
├── Infrastructure/  # EF Core persistence, repositories, services, background jobs
├── Presentation/    # Minimal API endpoints, Program.cs (composition root)
└── Configuration/   # appsettings.json (DB, SMTP, logging)
```

- **Domain** → Pure business rules, no dependencies  
- **Application** → Business logic with CQRS + MediatR  
- **Infrastructure** → Persistence, repositories, email services, background jobs  
- **Presentation** → Minimal APIs, Swagger, DI setup  

---

**Tech Stack**
- **ASP.NET Core 8.0  >** (Minimal APIs)
- **Entity Framework Core** (SQL Server)
- **MediatR** (CQRS pattern)
- **FluentValidation** (Validation pipeline)
- **BackgroundService** (Pending signup cleanup)
- **Swagger/OpenAPI** (API documentation)

---

**Setup**

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/chuks-kitchen.git
   cd chuks-kitchen
   ```

2. Update **appsettings.json**:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=ChuksKitchenDb;Trusted_Connection=True;"
   },
   "SmtpSettings": {
     "Host": "smtp.gmail.com",
     "Port": 587,
     "FromAddress": "noreply@yourdomain.com",
     "Username": "yourgmail@gmail.com",
     "Password": "your-app-password",
     "EnableSsl": true
   }
   ```

3. Apply EF Core migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the project:
   ```bash
   dotnet run
   ```

5. Open Swagger UI at:
   ```
   https://localhost:5001/swagger
   ```

---

**Endpoints Overview**

- **User**
  - `POST /users/signup` → Register new user
  - `POST /users/verify-otp` → Verify OTP
- **Food**
  - `GET /foods` → Browse food items
  - `POST /foods` → Add food (Admin)
  - `PUT /foods/{id}` → Update food (Admin)
- **Cart**
  - `POST /users/{userId}/cart/add` → Add item to cart
  - `DELETE /users/{userId}/cart/remove/{foodId}` → Remove item
  - `GET /users/{userId}/cart` → View cart
- **Order**
  - `POST /orders` → Place order
  - `GET /orders/{id}` → Track order status


**Security & Roles**
- Customers and Admins are distinguished by role-based access (to be extended with authentication/authorization middleware).
- Sensitive values (SMTP password, connection strings) should be stored in **User Secrets** or **Environment Variables** in production.
