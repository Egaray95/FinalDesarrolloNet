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
    public class PacientesController : Controller
    {
        private BDCLINICAEntities db = new BDCLINICAEntities();

    
        public ActionResult Index()
        {
            return View(db.Paciente.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Paciente paciente)
        {
            try
            {

            db.insertPaciente(paciente.Persona.PerNombre,
                paciente.Persona.PerApellido,
                paciente.Persona.PerDni, 
                paciente.Persona.PerRuc,
                paciente.Persona.PerTelefono,
                paciente.Persona.PerCorreo,
                paciente.Persona.PerGenero,
                paciente.PacFechaNacimiento);
                  
   

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return HttpNotFound();
            }

        }

       
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodPac,NomPac,ApePac,TelePac,DniPac,Genero,EstaPac")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }
    }
}
