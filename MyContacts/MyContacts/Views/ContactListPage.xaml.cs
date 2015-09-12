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
    }
}
