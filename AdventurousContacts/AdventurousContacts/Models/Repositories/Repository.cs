using AdventurousContacts.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models.Repositories
{
    public class Repository : IRepository
    {
        private bool _disposed;
        private AdventurousContactsEntities _entities = new AdventurousContactsEntities();

        public void Add(Contact contact)
        {
            _entities.Contacts.Add(contact);
        }
        public void Delete(Contact contact)
        {
            if (_entities.Entry(contact).State == EntityState.Detached)
            {
                _entities.Contacts.Attach(contact);
            }
            _entities.Contacts.Remove(contact);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            this._disposed = true;
        }
        public IQueryable<Contact> FindAllContacts()
        {
            return _entities.Contacts.AsQueryable();
        }
        public Contact GetContactById(int contactId)
        {
            return _entities.Contacts.Find(contactId);
        }
        public List<Contact> GetLastContacts(int count = 20)
        {
            var collection = _entities.Contacts.AsEnumerable();
            return collection.Reverse().Take(count).Reverse().ToList();
        }
        public void Save()
        {
            _entities.SaveChanges();
        }
        public void Update(Contact contact)
        {
            if(_entities.Entry(contact).State == EntityState.Detached)
            {
                _entities.Contacts.Attach(contact);
            }
            _entities.Entry(contact).State = EntityState.Modified;
        }
    }
}