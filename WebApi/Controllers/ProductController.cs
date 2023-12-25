using Application.Features.Product.Commands.AddProduct;
using Application.Features.Product.Queries;
using Application.Features.Product.Queries.GetProduct;
using Application.Features.Product.Queries.GetProductById;
using Application.Response.Product;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Product;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        //[HttpPost("AddProduct")]
        //public async Task<IActionResult> AddProduct([FromForm] AddProductModel model)
        //{
        //    bool isSuccessful = await _mediator.Send(new AddProductCommandRequest(model));
        //    if (isSuccessful)
        //    {
        //        return Ok();
        //    }
        //    return BadRequest();
        //}

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto model)
        {
            var command = _mapper.Map(model,new AddProductCommandResponse());
            bool isSuccessful = await _mediator.Send(new AddProductCommandRequest(command));
            if (isSuccessful)
            {
                return Ok();
            }
            return BadRequest();
        }

        //[HttpGet]
        //public async Task<IActionResult> GetProduct([FromBody] ProductModel model)
        //{
        //    var command = _mapper.Map(model, new ProductDto());
        //    ProductDto product = await _mediator.Send(new GetProductByIdQueryRequest(command.ProductId));
        //    if (product != null)
        //    {
        //        return Ok(product);
        //    }
        //    return NotFound();
        //}
        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProduct([FromRoute]int id)
        {
            ProductQueryResponse product = await _mediator.Send(new GetProductByIdQueryRequest(id));
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            List<ProductQueryResponse> products = await _mediator.Send(new GetProductQueryRequest());
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }
    }
}
