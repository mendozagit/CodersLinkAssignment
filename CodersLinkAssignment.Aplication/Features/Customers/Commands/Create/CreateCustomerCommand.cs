using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CodersLinkAssignment.Aplication.Interfaces;
using CodersLinkAssignment.Aplication.Wrappers;
using CodersLinkAssignment.Domain.Entities;
using MediatR;

namespace CodersLinkAssignment.Aplication.Features.Customers.Commands.Create
{
    public class CreateCustomerCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _repository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IRepositoryAsync<Customer> efcRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = efcRepository;
        }


        public async Task<Response<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            var data = await _repository.AddAsync(customer, cancellationToken);
            return new Response<int>(data.Id);
        }
    }
}
