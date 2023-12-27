using Application.IRepositories;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandRequestHandler : IRequestHandler<UpdateCategoryCommandRequest, bool>
{

    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandRequestHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<bool> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {

        var category = await _categoryRepository.Get(request.Id, cancellationToken);
        if (category is not null)
        {
            //   var updatedCategory = _mapper.Map(request, category);
            category.Name = request.Name;
            category.CategoryId = request.Id;
            _categoryRepository.Update(category);

            await _categoryRepository.Save();
            return true;
        }
        return false;
    }

}