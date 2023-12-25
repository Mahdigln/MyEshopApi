using Application.Response.Product;
using AutoMapper;
using Domain.Models;

namespace Application.MappingProfiles;

public class Mappings:Profile
{
    public Mappings()
    {
        CreateMap<AddProductCommandResponse, Product>().ReverseMap();
        CreateMap<ProductQueryResponse, Product>().ReverseMap();
    }
}