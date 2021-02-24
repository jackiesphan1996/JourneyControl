using AutoMapper;
using JourneyControl.Application.Features.Products.Commands.CreateProduct;
using JourneyControl.Application.Features.Products.Queries.GetAllProducts;
using JourneyControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JourneyControl.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
