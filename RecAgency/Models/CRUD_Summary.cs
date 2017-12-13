using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecAgency.Models
{
    public class CRUD_Summary
    {
        private RAEntities _entities = new RAEntities();

        public IEnumerable<Summary> getAllContacts()
        {
            return (from c in _entities.Summary
                    select c);
        }

        public Summary getContact(int id)
        {
            return (from c in _entities.Summary
                    where c.Id == id
                    select c).First();
        }
        
        public int addContact(Summary contact)
        {
            try
            {
                _entities.Summary.Add(contact);
                _entities.SaveChanges();
                return contact.Id;
            }
            catch
            {
                return 0;
            }
        }

        public bool updateContact(Summary contact)
        {
            int id = getContact(contact.Id).Id;
            try
            {
                Summary OriginalSum = getContact(contact.Id);
                var sum =
                     (from c in _entities.Summary
                        where c.Id == id
                        select c).First();
                sum.IdOfAuthor = OriginalSum.IdOfAuthor;
                sum.FIO = OriginalSum.FIO;
                sum.Info = OriginalSum.Info;
                sum.Experience = OriginalSum.Experience;
                sum.DatePublication = OriginalSum.DatePublication;
                sum.BaseProfession = OriginalSum.BaseProfession;
                sum.Age = OriginalSum.Age;
                sum.Sex = OriginalSum.Sex;
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }


        public bool removeContact(int id)
        {
            Summary contact = getContact(id);
            try
            {
                _entities.Summary.Remove(contact);
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}