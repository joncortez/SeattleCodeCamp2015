using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MyContacts.Models;
using MyContacts.Services;
using Xamarin.Forms;

namespace MyContacts.ViewModels
{
    public class ContactListViewModel : BaseViewModel
    {
        private readonly IContactsService _contactsService;
        private readonly INavigation _navigation;

        public ObservableCollection<Contact> Contacts { get; set; }

        public ContactListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _contactsService = ServiceLocator.ContactsService;

            Contacts = new ObservableCollection<Contact>();
        }

        private Command _refreshCommand;

        public Command RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new Command(async () => await ExecuteRefreshCommand(), () => !IsRefreshing));
            }
        }

        private async Task ExecuteRefreshCommand()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;
            RefreshCommand.ChangeCanExecute();

            await _contactsService.LoadContacts();
            if (_contactsService.Contacts != null)
            {
                Contacts.Clear();
                var contacts = _contactsService.Contacts;
                foreach (var contact in contacts)
                {
                    Contacts.Add(contact);
                }
            }

            IsRefreshing = false;
            RefreshCommand.ChangeCanExecute();
        }
    }
}
