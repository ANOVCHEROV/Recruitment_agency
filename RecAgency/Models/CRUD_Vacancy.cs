using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecAgency.Models
{
    public class CRUD_Vacancy
    {
        private RAEntities2 _entities = new RAEntities2();

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
            int id = getContact(contact.Id).Id;
            try
            {
                Vacancy OriginalSum = getContact(contact.Id);
                var vac =
                     (from c in _entities.Vacancy
                      where c.Id == id
                      select c).First();
                vac.IdOfAuthor = OriginalSum.IdOfAuthor;
                vac.Address = OriginalSum.Address;
                vac.Info = OriginalSum.Info;
                vac.Experience = OriginalSum.Experience;
                vac.DateOfPublication= OriginalSum.DateOfPublication;
                vac.Field = OriginalSum.Field;
                vac.Name = OriginalSum.Name;
                vac.Salary = OriginalSum.Salary;
                vac.Schedule = OriginalSum.Schedule;
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