using Application.Features.Product.Commands.AddProduct;
using Application.Features.Product.Commands.DeleteProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Features.Product.Queries.GetProduct;
using Application.Features.Product.Queries.GetProductById;
using Application.Response.Product;
using AutoMapper;
using MediatR;
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
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto model, CancellationToken cancellationToken)
        {
            var command = _mapper.Map(model, new AddProductCommandRequest());
            bool isSuccessful = await _mediator.Send(command, cancellationToken);
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
        public async Task<IActionResult> GetProduct([FromRoute] int id, CancellationToken cancellationToken)
        {
            ProductQueryResponse product = await _mediator.Send(new GetProductByIdQueryRequest(id), cancellationToken);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            List<ProductQueryResponse> products = await _mediator.Send(new GetProductQueryRequest(), cancellationToken);
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpPut("UpdateGetProducts/{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromForm] UpdateProductDto updateProduct, CancellationToken cancellationToken)
        {
            var command = _mapper.Map(updateProduct, new UpdateProductCommandRequest());
            command.ProductId = productId;
            bool IsSuccessFull = await _mediator.Send(command, cancellationToken);
            if (IsSuccessFull)
            {
                return Ok();
            }
            return NotFound();

        }
        [HttpDelete("DeleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            // bool isSuccessfull = await _mediator.Send(new DeleteProductCommandRequest(){ProductId = productId}); //whit out constructor
            // bool isSuccessfull = await _mediator.Send(new DeleteProductCommandRequest(productId)); //whit  constructor or record
            bool isSuccessfull = await _mediator.Send(new DeleteProductCommandRequest(productId), cancellationToken);

            if (isSuccessfull)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
