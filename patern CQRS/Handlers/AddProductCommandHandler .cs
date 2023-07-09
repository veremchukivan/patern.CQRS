using MediatR;
using patern_CQRS.Commands;

namespace patern_CQRS.Handlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly ProductStore _productStore;
        public AddProductCommandHandler(ProductStore productStore)
        {
            _productStore = productStore;
        }
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            int lastElementId = await _productStore.GetLastProductIdAsync();
            int newElId = lastElementId + 1;
            Product product = new Product()
            {
                Id = newElId,
                Name = request.product.Name
            };
            await _productStore.AddProductAsync(product);
            return product;
        }
    }
    public record GetProductByIdQuery(int id) : IRequest<Product>;


    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ProductStore _productStore;
        public GetProductByIdQueryHandler(ProductStore productStore)
        {
            _productStore = productStore;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) => await _productStore.GetProductByIdAsync(request.id);
    }
}
