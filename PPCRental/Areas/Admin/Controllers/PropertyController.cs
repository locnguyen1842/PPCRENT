using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
using System.IO;

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
            ReadList();            

            return View(product);
        }
        public void ReadList()
        {
            ViewBag.ptype = model.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.ward = model.WARDs.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.district = model.DISTRICTs.OrderByDescending(x => x.ID).Where(y => y.ID >= 31 && y.ID <= 54).ToList();
            ViewBag.street = model.STREETs.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.status = model.PROJECT_STATUS.OrderByDescending(x => x.ID).ToList();

        }
        [HttpPost]
        public ActionResult Edit( PROPERTY p)
        {
            //img
            ReadList();
            var en = model.PROPERTies.Find(p.ID);
            string filename;
            string extension;
            string s;
            
            if (p.AvatarUpload != null)
            {
                filename = Path.GetFileNameWithoutExtension(p.AvatarUpload.FileName);
                extension = Path.GetExtension(p.AvatarUpload.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                p.Avatar = filename;
                s = p.Avatar;
                filename = Path.Combine(Server.MapPath("~/Images"), filename);
                p.AvatarUpload.SaveAs(filename);
                    
            }
            else
            {
                s = en.Avatar;
                
            }
                

                en.PROPERTY_TYPE = p.PROPERTY_TYPE;
                en.PropertyName = p.PropertyName;
                en.Avatar = s;
                en.Images = p.Images;
                en.PropertyType_ID = p.PropertyType_ID;
                en.Content = p.Content;
                en.Street_ID = p.Street_ID;
                en.Ward_ID = p.Ward_ID;
                en.District_ID = p.District_ID;
                en.Price = p.Price;
                en.UnitPrice = p.UnitPrice;
                en.Area = p.Area;
                en.BedRoom = p.BedRoom;
                en.BathRoom = p.BathRoom;
                en.PackingPlace = p.PackingPlace;
                en.Updated_at = DateTime.Now;
                model.SaveChanges();
            
            
            return RedirectToAction("ViewListofAgencyProject");
        }
        public ActionResult Delete(int? id)
        {
            
            PROPERTY property = model.PROPERTies.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: /Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROPERTY property = model.PROPERTies.Find(id);
            model.PROPERTies.Remove(property);
            model.SaveChanges();
            return RedirectToAction("ViewListofAgencyProject");
        }

        public JsonResult GetStreet(int District_id)
        {
            return Json(
            model.STREETs.Where(s => s.District_ID == District_id )
            .Select(s => new { id = s.ID, text = s.StreetName }).ToList(),
            JsonRequestBehavior.AllowGet);
        }
    }
}