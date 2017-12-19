using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecAgency.Models;
using Microsoft.AspNet.Identity;

namespace RecAgency.Controllers
{
    public class VacController : Controller
    {
        CRUD_Vacancy crud = new CRUD_Vacancy();
        // GET: Vac
        public ActionResult List(string id = "", List<Vacancy> vacs = null)
        {
            if (id == "")
            {
                if (vacs != null)
                {
                    return View(vacs);
                }
                else
                {
                    return View(crud.getAllContacts());
                }
                
            }
            else
            {
                return View(crud.getContactOnAuthor(id));
            }
        }

        // GET: Vac/Details/5
        public ActionResult Details(int id)
        {
            return View(crud.getContact(id));
        }
        [Authorize(Roles = "Employer")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        public ActionResult Create(Vacancy contact)
        {
            Log.For(this).Info("User " + User.Identity.GetUserId() + " created a vacancy " + contact.Id);
            contact.DateOfPublication = DateTime.Now;
                contact.IdOfAuthor = User.Identity.GetUserId();
                int i = crud.addContact(contact);
                return RedirectToAction("Details", new { id = i });
        }

        // GET: Vac/Edit/5
        [Authorize(Roles = "Employer")]
        public ActionResult Edit(int id)
        {
            var contact = crud.getContact(id);
            if (contact.IdOfAuthor == User.Identity.GetUserId())
            {
                return View(contact);
            }
            return RedirectToAction("Error", "Home", new { error="Запрещено редактировать вакансии других работдателей"});
        }

        // POST: Vac/Edit/5
        [HttpPost]
        [Authorize(Roles = "Employer")]
        public ActionResult Edit(Vacancy contact)
        {
            Log.For(this).Info("User " + User.Identity.GetUserId() + " editted his vacancy " + contact.Id);
            contact.DateOfPublication = DateTime.Now;
                contact.IdOfAuthor = User.Identity.GetUserId();
                crud.updateContact(contact);
                int i = contact.Id;
                return RedirectToAction("Details", new { id = i });
        }
        [Authorize(Roles = "Employer")]
        public ActionResult Delete(int id)
        {
            return View(crud.getContact(id));
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Log.For(this).Info("User " + User.Identity.GetUserId() + " deleted his vacancy " + id);
            crud.removeContact(id);
                return RedirectToAction("List");
        }

        public ActionResult VacFilter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VacFilter(VacFilter filter)
        {

            Filters filters = new Filters();
            List<Vacancy> vacs = new List<Vacancy>();
            if (filter.Salary != 0 && filter.KeyWords != null)
            {
                vacs = filters.ForKeyWords(filters.ForSalary(crud.getAllContacts(), filter.Salary), filter.KeyWords).ToList();
            }
            else
            {
                if (filter.Salary != 0)
                {
                    vacs = filters.ForSalary(crud.getAllContacts(), filter.Salary).ToList();
                }
                if (filter.KeyWords != null)
                {
                    vacs = filters.ForKeyWords(crud.getAllContacts(), filter.KeyWords).ToList();
                }
            }
            return View("List", vacs);
        }

    }
}
