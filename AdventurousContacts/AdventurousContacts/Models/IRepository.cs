using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models.Repositories
{
    public class IRepository : IDisposable
    {
        public void Add(Contact contact);
        public void Delete(Contact contact);
        public IQueryable<Contact> FindAllContacts();
        public Contact GetContactById(int contactId);
        public List<Contact> GetLastContacts(int count = 20);
        public void Save();
        public void Update(Contact contact);
    }
}