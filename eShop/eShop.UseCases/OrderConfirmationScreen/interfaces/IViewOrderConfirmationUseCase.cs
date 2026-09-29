using eShop.CoreBusiness.Models;

namespace eShop.UseCases.OrderConfirmationScreen.interfaces
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(string uniqueId);
    }
}
