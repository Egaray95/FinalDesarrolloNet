using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaP2.Models;
using ClinicaP2.Models.ViewModel;

namespace ClinicaP2.Controllers
{
    public class RESERVACIONsController : Controller
    {
        private bdclinicEntities db = new bdclinicEntities();
        private List<SelectListItem> listaespecialidad;

        // GET: RESERVACIONs
        public ActionResult Index()
        {

            var rESERVACION = db.RESERVACION.Include(r => r.ESTADO).Include(r => r.Medico).Include(r => r.Paciente).Include(r => r.PAYMET).Include(r => r.USUARIOS);
            return View(rESERVACION.ToList());
        }



        // GET: RESERVACIONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVACION rESERVACION = db.RESERVACION.Find(id);
            if (rESERVACION == null)
            {
                return HttpNotFound();
            }
            return View(rESERVACION);
        }

        // GET: RESERVACIONs/Create
        /*VISTA PARCIAL*/
        public ActionResult _SearchPartial()
        {
            List<Especialidad> listaepe = db.Especialidad.ToList();
            ViewBag.listaepe = new SelectList(listaepe, "CodEspe", "NombEspe");

            return PartialView();
        }
        public ActionResult Create()
        {
            ViewBag.Codestado = new SelectList(db.ESTADO, "Codestado", "Name");
            ViewBag.Codmed = new SelectList(db.Medico, "Codmed", "NomTra");
            ViewBag.CodPac = new SelectList(db.Paciente, "CodPac", "NomPac");
            ViewBag.CodPay = new SelectList(db.PAYMET, "CodPay", "Name");
            ViewBag.CodUser = new SelectList(db.USUARIOS, "CodUser", "Usuario");
            return View();
        }
        /* CREAMOS UNA ACCION QUE DEVUELVE UNA ESTRUCTURA JSON EN FUNCION A ESPECIALIDAD*/
        public JsonResult GetMedicos(string CodEspe)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Medico> smedico = db.Medico.Where(x => x.CodEspe == CodEspe).ToList();
            return Json(smedico, JsonRequestBehavior.AllowGet);


        }



        // POST: RESERVACIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RESERVACION rESERVACION)
        {
            if (ModelState.IsValid)
            {
                //db.RESERVACION.Add(rESERVACION);
                //db.SaveChanges();
                db.SP_ADIRSERVAS(rESERVACION.Fecha, rESERVACION.CodPac, rESERVACION.Codmed, rESERVACION.precio, rESERVACION.CodPay, rESERVACION.Codestado, rESERVACION.CodUser);

                return RedirectToAction("Index");
            }

            ViewBag.Codestado = new SelectList(db.ESTADO, "Codestado", "Name", rESERVACION.Codestado);
            ViewBag.Codmed = new SelectList(db.Medico, "Codmed", "CodEspe", rESERVACION.Codmed);
            ViewBag.CodPac = new SelectList(db.Paciente, "CodPac", "NomPac", rESERVACION.CodPac);
            ViewBag.CodPay = new SelectList(db.PAYMET, "CodPay", "Name", rESERVACION.CodPay);
            ViewBag.CodUser = new SelectList(db.USUARIOS, "CodUser", "Usuario", rESERVACION.CodUser);
            return View(rESERVACION);
        }

        // GET: RESERVACIONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVACION rESERVACION = db.RESERVACION.Find(id);
            if (rESERVACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codestado = new SelectList(db.ESTADO, "Codestado", "Name", rESERVACION.Codestado);
            ViewBag.Codmed = new SelectList(db.Medico, "Codmed", "CodEspe", rESERVACION.Codmed);
            ViewBag.CodPac = new SelectList(db.Paciente, "CodPac", "NomPac", rESERVACION.CodPac);
            ViewBag.CodPay = new SelectList(db.PAYMET, "CodPay", "Name", rESERVACION.CodPay);
            ViewBag.CodUser = new SelectList(db.USUARIOS, "CodUser", "Usuario", rESERVACION.CodUser);
            return View(rESERVACION);
        }

        // POST: RESERVACIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodReserva,Fecha,CodPac,Codmed,precio,CodPay,Codestado,CodUser")] RESERVACION rESERVACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESERVACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codestado = new SelectList(db.ESTADO, "Codestado", "Name", rESERVACION.Codestado);
            ViewBag.Codmed = new SelectList(db.Medico, "Codmed", "CodEspe", rESERVACION.Codmed);
            ViewBag.CodPac = new SelectList(db.Paciente, "CodPac", "NomPac", rESERVACION.CodPac);
            ViewBag.CodPay = new SelectList(db.PAYMET, "CodPay", "Name", rESERVACION.CodPay);
            ViewBag.CodUser = new SelectList(db.USUARIOS, "CodUser", "Usuario", rESERVACION.CodUser);
            return View(rESERVACION);
        }

        // GET: RESERVACIONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVACION rESERVACION = db.RESERVACION.Find(id);
            if (rESERVACION == null)
            {
                return HttpNotFound();
            }
            return View(rESERVACION);
        }

        // POST: RESERVACIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RESERVACION rESERVACION = db.RESERVACION.Find(id);
            db.RESERVACION.Remove(rESERVACION);
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
    }
}
