namespace addressbook.Models
{
    using addressbook.DataAccess;
    using System.Collections.ObjectModel;

    internal static class ContactManager
    {
        private static IContactRepository contactRepository = new ContactFileDatabase("contactdb.csv");
        //private static IContactRepository contactRepository = new InMemoryContactDatabase();

        static ContactManager()
        {
            //PopulateSampleData();
        }

        public static void GetAllContacts(ObservableCollection<Contact> contacts)
        {
            contacts.Clear();
            foreach (var contact in contactRepository.GetAll())
            {
                contacts.Add(contact);
            }
        }

        public static void GetContactsByAlphabet(ObservableCollection<Contact> contacts, Alphabet firstAlphabet)
        {
            contacts.Clear();
            foreach (var contact in contactRepository.Filter(firstAlphabet.ToString()))
            {
                contacts.Add(contact);
            }
        }

        public static void DeleteContact(ObservableCollection<Contact> contacts, Contact selectedContact)
        {
            contactRepository.Delete(selectedContact.Id);
            contacts.Clear();
            foreach (var contact in contactRepository.GetAll())
            {
                contacts.Add(contact);
            }
        }

        public static void AddOrUpdateContact(ObservableCollection<Contact> contacts, Contact contactToSave)
        {
            contactRepository.CreateOrUpdate(contactToSave);
            contacts.Clear();
            foreach (var contact in contactRepository.GetAll())
            {
                contacts.Add(contact);
            }
        }

