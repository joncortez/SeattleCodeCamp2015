using MyContacts.Models;
using Xamarin.Forms;

namespace MyContacts.Views
{
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage(Contact contact)
        {
            InitializeComponent();
            this.BindingContext = contact;
        }
    }
}
