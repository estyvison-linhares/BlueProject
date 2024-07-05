using BlueProject.Business.Command;
using BlueProject.Business.Dto;
using BlueProject.Business.Query;
using BlueProject.Business.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlueProject.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetAllContacts()
        {
            var query = new GetAllContactsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> GetContactById(int id)
        {
            var query = new GetContactByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/contacts
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ContactDto>>> CreateContact(CreateContactCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT: api/contacts/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<ContactDto>>> UpdateContact(int id, UpdateContactBaseCommand command)
        {
            var updateCommand = new UpdateContactCommand(command.Name, command.Email, command.Phone)
            {
                Id = id
            };

            var result = await _mediator.Send(updateCommand);
            return Ok(result);
        }

        // DELETE: api/contacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteContact(int id)
        {
            var command = new DeleteContactCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
