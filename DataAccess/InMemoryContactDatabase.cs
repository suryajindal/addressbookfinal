namespace addressbook.DataAccess
{
    using addressbook.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class InMemoryContactDatabase : IContactRepository
    {
        private static IList<Contact> contacts = new List<Contact>();

        public void Delete(int id)
        {
            foreach (Contact contact in contacts)
            {
                if (contact.Id == id)
                {
                    contacts.Remove(contact);
                    break;
                }
            }
        }

        public IList<Contact> Filter(string firstAlphabet)
        {
            var filteredContacts = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (contact.Name.Trim().Substring(0, 1).ToUpper() == firstAlphabet.ToString())
                {
                    filteredContacts.Add(contact);
                }
            }

            return filteredContacts;
        }

        public IList<Contact> GetAll()
        {
            return contacts;
        }

        public void CreateOrUpdate(Contact contact)
        {
            bool isUpdate = false;
            foreach (Contact item in contacts)
            {
                if (item.Id == contact.Id)
                {
                    isUpdate = true;
                    item.Name = contact.Name;
                    item.Phone1 = contact.Phone1;
                    item.Phone2 = contact.Phone2;
                    item.MailingAddress = contact.MailingAddress;
                    item.Email = contact.Email;
                    item.Url = contact.Url;
                    break;
                }
            }

            if (!isUpdate)
            {
                contact.Id = contacts.Last().Id + 1;
                contacts.Add(contact);
            }
        }
    }
}
