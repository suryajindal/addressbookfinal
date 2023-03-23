using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace addressbook.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Address MailingAddress {get; set; }
        
        public string Url { get; set; } 
        
        public string Email { get; set; }
        
        public string Phone1 { get; set; }
        
        public string Phone2 { get; set; }

        public Contact(int Id,string name, Address address, string url, string email, string phone1, string phone2)
        {
            
            this.Id = Id;   
            this.Name = name;
            this.MailingAddress = address;
            this.Url = url;
            this.Email = email;
            this.Phone1 = phone1;
            this.Phone2 = phone2;
        }

        public override string ToString()
        {
            return $"{Id}|{Name}|{MailingAddress.AddressLine1}|{MailingAddress.AddressLine2}|{MailingAddress.City}|{MailingAddress.State}|{MailingAddress.ZipCode}|{Url}|{Email}|{Phone1}|{Phone2}";
        }
    }
}
