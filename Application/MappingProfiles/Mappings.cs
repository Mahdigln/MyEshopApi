﻿using Application.Features.Address.Commands.AddAddress;
using Application.Features.Address.Commands.UpdateAddress;
using Application.Features.Category.Commands.AddCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Order.Commands.AddOrder;
using Application.Features.OrderItem.Commands.AddOrderItem;
using Application.Features.Product.Commands.AddProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Response.Address;
using Application.Response.Category;
using Application.Response.Order;
using Application.Response.OrderItem;
using Application.Response.Product;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles;

public class Mappings : Profile
{
    public Mappings()
    {
        #region Product

        CreateMap<AddProductCommandRequest, Product>().ReverseMap();
        CreateMap<ProductQueryResponse, Product>().ReverseMap();
        CreateMap<UpdateProductCommandRequest, Product>().ReverseMap();

        #endregion


        #region Category

        CreateMap<AddCategoryCommandRequest, Category>().ReverseMap();
        CreateMap<CategoryQueryResponse, Category>().ReverseMap();
        CreateMap<UpdateCategoryCommandRequest, Category>().ReverseMap();

        #endregion

        #region Address

        CreateMap<AddAddressCommandRequest, Address>().ReverseMap();
        CreateMap<AddressQueryResponse, Address>().ReverseMap();
        CreateMap<UpdateAddressCommandRequest, Address>().ReverseMap();
        #endregion

        #region Order

        CreateMap<AddOrderCommandRequest, Order>().ReverseMap();
        CreateMap<OrderQueryResponse, Order>().ReverseMap();

        #endregion

        #region OrderItem

        CreateMap<AddOrderItemCommandRequest, OrderItem>().ReverseMap();
        CreateMap<OrderItemQueryResponse, OrderItem>().ReverseMap();

        #endregion
    }
}