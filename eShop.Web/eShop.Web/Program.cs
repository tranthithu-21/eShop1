using eShop.DataStore.HardCoded;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.SearchProductScreen;
using eShop.UseCases.ViewProductScreen;
using eShop.UseCases.ViewProductScreen.interfaces;
using eShop.Web.Components;

namespace eShop.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<eShop.CoreBusiness.Services.interfaces.IOrderService, eShop.CoreBusiness.Services.OrderService>();

            // Chỉ định đầy đủ eShop.ShoppingCart.LocalStorage.ShoppingCart để tránh trùng tên Namespace
            builder.Services.AddScoped<IShoppingCart, eShop.ShoppingCart.LocalStorage.ShoppingCart>();
            builder.Services.AddScoped<eShop.UseCases.PluginInterfaces.StateStore.IShoppingCartStateStore, eShop.StateStore.DI.ShoppingCartStateStore>();

            builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
            builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
            builder.Services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
            builder.Services.AddTransient<eShop.UseCases.ShoppingCartScreen.interfaces.IViewShoppingCartUseCase, eShop.UseCases.ShoppingCartScreen.ViewShoppingCartUseCase>();
            builder.Services.AddTransient<eShop.UseCases.ShoppingCartScreen.interfaces.IDeleteProductUseCase, eShop.UseCases.ShoppingCartScreen.DeleteProductUseCase>();
            builder.Services.AddTransient<eShop.UseCases.ShoppingCartScreen.interfaces.IUpdateQuantityUseCase, eShop.UseCases.ShoppingCartScreen.UpdateQuantityUseCase>();
            builder.Services.AddTransient<eShop.UseCases.ShoppingCartScreen.interfaces.IPlaceOrderUseCase, eShop.UseCases.ShoppingCartScreen.PlaceOrderUseCase>();
            builder.Services.AddTransient<eShop.UseCases.OrderConfirmationScreen.interfaces.IViewOrderConfirmationUseCase, eShop.UseCases.OrderConfirmationScreen.ViewOrderConfirmationUseCase>();
            builder.Services.AddTransient<eShop.UseCases.AdminPortal.OutstandingOrdersScreen.IViewOutstandingOrdersUseCase, eShop.UseCases.AdminPortal.OutstandingOrdersScreen.ViewOutstandingOrdersUseCase>();
            builder.Services.AddTransient<eShop.UseCases.AdminPortal.ProcessedOrdersScreen.IViewProcessedOrdersUseCase, eShop.UseCases.AdminPortal.ProcessedOrdersScreen.ViewProcessedOrdersUseCase>();
            builder.Services.AddTransient<eShop.UseCases.AdminPortal.OrderDetailScreen.Interfaces.IViewOrderDetailUseCase, eShop.UseCases.AdminPortal.OrderDetailScreen.ViewOrderDetailUseCase>();
            builder.Services.AddTransient<eShop.UseCases.AdminPortal.OrderDetailScreen.Interfaces.IProcessOrderUseCase, eShop.UseCases.AdminPortal.OrderDetailScreen.ProcessOrderUseCase>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddAdditionalAssemblies(
                    typeof(eShop.Web.CustomerPortal.Pages.SearchProductComponent).Assembly,
                    typeof(eShop.Web.AdminPortal.Pages.OutstandingOrdersComponent).Assembly)
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}