        private static void PopulateSampleData()
        {
            contactRepository.CreateOrUpdate(new Contact(1, "Arun Nair", new Address("19716 SE 17th St", null, "Sammamish", "WA", "98075"), null, "arun.nair@gmail.com", "4258907890", null));
            contactRepository.CreateOrUpdate(new Contact(2, "Geeta Kapoor", new Address("4326 Athens St", null, "San Diego", "CA", "92115"), null, "geeta.kapoor@gmail.com", "6194328909", "6194447890"));
            contactRepository.CreateOrUpdate(new Contact(3, "Charvi Jain", new Address("2566 Dow Street", "PO Box 168", "Houston", "Texas", "77494"), "https://www.linkedin.com/in/charvi-jain-b5897b189", "charvi.jain@gmail.com", "2104567890", "2103425678"));
            contactRepository.CreateOrUpdate(new Contact(4, "Andrew Collins", new Address("121 Alexander Ave", null, "Montclair", "New Jersey", "07043"), null, "andrew.collins@gmail.com", "2118795689", null));
            contactRepository.CreateOrUpdate(new Contact(5, "Sophie Webster", new Address("63 Melcher St", "Apt #307", "Boston", "MA", "02127"), "https://www.linkedin.com/in/sophiecwebster", "sophie.webster@gmail.com", "8576903421", null));
            contactRepository.CreateOrUpdate(new Contact(6, "Ulla Johnson", new Address("93 NORTH 9TH STREET", null, "Brooklyn", "NY", "11211"), null, "ulla.johnson@gmail.com", "4567893456", null));
            contactRepository.CreateOrUpdate(new Contact(7, "Robert Jackson", new Address("202 HARLOW ST", null, "BANGOR", "ME", "04901"), null, "robert.jackson@gmail.com", "7456789234", null));
            contactRepository.CreateOrUpdate(new Contact(8, "Ulla Johnson", new Address("46 FRONT STREET", null, "WATERVILLE", "ME", "02903"), null, "ulla.johnson@gmail.com", "5456789098", null));
            contactRepository.CreateOrUpdate(new Contact(9, "Keith Arora", new Address("22 SUSSEX ST", null, "HACKENSACK", "NJ", "07601"), null, "keith.arora@gmail.com", "6456789340", null));
            contactRepository.CreateOrUpdate(new Contact(10, "Shally Whitman", new Address("520 5TH AVE", null, "MCKEESPORT", "PA", "15132"), null, "shally.whitman@gmail.com", "8456789095", null));
            contactRepository.CreateOrUpdate(new Contact(11, "Hailey Pattinson", new Address("337 BRIGHTSEAT ROAD", null, "LANDOVER", "MD", "20785"), null, "hailey.pattinson@gmail.com", "9470789654", null));
            contactRepository.CreateOrUpdate(new Contact(12, "Monica Bhatia", new Address("1925 E MAIN ST", null, "ALBEMARLE", "NC", "28001"), null, "monica.bhatia@gmail.com", "9470345654", null));
            contactRepository.CreateOrUpdate(new Contact(13, "Zayn Khan", new Address("337 BRIGHTSEAT ROAD", null, "LANDOVER", "MD", "20785"), null, "zayn.Khan@gmail.com", "9420289654", null));
            contactRepository.CreateOrUpdate(new Contact(14, "Chen Hu", new Address("97 WEST OAK AVE", null, "PANAMA CITY", "FL", "32401"), null, "chen.hu@gmail.com", "4570789654", null));
            contactRepository.CreateOrUpdate(new Contact(15, "James Smith", new Address("203 SOUTH WALNUT ST", null, "FLORENCE", "AL", "35630"), null, "JamesSmith@gmail.com", "4412389654", null));
            contactRepository.CreateOrUpdate(new Contact(16, "Christopher Anderson", new Address("108 CENTER POINTE DR", null, "CLARKSVILLE", "TN", "37040"), null, "ChristopherAnderson@gmail.com", "5423489654", null));
            contactRepository.CreateOrUpdate(new Contact(17, "Ronald Clark", new Address("1301 GREENE STREET", null, "MARIETTA", "OH", "45750"), null, "RonaldClark@gmail.com", "6434589654", null));
            contactRepository.CreateOrUpdate(new Contact(18, "Mary Wright", new Address("602 SOUTH MICHIGAN ST", null, "SOUTH BEND", "IN", "46601"), null, "MaryWright@gmail.com", "7445689654", null));
            contactRepository.CreateOrUpdate(new Contact(19, "Lisa Mitchell", new Address("317 SOUTH DRAKE ROAD", null, "KALAMAZOO", "MI", "49009"), null, "LisaMitchell@gmail.com", "8456789654", null));
            contactRepository.CreateOrUpdate(new Contact(20, "Daniel Rodriguez", new Address("311839 Federalist Way", null, "Fairfax ", "VA", "22030"), null, "DanielRodriguez@gmail.com", "9467889654", null));
            contactRepository.CreateOrUpdate(new Contact(21, "Anthony Lopez", new Address("400 Monroe St", null, "Hoboken", "NJ", "07030"), null, "AnthonyLopez@gmail.com", "3478989654", null));
            contactRepository.CreateOrUpdate(new Contact(22, "Patricia Perez", new Address("2900 4TH AVE", null, "BILLINGS ", "MT", "59101"), null, "PatriciaPerez@gmail.com", "4498789654", null));
            contactRepository.CreateOrUpdate(new Contact(23, "Barbara Harris", new Address("158 N SCOTT STREET", null, "JOLIET", "IL", "60432"), null, "BarbaraHarris@aol.com", "7434589654", null));
            contactRepository.CreateOrUpdate(new Contact(24, "Elizabeth Hall", new Address("1207 NETWORK CENTRE DR", null, "EFFINGHAM", "IL", "62401"), null, "ElizabethHall@aol.com", "8440589654", null));
            contactRepository.CreateOrUpdate(new Contact(25, "Donald Davis", new Address("300 E 3RD ST", null, "NORTH PLATTE", "NE", "69101"), null, "DonaldDavis@aol.com", "7409889654", null));
            contactRepository.CreateOrUpdate(new Contact(26, "Ruth Taylor", new Address("101 West End Avenue", null, "New York", "NY", "10023"), null, "RuthTaylor@facebook.com", "6420989654", null));
        }
    }
}
