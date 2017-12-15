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
        public ActionResult Details(string id)
        {
            var r = crud.getContactOnUser(id);
            if (r != null)
            {
                return View(r);
            }
            else
            {
                return RedirectToAction("Create");
            }
            
        }

        public ActionResult Create()
        {
                return View();
        }

        [HttpPost]
        public ActionResult Create(Summary contact)
        {
                contact.DatePublication = DateTime.Now;
                contact.IdOfAuthor = User.Identity.GetUserId();
                crud.addContact(contact);            
                return RedirectToAction("Details", new { id = User.Identity.GetUserId() });
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
            contact.DatePublication = DateTime.Now;
            contact.IdOfAuthor = User.Identity.GetUserId();
            if (crud.updateContact(contact))
            {
                return RedirectToAction("Details", new { id = User.Identity.GetUserId() });
            }
            else
            {
                return RedirectToAction("Error", "Home", new { error = contact.IdOfAuthor});
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
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
