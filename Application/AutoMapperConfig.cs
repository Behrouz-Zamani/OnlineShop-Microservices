using Application.CQRS.ProductCommandQuery.Query;
using AutoMapper;
using Core.Entities;
using Infrastructure.Dto;

namespace Application;
public class AutoMapperConfig:Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Product,ProductDto>().ReverseMap();
        CreateMap<Product ,ProductDto>()
        .ForMember(dest => dest.PriceWithComma,opt => opt.MapFrom(src => string.Format("{0;n0}",src.Price)))
        .ReverseMap();

       CreateMap<Product,GetProductQueryResponce>()
       .ForMember(des=> des.Title,opt => opt.MapFrom(src => src.ProductName.ToUpper()))
       .ForMember(des=> des.PriceWithComma,opt => opt.MapFrom(src=> string.Format("{0:n0}",src.Price)));
    }
}