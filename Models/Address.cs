using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook.Models
{
    public class Address
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }    
        
        public string City { get; set; }
        
        public string State {get; set; }    
        
        public string ZipCode {get; set; }

        public Address(string addressline1, string addressline2, string city, string state, string zipcode) 
        { 
            this.AddressLine1 = addressline1;
            this.AddressLine2 = addressline2;
            this.City = city;
            this.State = state;
            this.ZipCode = zipcode;
        }

        public override string ToString()
        {
            return $"{AddressLine1} {AddressLine2} {City} {State} {ZipCode}";
        }
    }
}
