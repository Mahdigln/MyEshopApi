using Application.Features.Address.Commands.AddAddress;
using Application.Features.Address.Commands.UpdateAddress;
using Application.Features.Authentication.Commands.Register;
using Application.Features.Authentication.Queries;
using Application.Features.Category.Commands.AddCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Order.Commands.AddOrder;
using Application.Features.OrderItem.Commands.AddOrderItem;
using Application.Features.OrderItem.Commands.AddSomeOrderItems;
using Application.Features.Product.Commands.AddProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Response.Product;
using AutoMapper;
using WebApi.DTOs.Address;
using WebApi.DTOs.Authentication;
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
        CreateMap<AddSomeOrderItemCommandRequest, AddSomeOrderItemsDto>().ReverseMap();

        #endregion

        #region Authentication

        CreateMap<RegisterCommandRequest, RegisterDto>().ReverseMap();
        CreateMap<LoginQueryRequest, LoginDto>().ReverseMap();

        #endregion
    }
}