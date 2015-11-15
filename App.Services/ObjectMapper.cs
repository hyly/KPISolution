using System;
using System.Collections.Generic;
using AutoMapper;
using App.Data.DomainModel.Entities;
using App.Services.Core;

namespace App.Services.Implementation
{
    public class ObjectMapper
    {
        public static void CreateObjectServicesMap() {
            Mapper.CreateMap<Product, ProductDto>();
        }
    }
}
