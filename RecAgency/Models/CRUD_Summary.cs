using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecAgency.Models
{
    public class CRUD_Summary
    {
        private RAEntities3 _entities = new RAEntities3();

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

        public Summary getContactOnUser(string id)
        {
            try
            {
                return (from c in _entities.Summary
                        where c.IdOfAuthor == id
                        select c).First();
            }
            catch
            {
                return null;
            }


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
            

            int id = contact.Id;
            try
            {
                Summary s =
                 (from c in _entities.Summary
                  where c.Id == id
                  select c).First();
                s.IdOfAuthor = contact.IdOfAuthor;
                s.FIO = contact.FIO;
                s.Info = contact.Info;
                s.Experience = contact.Experience;
                s.DatePublication = contact.DatePublication;
                s.BaseProfession = contact.BaseProfession;
                s.Age = contact.Age;
                s.Sex = contact.Sex;

                _entities.SaveChanges();

                return true;
            }
            catch
            {
                return false;

            }
            
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