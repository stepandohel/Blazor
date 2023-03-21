﻿using AutoMapper;
using Domain.Data.Entities;
using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
