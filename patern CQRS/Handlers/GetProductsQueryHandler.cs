using MediatR;
using patern_CQRS.Queries;

namespace patern_CQRS.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly ProductStore _productStore;
        public GetProductsQueryHandler(ProductStore productStore)
        {
            _productStore = productStore;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productStore.GetAllProductsAsync();
        }
    }
}
