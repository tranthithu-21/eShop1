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

## 🎯 Chi tiết các công việc đã thực hiện (Project Implementation Details)

Nhằm đáp ứng yêu cầu khắt khe của một hệ thống e-commerce chuyên nghiệp và tuân thủ chặt chẽ mô hình **Clean Architecture** cũng như nguyên lý **SOLID**, các phân hệ và tính năng sau đã được xây dựng hoàn thiện trong đồ án:

### 1. Phân hệ Giao diện & Tương tác (Presentation - Blazor)
- **Phát triển Customer Portal Modules:** Xây dựng toàn bộ giao diện phía người dùng (Client-facing) với các thành phần tái sử dụng (Razor Components) như `ProductItemComponent`, `CartComponent`, `OrderSummaryComponent`, `CustomerFormComponent`.
- **Hoàn thiện luồng mua sắm (Shopping Flow):**
  - **Tìm kiếm và Duyệt sản phẩm:** Hiển thị danh mục sản phẩm, tìm kiếm theo tên và xem chi tiết sản phẩm.
  - **Quản lý Giỏ hàng:** Tính năng thêm vào giỏ, cập nhật số lượng trực tiếp (Update Quantity) và xóa sản phẩm khỏi giỏ (Delete Product).
  - **Tiến trình Đặt hàng:** Trang xác nhận thông tin người mua, tóm tắt đơn hàng và thực thi đặt hàng (Place Order).

### 2. Tầng Ứng dụng & Lõi nghiệp vụ (Use Cases & Core Business)
Phát triển các **Use Case** xử lý logic nghiệp vụ độc lập hoàn toàn với Framework giao diện và Cơ sở dữ liệu:
- **Product Use Cases:** `ViewProductUseCase`, `SearchProductUseCase`.
- **Shopping Cart Use Cases:** `ViewShoppingCartUseCase`, `UpdateQuantityUseCase`, `DeleteProductUseCase`, `AddProductToCartUseCase`.
- **Order Processing:** `PlaceOrderUseCase` xử lý nghiệp vụ tạo đơn hàng, tính toán tổng tiền, và gán mã đơn hàng duy nhất.
- Ứng dụng mạnh mẽ **Dependency Injection (DI)** thông qua việc định nghĩa các Interfaces (VD: `IPlaceOrderUseCase`, `IProductRepository`...) để nạp (inject) vào Blazor Components.

### 3. Tầng Dữ liệu & Cơ sở hạ tầng (Infrastructure - Plugins)
- Triển khai **Repository Pattern** chuyên nghiệp để giao tiếp với dữ liệu.
- Hoàn thiện module `eShop.DataStore.HardCoded` cung cấp dữ liệu giả lập (Mock Data) chuẩn xác cho Danh mục sản phẩm (Products) và Lưu trữ Đơn hàng (Orders Repository).
- Quản lý trạng thái State Management cho Shopping Cart an toàn và mượt mà trong quá trình người dùng duyệt web.

---

## 👨‍🎓 Sinh viên thực hiện

Dự án này được phân tích, thiết kế và phát triển bởi:
- **Họ và tên:** Trần Thị Thu
- **Mã sinh viên:** 23K4080049
