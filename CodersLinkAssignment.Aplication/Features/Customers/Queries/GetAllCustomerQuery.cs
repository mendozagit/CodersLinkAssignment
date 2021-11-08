using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CodersLinkAssignment.Aplication.DTOs;
using CodersLinkAssignment.Aplication.Interfaces;
using CodersLinkAssignment.Aplication.Specifications;
using CodersLinkAssignment.Aplication.Wrappers;
using CodersLinkAssignment.Domain.Entities;
using MediatR;

namespace CodersLinkAssignment.Aplication.Features.Customers.Queries
{
    public class GetAllCustomerQuery : IRequest<PagedResponse<List<CustomerDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string LastName { get; set; }
        public string SortingDirection { get; set; }

    }
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, PagedResponse<List<CustomerDto>>>
    {
        private readonly IRepositoryAsync<Customer> _repository;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(IMapper mapper, IRepositoryAsync<Customer> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        public async Task<PagedResponse<List<CustomerDto>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.ListAsync(
                new PagedCustomerSpecification(
                    request.PageSize,
                    request.PageNumber,
                    request.LastName,
                    request.SortingDirection), cancellationToken);

            var customersDto = _mapper.Map<List<CustomerDto>>(customers);


            return new PagedResponse<List<CustomerDto>>(customersDto, request.PageSize, request.PageNumber);
        }
    }
}
