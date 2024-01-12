using Application.PipelineBehaviors.Validation;
using MediatR;

namespace Application.Features.Product.Commands.AddProduct;

public class AddProductCommandRequest : IRequest<bool>, IProduct, IValidatable
{
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
}

public interface IProduct
{
    public string Name { get; set; }

}