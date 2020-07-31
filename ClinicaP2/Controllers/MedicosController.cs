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
    public class MedicosController : Controller
    {
        private BDCLINICAEntities db = new BDCLINICAEntities();

        // GET: Medicos
        public ActionResult Index()
        {
            // var medico = db.Medico.Include(m => m.Especialidad).Include(m => m.MODULO);

            var medico = from tra in db.Trabajador where tra.EspCodigo != 1 select tra;

            return View(medico.ToList());
        }

        // GET: Medicos/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Medico medico = db.Medico.Find(id);
        //    if (medico == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(medico);
        //}

        // GET: Medicos/Create
        public ActionResult Create()
        {
            ViewBag.EspCodigo = new SelectList(db.Especialidad, "EspCodigo", "EspEspecialidad");
           /// ViewBag.Codmod = new SelectList(db.TipoTrabajador, "TipCodigo", "TipTipo");
            return View();
        }

        // POST: Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create( Trabajador tra)
        {
            db.InsertTrabajador(tra.Persona.PerNombre, tra.Persona.PerApellido,tra.Persona.PerDni,tra.Persona.PerRuc,tra.Persona.PerTelefono,tra.Persona.PerCorreo,tra.Persona.PerGenero,tra.EspCodigo,tra.TraHorasTrabajo,tra.TraUsuario,tra.TraContrasena);

            return RedirectToAction("index");
        }

        // GET: Medicos/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Medico medico = db.Medico.Find(id);
        //    if (medico == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CodEspe = new SelectList(db.Especialidad, "CodEspe", "NombEspe", medico.CodEspe);

        //    ViewBag.Codmod = new SelectList(db.MODULO, "Codmod", "name", medico.Codmod);
        //    return View(medico);
        //}

        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Codmed,CodEspe,NomTra,ApeTra,Genero,DniTra,CorreoTra,EstaTra,Codmod")] Medico medico)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(medico).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CodEspe = new SelectList(db.Especialidad, "CodEspe", "NombEspe", medico.CodEspe);
        //    ViewBag.Codmod = new SelectList(db.MODULO, "Codmod", "name", medico.Codmod);
        //    return View(medico);
        //}

        // GET: Medicos/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Medico medico = db.Medico.Find(id);
        //    if (medico == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(medico);
        //}

        //// POST: Medicos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Medico medico = db.Medico.Find(id);
        //    db.Medico.Remove(medico);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
