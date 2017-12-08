using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecuirementAgency.Models.Dao_Summ;
using Microsoft.AspNet.Identity;

namespace RecuirementAgency.Controllers
{
    public class AspirantController : Controller
    {
        CRUD_Summ summ = new CRUD_Summ();
        // GET: Aspirant
        public ActionResult Summaries()
        {
            return View(summ.GetAllSumm());
        }
        public ActionResult Details_Summ(int id)
        {
            return View(summ.Get_Summ(id));
        }
        public ActionResult Edit_Summ(int id, string action)
        {
            VO_Summ item = summ.Get_Summ(id);
            switch (action)
            {
                case "addProfession":
                    item.professions.Add("9");
                    break;

            }
            return View(item);
        }
        public ActionResult Create_Summary()
        {
            VO_Summ item = new VO_Summ();
            return View(item);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create_Summary([Bind(Exclude = "ID")] VO_Summ item)
        {
            item.idOfAuthor = Convert.ToInt32(User.Identity.GetUserId());

            try
            {
                if (summ.Create_Summ(item))
                    return RedirectToAction("Summaries");
                else
                    return View("Create_Summary");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return View(item);
            }
        }
    }
}