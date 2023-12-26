using MediatR;

namespace Application.Features.Category.Commands.AddCategory;

public record AddCategoryCommandRequest(string Name) : IRequest<bool>;
//public class AddCategoryCommandRequest : IRequest<bool>
//{
//    public string Nanme { get; set; }
//}