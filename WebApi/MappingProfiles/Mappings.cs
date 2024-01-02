using Application.Features.Address.Commands.AddAddress;
using Application.Features.Address.Commands.UpdateAddress;
using Application.Features.Category.Commands.AddCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Order.Commands.AddOrder;
using Application.Features.OrderItem.Commands.AddOrderItem;
using Application.Features.Product.Commands.AddProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Response.Product;
using AutoMapper;
using WebApi.DTOs.Address;
using WebApi.DTOs.Category;
using WebApi.DTOs.Order;
using WebApi.DTOs.OrderItem;
using WebApi.DTOs.Product;

namespace WebApi.MappingProfiles;

public class Mappings : Profile
{
    public Mappings()
    {
        #region Product
        CreateMap<AddProductCommandRequest, AddProductDto>().ReverseMap();
        CreateMap<UpdateProductCommandRequest, UpdateProductDto>().ReverseMap();
        CreateMap<ProductQueryParametersResponse, ProductQueryParametersDto>().ReverseMap();
        #endregion


        #region Category

        CreateMap<AddCategoryCommandRequest, AddCategoryDto>().ReverseMap();
        CreateMap<UpdateCategoryCommandRequest, UpdateCategoryDto>().ReverseMap();

        #endregion

        #region Address

        CreateMap<AddAddressCommandRequest, AddAddressDto>().ReverseMap();
        CreateMap<UpdateAddressCommandRequest, UpdateAddressDto>().ReverseMap();

        #endregion

        #region Order

        CreateMap<AddOrderCommandRequest, AddOrderDto>().ReverseMap();

        #endregion

        #region OrderItem

        CreateMap<AddOrderItemCommandRequest, AddOrderItemDto>().ReverseMap();

        #endregion

    }
}