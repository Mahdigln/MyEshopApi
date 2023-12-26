﻿using Application.IRepositories;
using Domain.Models;
using MediatR;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Features.Product.Commands.DeleteProduct;

public record DeleteProductCommandRequest(int ProductId) : IRequest<bool>;
//public class DeleteProductCommandRequest : IRequest<bool>
//{
//    public int ProductId { get; set; }
//}


public class DeleteProductCommandRequestHandler : IRequestHandler<DeleteProductCommandRequest, bool>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandRequestHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<bool> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(request.ProductId, cancellationToken);
        if (product is not null)
        {
            _productRepository.Delete(product);
            await _productRepository.Save();
            return true;
        }
        return false;
    }
}