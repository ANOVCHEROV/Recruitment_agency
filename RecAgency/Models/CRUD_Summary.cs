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

        public IEnumerable<Summary> getContactsByStatus(int id)
        {
            return (from c in _entities.Summary
                    where c.Status == id
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
                Summary s =
                 (from c in _entities.Summary
                  where c.Id == id
                  select c).First();
                if (contact.IdOfAuthor != null)
                {
                    s.IdOfAuthor = contact.IdOfAuthor;
                }
                if (contact.DatePublication != null)
                {
                    s.DatePublication = contact.DatePublication;
                } 
                if (contact.FIO != null)
                {
                    s.FIO = contact.FIO;
                }
                if (contact.Info != null)
                {
                    s.Info = contact.Info;
                }
                if (contact.Experience != 0)
                {
                    s.Experience = contact.Experience;
                }
                if (contact.BaseProfession != null)
                {
                    s.BaseProfession = contact.BaseProfession;
                }
                if (contact.Age != 0)
                {
                    s.Age = contact.Age;
                }
                s.Sex = contact.Sex;
                if (contact.Status != 0)
                {
                    s.Status = contact.Status;
                }
                if (contact.Comment != null)
                {
                    s.Comment = contact.Comment;
                }







                _entities.SaveChanges();

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