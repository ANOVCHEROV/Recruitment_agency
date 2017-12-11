using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecAgency.Controllers
{
    public class VacController : Controller
    {
        // GET: Vac
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vac/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vac/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vac/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vac/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vac/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vac/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
