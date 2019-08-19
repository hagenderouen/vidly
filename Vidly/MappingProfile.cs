using System;
using AutoMapper;
using Vidly.Models;
using Vidly.Areas.Dtos;

namespace Vidly
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
