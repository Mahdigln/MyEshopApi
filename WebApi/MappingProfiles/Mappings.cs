using Application.Response.Product;
using AutoMapper;
using Domain.Models;
using WebApi.DTOs.Product;

namespace WebApi.MappingProfiles;

public class Mappings:Profile
{
    public Mappings()
    {
        CreateMap<AddProductCommandResponse, AddProductDto>().ReverseMap();
        
    }
}