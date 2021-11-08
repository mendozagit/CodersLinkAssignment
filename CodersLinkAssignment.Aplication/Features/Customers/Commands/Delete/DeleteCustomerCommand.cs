using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CodersLinkAssignment.Aplication.Interfaces;
using CodersLinkAssignment.Aplication.Wrappers;
using CodersLinkAssignment.Domain.Entities;
using MediatR;

namespace CodersLinkAssignment.Aplication.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _efcRepository;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandHandler(IRepositoryAsync<Customer> efcRepository, IMapper mapper)
        {
            _mapper = mapper;
            _efcRepository = efcRepository;
        }


        public async Task<Response<int>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var record = await _efcRepository.GetByIdAsync(request.Id, cancellationToken);

            if (record is null)
            {
                throw new KeyNotFoundException($"Record not found. Id {request.Id}");
            }

            await _efcRepository.DeleteAsync(record, cancellationToken);

            return new Response<int>(record.Id);
        }
    }
}
