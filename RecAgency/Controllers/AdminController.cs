using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecAgency.Models;

namespace RecAgency.Controllers
{
    public class AdminController : Controller
    {
        CRUD_Summary crud = new CRUD_Summary();
        // GET: Admin
        public ActionResult SumList()
        {
                return View(crud.getContactsByStatus(2));
        }

        public ActionResult Details(int id)
        {
            var n = crud.getContact(id);
            Log.For(this).Info("Admin checked summary: " + n.Id);
            return View(n);

        }

        public ActionResult Submit(int id)
        {
            Summary contact = crud.getContact(id);
            contact.Status = 4;
            crud.updateContact(contact);
            Log.For(this).Info("Admin submitted summary: " + contact.Id);
            return RedirectToAction("SumList", new { id = 1 });
        }


        public ActionResult Refuse(int id)
        {
            var sum = crud.getContact(id);
            return View(sum);
        }
        [HttpPost]
        public ActionResult Refuse(Summary contact)
        {
            contact.Status = 3;
            Log.For(this).Info("Admin refused summary: " + contact.Id + " with comment: " + contact.Comment);
            crud.updateContact(contact);
            return RedirectToAction("SumList");
        }
    }
}