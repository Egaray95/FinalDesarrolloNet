using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaP2.Models;

namespace ClinicaP2.Controllers
{
    public class EspecialidadsController : Controller
    {
        private BDCLINICAEntities db = new BDCLINICAEntities();

        // GET: Especialidads
        public ActionResult Index()
        {
            return View(db.Especialidad.ToList());
        }

        public ActionResult LisEspecialidadtoDoctor()
        {

            var especialidad = from esp in db.Especialidad where esp.EspEstado == 1 select esp;

            return View(especialidad.ToList());
        }

   

 
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
               
                db.InsertEspecialidad(especialidad.EspEspecialidad, especialidad.EspPrecio);
                return RedirectToAction("Index");
            }

            return View(especialidad);
        }

       
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidad.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        public ActionResult ListMedicosporesp(int id)
        {
            
            var lis = from f in db.Trabajador where f.EspCodigo == id select f;

            return View(lis.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Especialidad especialidad)
        {
            return View(especialidad);
        }

    }
}
