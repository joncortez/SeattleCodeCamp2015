namespace MyContacts.Services
{
    public static class ServiceLocator
    {
        private static IContactsService _contactsService;

        public static IContactsService ContactsService
        {
            get { return _contactsService ?? (_contactsService = new ContactsService()); }
        }
    }
}
