using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CodersLinkAssignment.Aplication.Interfaces;
using CodersLinkAssignment.Aplication.Wrappers;
using CodersLinkAssignment.Domain.Entities;
using MediatR;

namespace CodersLinkAssignment.Aplication.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Customer> _efcRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IRepositoryAsync<Customer> efcRepository, IMapper mapper)
        {
            _mapper = mapper;
            _efcRepository = efcRepository;
        }


        public async Task<Response<int>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {


            var record = await _efcRepository.GetByIdAsync(request.Id, cancellationToken);

            if (record is null)
            {
                throw new KeyNotFoundException($"Record not found. Id {request.Id}");
            }

            record.FirstName = request.FirstName;
            record.LastName = request.FirstName;
            record.PhoneNumber = request.PhoneNumber;
            record.Email = request.Email;

            await _efcRepository.UpdateAsync(record, cancellationToken);

            return new Response<int>(record.Id);


        }
    }
}
