﻿using System;
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

        // GET: Especialidads/Details/5
        public ActionResult Details(string id)
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

        // GET: Especialidads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especialidads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                //db.Especialidad.Add(especialidad);
                //db.SaveChanges();
                db.InsertEspecialidad(especialidad.EspEspecialidad, especialidad.EspPrecio);
                return RedirectToAction("Index");
            }

            return View(especialidad);
        }

        // GET: Especialidads/Edit/5
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




        // POST: Especialidads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Especialidad especialidad)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(especialidad).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View(especialidad);
        }

        // GET: Especialidads/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Especialidad especialidad = db.Especialidad.Find(id);
        //    if (especialidad == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(especialidad);
        //}

        // POST: Especialidads/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Especialidad especialidad = db.Especialidad.Find(id);
        //    db.Especialidad.Remove(especialidad);
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
