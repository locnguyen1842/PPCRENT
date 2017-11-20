using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Areas.Admin.Controllers
{
    public class PropertyController : Controller
    {
        //
        // GET: /Admin/Property/
        PPCRentalEntities2 model = new PPCRentalEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewListofAgencyProject()
        {
            var product = model.PROPERTies.OrderByDescending(x => x.ID).ToList();
            return View(product);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(int id, PROPERTY p)
        {
            var product = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            product.PROPERTY_TYPE = p.PROPERTY_TYPE;
            product.PropertyName = p.PropertyName;
            product.Avatar = p.Avatar;
            product.Images = p.Images;
            product.PropertyType_ID = p.PropertyType_ID;
            product.Content = p.Content;
            product.Street_ID = p.Street_ID;
            product.Ward_ID = p.Ward_ID;
            product.District_ID = p.District_ID;
            product.Price = p.Price;
            product.UnitPrice = p.UnitPrice;
            product.Area = p.Area;
            product.BedRoom = p.BedRoom;
            product.BathRoom = p.BathRoom;
            product.PackingPlace = p.PackingPlace;
            product.Updated_at = DateTime.Now;
            return RedirectToAction("Index");
        }
	}
}