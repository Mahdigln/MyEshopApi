using FluentValidation;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandRequestHandlerValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandRequestHandlerValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("نام محصول را وارد کنید");
        RuleFor(p => p.Price).NotEmpty().GreaterThan(0).WithMessage("مقدار باید بیشتر از 0 باشد");
        RuleFor(p => p.CategoryId).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
        RuleFor(p => p.Inventory).NotEmpty().WithMessage("تعداد موجودی کالا را وارد کنید");
    }
}