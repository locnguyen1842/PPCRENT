using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class HomeController : Controller
    {
        PPCRentalEntities2 db = new PPCRentalEntities2();
        public ActionResult Index()
        {
            List<object> myModel = new List<object>();
            myModel.Add(db.PROPERTies.ToList());
            ViewBag.District_ID = new SelectList(db.DISTRICTs.Where(y => y.ID >= 31 && y.ID <= 54), "ID", "DistrictName");

            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType");

            ViewBag.Feature_ID = new SelectList(db.FEATUREs, "ID", "FeatureName");
            return View(myModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}