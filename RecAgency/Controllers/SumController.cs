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
                Log.For(this).Info("User " + User.Identity.GetUserId() + " arrived to list of summaries");
                return View(crud.getContactsByStatus(4));
            }
            else
            {
                Log.For(this).Info("User " + User.Identity.GetUserId() + " opened himself summary");
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
            contact.Status = 1;
            crud.addContact(contact);
            Log.For(this).Info("User " + User.Identity.GetUserId() + " created draft of summary");
            return RedirectToAction("Details", new { id = User.Identity.GetUserId() });
        }

        public ActionResult SendForAdmin(int id)
        {
            Summary contact = crud.getContact(id);
            contact.Status = 2;
            crud.updateContact(contact);
            Log.For(this).Info("User " + User.Identity.GetUserId() + " sent draft for admin");
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
            contact.Status = 1;
            crud.updateContact(contact);
            Log.For(this).Info("User " + User.Identity.GetUserId() + " editted his summary");
            return RedirectToAction("Details", new { id = User.Identity.GetUserId() });
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
                Log.For(this).Info("User " + User.Identity.GetUserId() + " deleted his summary");
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
