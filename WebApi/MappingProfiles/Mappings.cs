using Application.Features.Category.Commands.AddCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Product.Commands.AddProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Response.Product;
using AutoMapper;
using Domain.Models;
using WebApi.DTOs.Category;
using WebApi.DTOs.Product;

namespace WebApi.MappingProfiles;

public class Mappings:Profile
{
    public Mappings()
    {
        CreateMap<AddProductCommandRequest, AddProductDto>().ReverseMap();
        CreateMap<UpdateProductCommandRequest, UpdateProductDto>().ReverseMap();


        CreateMap<AddCategoryCommandRequest, AddCategoryDto>().ReverseMap();
        CreateMap<UpdateCategoryCommandRequest, UpdateCategoryDto>().ReverseMap();

    }
}