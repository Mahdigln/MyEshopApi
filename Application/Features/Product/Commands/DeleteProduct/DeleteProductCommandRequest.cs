using MediatR;

namespace Application.Features.Product.Commands.DeleteProduct;

public record DeleteProductCommandRequest(int ProductId) : IRequest<bool>;
//public class DeleteProductCommandRequest : IRequest<bool>
//{
//    public int ProductId { get; set; }
//}