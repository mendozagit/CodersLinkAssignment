using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CodersLinkAssignment.Aplication.DTOs;
using CodersLinkAssignment.Aplication.Interfaces;
using CodersLinkAssignment.Aplication.Wrappers;
using CodersLinkAssignment.Domain.Entities;
using MediatR;

namespace CodersLinkAssignment.Aplication.Features.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<Response<CustomerDto>>
    {
        public int Id { get; set; }
    }
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerDto>>
    {
        private readonly IRepositoryAsync<Customer> _repository;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(IMapper mapper, IRepositoryAsync<Customer> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<CustomerDto>> Handle(GetCustomerByIdQuery request,
            CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (customer is null)
                throw new KeyNotFoundException($"Record not found. Id {request.Id}");


            var customerDto = _mapper.Map<CustomerDto>(customer);

            return new Response<CustomerDto>(customerDto);
        }
    }

}
