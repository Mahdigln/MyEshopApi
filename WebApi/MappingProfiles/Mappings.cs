using Application.Features.Address.Commands.AddAddress;
using Application.Features.Category.Commands.AddCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Product.Commands.AddProduct;
using Application.Features.Product.Commands.UpdateProduct;
using AutoMapper;
using WebApi.DTOs.Address;
using WebApi.DTOs.Category;
using WebApi.DTOs.Product;

namespace WebApi.MappingProfiles;

public class Mappings : Profile
{
    public Mappings()
    {
        #region Product
        CreateMap<AddProductCommandRequest, AddProductDto>().ReverseMap();
        CreateMap<UpdateProductCommandRequest, UpdateProductDto>().ReverseMap();

        #endregion


        #region Category

        CreateMap<AddCategoryCommandRequest, AddCategoryDto>().ReverseMap();
        CreateMap<UpdateCategoryCommandRequest, UpdateCategoryDto>().ReverseMap();

        #endregion

        #region Address

        CreateMap<AddAddressCommandRequest, AddAddressDto>().ReverseMap();

        #endregion

    }
}