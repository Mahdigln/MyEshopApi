using Application.PipelineBehaviors.Validation;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandRequest : IRequest<bool>, IValidatable
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Description { get; set; }

    public int CategoryId { get; set; }


}