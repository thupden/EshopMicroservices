namespace Basket.Api.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string UserName, CancellationToken cancellationToken);
        Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken);
        Task<bool> DeleteBasket(string UserName, CancellationToken cancellationToken);
    }
}
