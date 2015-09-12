using System.Threading.Tasks;

namespace MyContacts.Services
{
    public interface IContactsService
    {
        Task LoadContacts();
    }
}
