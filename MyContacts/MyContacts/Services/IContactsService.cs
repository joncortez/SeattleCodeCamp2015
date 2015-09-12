using System.Collections.Generic;
using System.Threading.Tasks;
using MyContacts.Models;

namespace MyContacts.Services
{
    public interface IContactsService
    {
        List<Contact> Contacts { get; }
        Task LoadContacts();
    }
}
