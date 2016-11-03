using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaAjaxAspMvc.Models;

namespace PruebaAjaxAspMvc.Controllers
{
    public class EmpleadosController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Empleados
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult List()
        {
            return Json(db.Empleados.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Empleados emp)
        {
            return Json(db.Empleados.Add(emp), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            var emp = db.Empleados.Where(r => r.ID == id).SingleOrDefault();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Empleados emp)
        {
            return Json(db.Entry(emp).State = EntityState.Modified, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            return Json(db.Entry(db.Empleados.Where(r => r.ID == id).SingleOrDefault()).State = EntityState.Deleted, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
