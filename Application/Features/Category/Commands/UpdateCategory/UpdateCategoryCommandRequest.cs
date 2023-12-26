using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public record UpdateCategoryCommandRequest(int Id, string Name) : IRequest<bool>;