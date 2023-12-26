using Application.Features.Category.Commands.AddCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Product.Commands.AddProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Response.Category;
using Application.Response.Product;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles;

public class Mappings:Profile
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
    }
}