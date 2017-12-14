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
        public ActionResult List(string id = "")
        {
            if (id == "")
            {
                return View(crud.getAllContacts());
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
            try
            {
                contact.DateOfPublication = DateTime.Now;
                contact.IdOfAuthor = User.Identity.GetUserId();
                int i = crud.addContact(contact);
                return RedirectToAction("Details", new { id = i });
            }
            catch
            {
                return View();
            }
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
            try
            {
                contact.DateOfPublication = DateTime.Now;
                crud.updateContact(contact);
                int i = contact.Id;
                return RedirectToAction("Details", new { id = i });
            }
            catch
            {
                return View();
            }
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
            try
            {
                crud.removeContact(id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
