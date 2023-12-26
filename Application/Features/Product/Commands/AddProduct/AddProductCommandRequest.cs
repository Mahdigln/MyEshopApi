﻿using Application.Response.Product;
using MediatR;

namespace Application.Features.Product.Commands.AddProduct;

public class AddProductCommandRequest : IRequest<bool>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
}