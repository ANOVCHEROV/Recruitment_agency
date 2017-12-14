using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecAgency.Models;
using Microsoft.AspNet.Identity;

namespace RecAgency.Controllers
{
    public class SumController : Controller
    {
        CRUD_Summary crud = new CRUD_Summary();
        public ActionResult List(string id = "")
        {
            if (id == "")
            {
                return View(crud.getAllContacts());
            }
            else
            {
                return View(crud.getContactOnUser(id));
            }
        }
        public ActionResult Details(int id)
        {
            return View(crud.getContact(id));
        }
   
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Summary contact)
        {
            try
            {
                contact.DatePublication = DateTime.Now;
                contact.IdOfAuthor = User.Identity.GetUserId();
                int i = crud.addContact(contact);
                
                return RedirectToAction("Details", new { id = i });
            }
            catch
            {
                return View();
            }
        }

        // GET: Sum/Edit/5
        public ActionResult Edit(int id)
        {
            return View(crud.getContact(id));
        }

        // POST: Sum/Edit/5
        [HttpPost]
        public ActionResult Edit(Summary contact)
        {
            try
            {
                contact.DatePublication = DateTime.Now;
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
            return View();
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
