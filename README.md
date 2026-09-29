# eShop

eShop is an e-commerce web application built using .NET and Blazor. The project is structured following the principles of Clean Architecture to ensure separation of concerns, maintainability, and scalability.

## Project Structure

The solution is divided into several projects and folders:

### Core Layers
- **`eShop.CoreBusiness`**: The domain layer containing the core entities, models, and business rules (e.g., Product, Order).
- **`eShop.UseCases`**: The application layer containing the business logic and use case implementations (e.g., AddProductToCart, ViewProductScreen, ShoppingCartScreen). It also defines interfaces for dependencies like repositories.

### Infrastructure / Plugins
- **`Plugins/eShop.DataStore.HardCoded`**: The infrastructure layer containing hardcoded data repository implementations (like `OrderRepository`) for development and testing without a live database.

### Presentation Layer
- **`eShop.Web`**: The main Blazor web application. It contains the user interface components, pages, and startup configuration (`Program.cs`).
- **`eShop.Web.Modules`**: Contains additional web modules, reusable UI components, or specific feature modules.

## Technologies Used
- **.NET** (C#)
- **Blazor** (Web Framework)
- **Clean Architecture** patterns

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- Visual Studio, Visual Studio Code, or Rider

### Running the Application
1. Clone or download the repository to your local machine.
2. Open the solution file located at `eShop.Web/eShop.Web.sln`.
3. Ensure that `eShop.Web` is set as the startup project.
4. Run the application (Press `F5` in Visual Studio or use `dotnet run` inside the `eShop.Web/eShop.Web` directory).

## Architecture Details

This project follows a strict dependency rule where outer layers depend on inner layers:
1. **CoreBusiness** has no dependencies on any other project.
2. **UseCases** depends only on **CoreBusiness**.
3. **Plugins** (Infrastructure) implement the interfaces defined in **UseCases** but are injected at runtime.
4. **Web** (Presentation) depends on **UseCases** and configures Dependency Injection to wire up the **Plugins**.

## Sinh viên thực hiện
- **Họ và tên:** Trần Thị Thu
- **Mã sinh viên:** 23K4080049
