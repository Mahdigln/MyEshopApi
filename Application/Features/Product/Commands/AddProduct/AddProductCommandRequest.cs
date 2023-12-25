using Application.Response.Product;
using MediatR;

namespace Application.Features.Product.Commands.AddProduct;

public record AddProductCommandRequest(AddProductCommandResponse AddProductModel) : IRequest<bool>;