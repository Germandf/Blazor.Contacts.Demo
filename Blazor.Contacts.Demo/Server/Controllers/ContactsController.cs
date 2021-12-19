using Blazor.Contacts.Demo.Repositories;
using Blazor.Contacts.Demo.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Contacts.Demo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            if (contact is null)
                return BadRequest();
            if (string.IsNullOrWhiteSpace(contact.FirstName))
                ModelState.AddModelError("FirstName", "First name can't be empty");
            if (string.IsNullOrWhiteSpace(contact.LastName))
                ModelState.AddModelError("LastName", "Last name can't be empty");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _contactRepository.InsertContact(contact);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
        {
            if (contact is null)
                return BadRequest();
            if (string.IsNullOrWhiteSpace(contact.FirstName))
                ModelState.AddModelError("FirstName", "First name can't be empty");
            if (string.IsNullOrWhiteSpace(contact.LastName))
                ModelState.AddModelError("LastName", "Last name can't be empty");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _contactRepository.UpdateContact(contact);
            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _contactRepository.GetAllContacts();
        }

        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await _contactRepository.GetContactDetails(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _contactRepository.DeleteContact(id);
        }
    }
}
