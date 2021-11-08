using System.Collections.Generic;
using AutoMapper;
using CodersLinkAssignment.Aplication.DTOs;
using CodersLinkAssignment.Aplication.Features.Customers.Commands.Create;
using CodersLinkAssignment.Aplication.Features.Customers.Commands.Seeder;
using CodersLinkAssignment.Domain.Entities;

namespace CodersLinkAssignment.Aplication.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands

            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<SeedCustomerCommand, List<CreateCustomerCommand>>();
            #endregion


            #region DTOs

            CreateMap<Customer, CustomerDto>();

            #endregion
        }
    }
}
