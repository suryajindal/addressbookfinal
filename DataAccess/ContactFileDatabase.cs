namespace addressbook.DataAccess
{
    using addressbook.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Windows.Storage;

    public class ContactFileDatabase : IContactRepository
    {
        private readonly string filePath;

        public ContactFileDatabase(string fileName)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists).GetAwaiter().GetResult();
            this.filePath = file.Path;
        }

        public void CreateOrUpdate(Contact contact)
        {
            IList<Contact> contacts = GetAll();
            var existingContact = contacts.SingleOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.Id = contact.Id;
                existingContact.Name = contact.Name;   
                existingContact.Email = contact.Email;  
                existingContact.Phone1 = contact.Phone1;
                existingContact.Phone2 = contact.Phone2;
                existingContact.MailingAddress  = contact.MailingAddress;
                existingContact.Url = contact.Url;
                //contacts.Remove(existingContact);
                //contacts.Add(contact);
            }
            else
            {
                if (contacts.Any())
                {
                    contact.Id = contacts.Max(c => c.Id) + 1;
                }
                else
                {
                    contact.Id = 1;
                }

                contacts.Add(contact);
            }

            SaveAll(contacts);
        }

        public IList<Contact> GetAll()
        {
            if (!File.Exists(filePath))
            {
                return new List<Contact>();
            }

            var lines = File.ReadAllLines(filePath);
            var contacts = new List<Contact>();
            foreach (var line in lines)
            {
                if(string.IsNullOrWhiteSpace(line)) continue;
                var parts = line.Split('|');
                var contact = new Contact(
                    int.Parse(parts[0]),
                    parts[1],
                    new Address(parts[2], parts[3], parts[4], parts[5], parts[6]),
                    parts[7],
                    parts[8],
                    parts[9],
                    parts[10]);

                contacts.Add(contact);
            }

            return contacts;
        }

        public void Update(Contact contact)
        {
            var contacts = GetAll();
            var existingContact = contacts.SingleOrDefault(c => c.Email == contact.Email);
            if (existingContact != null)
            {
                contacts.Remove(existingContact);
                contacts.Add(contact);
                SaveAll(contacts);
            }
        }

        public void Delete(int id)
        {
            var contacts = GetAll();
            var contactToDelete = contacts.SingleOrDefault(c => c.Id == id);
            if (contactToDelete != null)
            {
                contacts.Remove(contactToDelete);
                SaveAll(contacts);
            }
        }

        public IList<Contact> Filter(string firstAlphabet)
        {
            var contacts = GetAll();
            return contacts.Where(c => c.Name.ToUpper().StartsWith(firstAlphabet.ToUpper())).ToList();
        }

        private void SaveAll(IList<Contact> contacts)
        {
            var lines = contacts.Select(c => c.ToString());
            File.WriteAllLines(filePath, lines);
        }
    }
}
