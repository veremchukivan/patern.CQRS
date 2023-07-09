using MediatR;

namespace patern_CQRS.Commands
{
    public record AddProductCommand(Product product) : IRequest<Product>;
}
