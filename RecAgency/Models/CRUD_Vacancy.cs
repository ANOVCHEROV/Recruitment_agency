using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecAgency.Models
{
    public class CRUD_Vacancy
    {
        private RAEntities4 _entities = new RAEntities4();

        public IEnumerable<Vacancy> getAllContacts()
        {
            return (from c in _entities.Vacancy
                    select c);
        }

        public Vacancy getContact(int id)
        {
            return (from c in _entities.Vacancy
                    where c.Id == id
                    select c).First();
        }

        public IEnumerable<Vacancy> getContactOnAuthor(string id)
        {
            return (from c in _entities.Vacancy
                    where c.IdOfAuthor == id
                    select c);
        }

        public int addContact(Vacancy contact)
        {
            try
            {
                _entities.Vacancy.Add(contact);
                _entities.SaveChanges();
                return contact.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("!!!!!!" + ex.Message);
                return 0;
            }
        }

        public bool updateContact(Vacancy contact)
        {
            int id = contact.Id;
            try
            {
                var vac =
                     (from c in _entities.Vacancy
                      where c.Id == id
                      select c).First();
                vac.IdOfAuthor = contact.IdOfAuthor;
                vac.Address = contact.Address;
                vac.Info = contact.Info;
                vac.Experience = contact.Experience;
                vac.DateOfPublication= contact.DateOfPublication;
                vac.Field = contact.Field;
                vac.Name = contact.Name;
                vac.Salary = contact.Salary;
                vac.Schedule = contact.Schedule;
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
            Vacancy contact = getContact(id);
            try
            {
                _entities.Vacancy.Remove(contact);
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