using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecuirementAgency.Models.Dao_Summ;

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
    }
}