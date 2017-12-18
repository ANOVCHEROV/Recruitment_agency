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
            return View(crud.getContact(id));
        }

        public ActionResult Submit(int id)
        {
            Summary contact = crud.getContact(id);
            contact.Status = 4;
            crud.updateContact(contact);
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
            try
            {
                crud.updateContact(contact);
                return RedirectToAction("SumList");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home", new { error = ex.Message });
            }
        }
    }
}