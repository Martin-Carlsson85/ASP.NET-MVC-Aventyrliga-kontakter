using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdventurousContacts.Models.DataModels;

namespace AdventurousContacts.Models
{
    public class Repository
    {
        private bool _disposed;
        private AdventurousContactsEntities _entities = new AdventurousContactsEntities();

        public void Add(Contact contact)
        {
            throw new NotImplementedException();
        }
        public void Delete(Contact contact)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!this._disposed)
            {
                if(disposing)
                {
                    _entities.Dispose();
                }
            }
            this._disposed = true;
        }
        public IQueryable<Contact> FindAllContacts()
        {
            throw new NotImplementedException();
        }

        public Contact GetContactById(int contactId)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetLastContacts(int count = 20)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

    }
}