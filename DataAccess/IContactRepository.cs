using addressbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook.DataAccess
{
    public interface IContactRepository
    {
        IList<Contact> GetAll();

        void CreateOrUpdate(Contact contact);

        void Delete(int id);

        IList<Contact> Filter(string filterString);
    }
}
