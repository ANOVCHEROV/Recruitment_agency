using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecAgency.Models;

namespace RecAgency.Controllers
{
    public class VacController : Controller
    {
        CRUD_Vacancy crud = new CRUD_Vacancy();
        // GET: Vac
        public ActionResult List()
        {
            return View(crud.getAllContacts());
        }

        // GET: Vac/Details/5
        public ActionResult Details(int id)
        {
            return View(crud.getContact(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vacancy contact)
        {
            try
            {
                contact.DateOfPublication = DateTime.Now;
                contact.IdOfAuthor = 1;
                //contact.IdOfAuthor = Int32.Parse(User.Identity.GetUserId());
                int i = crud.addContact(contact);
                return RedirectToAction("Details", new { id = i });
            }
            catch
            {
                return View();
            }
        }

        // GET: Vac/Edit/5
        public ActionResult Edit(int id)
        {
            return View(crud.getContact(id));
        }

        // POST: Vac/Edit/5
        [HttpPost]
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

        public ActionResult Delete(int id)
        {
            return View(crud.getContact(id));
        }

        [HttpPost]
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
