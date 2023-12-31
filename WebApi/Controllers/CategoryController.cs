using Application.Features.Category.Commands.AddCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetCategory;
using Application.Features.Category.Queries.GetCategoryById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Category;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromForm] AddCategoryDto model, CancellationToken cancellationToken)
        {
            // var command =_mapper.Map(model, new AddCategoryCommandRequest(model.Name));
            var command = _mapper.Map(model, new AddCategoryCommandRequest(model.Name));
            bool isSuccessfull = await _mediator.Send(command, cancellationToken);
            if (isSuccessfull)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(CancellationToken cancellationToken)
        {
            var category = await _mediator.Send(new GetCategoryQueryRequest(), cancellationToken);
            if (category is not null)
            {
                return Ok(category);
            }
            return NotFound();
        }

        [HttpGet("GetCategoryById/{categoryId}")]
        public async Task<IActionResult> GetCategory([FromRoute] int categoryId, CancellationToken cancellationToken)
        {
            var category = await _mediator.Send(new GetCategoryByIdQueryRequest(categoryId), cancellationToken);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int categoryId, UpdateCategoryDto updateCategory,
            CancellationToken cancellationToken)
        {
            var command = _mapper.Map(updateCategory, new UpdateCategoryCommandRequest(categoryId, updateCategory.Name));

            bool IsSuccessFull = await _mediator.Send(command, cancellationToken);
            if (IsSuccessFull)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
