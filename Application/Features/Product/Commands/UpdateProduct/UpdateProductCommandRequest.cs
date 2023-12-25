using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct;

public record UpdateProductCommandRequest: IRequest<bool>;