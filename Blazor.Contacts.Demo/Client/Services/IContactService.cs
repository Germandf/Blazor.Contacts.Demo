using Blazor.Contacts.Demo.Shared;

namespace Blazor.Contacts.Demo.Client.Services
{
    public interface IContactService
    {
        public Task SaveContact(Contact contact);
        public Task DeleteContact(int id);
        public Task<IEnumerable<Contact>> GetAllContacts();
        public Task<Contact> GetContactDetails(int id);
    }
}
