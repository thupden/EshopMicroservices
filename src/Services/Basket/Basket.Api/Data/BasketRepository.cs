namespace Basket.Api.Data
{
    public class BasketRepository(IDocumentSession session)
        : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string UserName, CancellationToken cancellationToken)
        {
            session.Delete<ShoppingCart>(UserName);
            await session.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<ShoppingCart> GetBasket(string UserName, CancellationToken cancellationToken)
        {
            var basket = await session.LoadAsync<ShoppingCart>(UserName, cancellationToken);
            return basket is null ? throw new BasketNotFoundException(UserName): basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken)
        {
            session.Store(basket);
            await session.SaveChangesAsync(cancellationToken);
            return basket;
        }
    }
}
