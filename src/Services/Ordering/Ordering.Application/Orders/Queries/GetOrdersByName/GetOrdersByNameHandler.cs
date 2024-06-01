
namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    public class GetOrdersByNameHandler(IApplicationDbContext dbContext) 
        : IQueryHandler<GetOrdersByNameQuery, GetOrderByNameResult>
    {
        public async Task<GetOrderByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
        {
            //get orders by name using dbContext
            //return result
            //AsNoTracking will improve the performance by not tracking the entity. we can use this method for get request

            var orders = await dbContext.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.OrderName.Value.Contains(query.Name))
                .OrderBy(o => o.OrderName.Value)
                .ToListAsync(cancellationToken);

            return new GetOrderByNameResult(orders.ToOrderDtoList());
        }
    }
}
