using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyContacts.Configuration;
using MyContacts.Models;
using Newtonsoft.Json;

namespace MyContacts.Services
{
    public class ContactsService : IContactsService
    {
        public List<Contact> Contacts { get; private set; }

        public async Task LoadContacts()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(AppConstants.ContactSvcUrl);
                Contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
            }
        }
    }
}
