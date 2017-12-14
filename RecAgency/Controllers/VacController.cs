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
        public ActionResult List()
        {
            return View(crud.getAllContacts());
        }

        // GET: Vac/Details/5
        public ActionResult Details(int id)
        {
            return View(crud.getContact(id));
        }
        [Authorize(Roles = "Aspirant")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Aspirant")]
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
        [Authorize(Roles = "Aspirant")]
        public ActionResult Edit(int id)
        {
            var contact = crud.getContact(id);
            if (contact.IdOfAuthor == User.Identity.GetUserId())
            {
                return View(contact);
            }
            return RedirectToAction("Error");
        }

        // POST: Vac/Edit/5
        [HttpPost]
        [Authorize(Roles = "Aspirant")]
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
        [Authorize(Roles = "Aspirant")]
        public ActionResult Delete(int id)
        {
            return View(crud.getContact(id));
        }

        [HttpPost]
        [Authorize(Roles = "Aspirant")]
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
