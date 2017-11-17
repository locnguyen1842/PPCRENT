using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;

namespace PPCRental.Controllers
{
    public class ProjectController : Controller
    {
        private PPCRentalEntities2 db = new PPCRentalEntities2();

        // GET: /Project/
        public ActionResult Index()
        {
            List<object> myModel = new List<object>();
            myModel.Add(db.PROPERTies.ToList());
            myModel.Add(db.DISTRICTs.ToList());
            myModel.Add(db.PROPERTY_TYPE.ToList());
            //var properties = db.PROPERTies.Include(p => p.DISTRICT).Include(p => p.PROJECT_STATUS).Include(p => p.PROPERTY_TYPE).Include(p => p.STREET).Include(p => p.USER).Include(p => p.USER1).Include(p => p.WARD);
            return View(myModel);
        }

        // GET: /Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROPERTY property = db.PROPERTies.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: /Project/Create
        public ActionResult Create()
        {
            ViewBag.District_ID = new SelectList(db.DISTRICTs, "ID", "DistrictName");
            ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name");
            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType");
            ViewBag.Street_ID = new SelectList(db.STREETs, "ID", "StreetName");
            ViewBag.UserID = new SelectList(db.USERs, "ID", "Email");
            ViewBag.Sale_ID = new SelectList(db.USERs, "ID", "Email");
            ViewBag.Ward_ID = new SelectList(db.WARDs, "ID", "WardName");
            return View();
        }

        // POST: /Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,PropertyName,Avatar,Images,PropertyType_ID,Content,Street_ID,Ward_ID,District_ID,Price,UnitPrice,Area,BedRoom,BathRoom,PackingPlace,UserID,Created_at,Create_post,Status_ID,Note,Updated_at,Sale_ID")] PROPERTY property)
        {
            if (ModelState.IsValid)
            {
                db.PROPERTies.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.District_ID = new SelectList(db.DISTRICTs, "ID", "DistrictName", property.District_ID);
            ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name", property.Status_ID);
            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType", property.PropertyType_ID);
            ViewBag.Street_ID = new SelectList(db.STREETs, "ID", "StreetName", property.Street_ID);
            ViewBag.UserID = new SelectList(db.USERs, "ID", "Email", property.UserID);
            ViewBag.Sale_ID = new SelectList(db.USERs, "ID", "Email", property.Sale_ID);
            ViewBag.Ward_ID = new SelectList(db.WARDs, "ID", "WardName", property.Ward_ID);
            return View(property);
        }

        // GET: /Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROPERTY property = db.PROPERTies.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.District_ID = new SelectList(db.DISTRICTs, "ID", "DistrictName", property.District_ID);
            ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name", property.Status_ID);
            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType", property.PropertyType_ID);
            ViewBag.Street_ID = new SelectList(db.STREETs, "ID", "StreetName", property.Street_ID);
            ViewBag.UserID = new SelectList(db.USERs, "ID", "Email", property.UserID);
            ViewBag.Sale_ID = new SelectList(db.USERs, "ID", "Email", property.Sale_ID);
            ViewBag.Ward_ID = new SelectList(db.WARDs, "ID", "WardName", property.Ward_ID);
            return View(property);
        }

        // POST: /Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PropertyName,Avatar,Images,PropertyType_ID,Content,Street_ID,Ward_ID,District_ID,Price,UnitPrice,Area,BedRoom,BathRoom,PackingPlace,UserID,Created_at,Create_post,Status_ID,Note,Updated_at,Sale_ID")] PROPERTY property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.District_ID = new SelectList(db.DISTRICTs, "ID", "DistrictName", property.District_ID);
            ViewBag.Status_ID = new SelectList(db.PROJECT_STATUS, "ID", "Status_Name", property.Status_ID);
            ViewBag.PropertyType_ID = new SelectList(db.PROPERTY_TYPE, "ID", "CodeType", property.PropertyType_ID);
            ViewBag.Street_ID = new SelectList(db.STREETs, "ID", "StreetName", property.Street_ID);
            ViewBag.UserID = new SelectList(db.USERs, "ID", "Email", property.UserID);
            ViewBag.Sale_ID = new SelectList(db.USERs, "ID", "Email", property.Sale_ID);
            ViewBag.Ward_ID = new SelectList(db.WARDs, "ID", "WardName", property.Ward_ID);
            return View(property);
        }

        // GET: /Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROPERTY property = db.PROPERTies.Find(id);
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
            PROPERTY property = db.PROPERTies.Find(id);
            db.PROPERTies.Remove(property);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Filter(int? area,int? type,int? min, int? max)
        {
            var project = db.PROPERTies.ToList();
            if (area != 99){
                project = project.Where(p => p.District_ID == area).ToList();
                
            }
            if (type != 99)
            {
                project = project.Where(p => p.PropertyType_ID == type).ToList();
            }
            if (!String.IsNullOrEmpty(min.ToString()))
            {
                min = 0;
                project = project.Where(p => p.Price >= min).ToList();
            }
            if (max.ToString() == "")
            {
                max = 0;
                project = project.Where(p => p.Price >= min).ToList();
            }
            return View(project);

        }

        
    }
}
