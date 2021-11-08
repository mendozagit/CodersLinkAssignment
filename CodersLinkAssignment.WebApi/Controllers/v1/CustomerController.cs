using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodersLinkAssignment.Aplication.Features.Customers.Commands.Create;
using CodersLinkAssignment.Aplication.Features.Customers.Commands.Delete;
using CodersLinkAssignment.Aplication.Features.Customers.Commands.Seeder;
using CodersLinkAssignment.Aplication.Features.Customers.Commands.Update;
using CodersLinkAssignment.WebApi.Controllers.Base;
using CodersLinkAssignment.Aplication.Features.Customers.Queries;

namespace CodersLinkAssignment.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {
        // GET api/<controller>
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomerParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllCustomerQuery()
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                LastName = filter.LastName,
                SortingDirection = filter.SortingDirection
            }, default));
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery() { Id = id }));
        }


        // POST api/<controller>

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/<controller>/seed

        [HttpPost("{seed?}")]
        public async Task<IActionResult> Post(SeedCustomerCommand command, bool seed = true)
        {
            return Ok(await Mediator.Send(command));
        }


        // PUT api/<controller>/5

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateCustomerCommand command, int id)
        {
            if (command.Id != id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/6
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerCommand() { Id = id }));
        }
    }
}
