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
            // Domain to Dto
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
            
            // Dto to Domain
            CreateMap<CustomerDto, Customer>();
            CreateMap<MovieDto, Movie>();
        }
    }
}
