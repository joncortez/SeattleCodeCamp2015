using MyContacts.Models;
using MyContacts.ViewModels;
using Xamarin.Forms;

namespace MyContacts.Views
{
    public partial class ContactListPage : ContentPage
    {
        public ContactListViewModel ViewModel
        {
            get { return BindingContext as ContactListViewModel; }
            set { BindingContext = value; }
        }

        public ContactListPage()
        {
            InitializeComponent();

            ViewModel = new ContactListViewModel(Navigation);
            ViewModel.RefreshCommand.Execute(null);
        }

        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var contact = args.Item as Contact;
            if (contact == null)
                return;

            Navigation.PushAsync(new ContactDetailsPage(contact));

            var list = sender as ListView;
            if (list == null)
                return;

            list.SelectedItem = null;
        }
    }
}
