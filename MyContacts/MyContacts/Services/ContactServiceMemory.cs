using System.Collections.Generic;
using System.Threading.Tasks;
using MyContacts.Core.Models;

namespace MyContacts.Core.Services
{
    public class ContactServiceMemory : IContactService
    {
        private static IList<Contact> _contacts;

        public async Task<IList<Contact>> GetAllContacts()
        {
            if (_contacts == null)
                _contacts = SimpsonFactory.Characters;

            return await Task<IList<Contact>>.Factory.StartNew(() => _contacts);
        }
    }
}
