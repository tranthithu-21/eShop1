# 🛒 eShop - Blazor Clean Architecture

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor-5C2D91?style=for-the-badge&logo=blazor&logoColor=white)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-brightgreen?style=for-the-badge)

**eShop** is a modern e-commerce web application built using **.NET** and **Blazor**. The project is strictly designed following the principles of **Clean Architecture** to ensure robust separation of concerns, high maintainability, and scalability.

---

## ✨ Features
- **Product Management:** Browse and view detailed product information.
- **Shopping Cart:** Add, update, or remove items from the shopping cart.
- **Order Processing:** Place orders and manage order summaries securely.
- **Customer Portal:** Dedicated interfaces for user activities and interactions.

---

## 🏗️ Project Structure

The solution is divided into distinct layers enforcing a strict dependency rule: inner layers have no knowledge of outer layers.

### 1. Core Layers
- **`eShop.CoreBusiness`** (Domain): Contains core business entities, models, and intrinsic rules (e.g., `Product`, `Order`). This layer has **no dependencies** on any other project.
- **`eShop.UseCases`** (Application): Orchestrates business logic and use cases (e.g., `PlaceOrderUseCase`, `ViewShoppingCartUseCase`). It defines interfaces for external systems (e.g., Repositories) and depends only on `CoreBusiness`.

### 2. Infrastructure / Plugins
- **`Plugins/eShop.DataStore.HardCoded`**: Implements the repository interfaces defined in `eShop.UseCases`. This layer contains hardcoded data for development and testing environments, allowing the app to run without a live database.

### 3. Presentation Layer
- **`eShop.Web`**: The primary Blazor web application containing the user interface, pages, and dependency injection wiring (`Program.cs`). It depends on `UseCases`.
- **`eShop.Web.Modules`**: Houses encapsulated UI modules and reusable Razor components (e.g., Customer Portal).

---

## 🚀 Getting Started

### Prerequisites
- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- Visual Studio, Visual Studio Code, or Rider

### Running the Application Locally
1. **Clone the repository** to your local machine.
2. **Open the solution file** located at `eShop.Web/eShop.Web.sln`.
3. Set **`eShop.Web`** as the startup project.
4. **Run the application**:
   - In Visual Studio: Press `F5`
   - In CLI: Navigate to the `eShop.Web/eShop.Web` directory and run:
     ```bash
     dotnet run
     ```

---

## 🔗 Architecture Details

The project relies heavily on **Dependency Injection (DI)**. The `eShop.Web` project acts as the Composition Root, resolving interfaces from the UseCases to their concrete implementations within the Plugins layer at runtime.

---

## 👨‍🎓 Sinh viên thực hiện

Dự án này được thực hiện và phát triển bởi:
- **Họ và tên:** Trần Thị Thu
- **Mã sinh viên:** 23K4080049
