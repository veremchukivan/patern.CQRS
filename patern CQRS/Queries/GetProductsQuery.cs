using MediatR;

namespace patern_CQRS.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;
}
