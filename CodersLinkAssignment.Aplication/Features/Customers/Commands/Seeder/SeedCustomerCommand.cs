using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CodersLinkAssignment.Aplication.Features.Customers.Commands.Create;
using CodersLinkAssignment.Aplication.Interfaces;
using CodersLinkAssignment.Aplication.Wrappers;
using CodersLinkAssignment.Domain.Entities;
using MediatR;

namespace CodersLinkAssignment.Aplication.Features.Customers.Commands.Seeder
{
    public class SeedCustomerCommand : IRequest<Response<int>>
    {
        public List<CreateCustomerCommand> Commands { get; set; }
    }

    public class SeedCustomerCommandHandler : IRequestHandler<SeedCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _repository;
        private readonly IMapper _mapper;

        public SeedCustomerCommandHandler(IRepositoryAsync<Customer> efcRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = efcRepository;
        }


        public async Task<Response<int>> Handle(SeedCustomerCommand request, CancellationToken cancellationToken)
        {
            var commadList = request.Commands.Select(command => _mapper.Map<CreateCustomerCommand>(command)).ToList();

            //for games is cool, but in real world should be implemented addRange method
            foreach (var customer in commadList.Select(command => _mapper.Map<Customer>(command)))
            {
                await _repository.AddAsync(customer, cancellationToken);
            }

            return new Response<int>(commadList.Count);
        }
    }
}
