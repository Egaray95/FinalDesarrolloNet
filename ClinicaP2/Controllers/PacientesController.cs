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

        public ActionResult CreatePac()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePac(Consulta consulta,int idtrabajador)
        {
            try
            {
                var pacientess = from pac in db.Paciente where pac.Persona.PerDni == consulta.Paciente.Persona.PerDni select pac;
                int codigopaciente = 0;
                foreach (var item in pacientess)
                {
                    codigopaciente = item.PacCodigo;
                }


                if (codigopaciente==0)
                {

                    int codigonuevopac = 0;
                    db.insertPaciente(consulta.Paciente.Persona.PerNombre,
                       consulta.Paciente.Persona.PerApellido,
                       consulta.Paciente.Persona.PerDni,
                       consulta.Paciente.Persona.PerRuc,
                       consulta.Paciente.Persona.PerTelefono,
                       consulta.Paciente.Persona.PerCorreo,
                       consulta.Paciente.Persona.PerGenero,
                       consulta.Paciente.PacFechaNacimiento);


                    var query = from u in db.Paciente
                                join ur in db.Persona on u.PerCodigo equals ur.PerCodigo
                                where ur.PerDni ==consulta.Paciente.Persona.PerDni

                                select new
                                {
                                    codigonuevo = u.PacCodigo
                                };

                    foreach (var item in query)
                    {
                        codigonuevopac = item.codigonuevo;
                    }




                    db.InsertConsulta(codigonuevopac, idtrabajador, consulta.ConsFecha);
                    TempData["msg"] = "<script>alert('Consulta registrada Satisfactoriamente');</script>";
                    return RedirectToAction("LisEspecialidadtoDoctor", "Especialidads");
                }
                else
                {

                    db.InsertConsulta(codigopaciente, idtrabajador, consulta.ConsFecha);
                    TempData["msg"] = "<script>alert('Consulta registrada Satisfactoriamente');</script>";
                    return RedirectToAction("LisEspecialidadtoDoctor","Especialidads");
                }
            }
            catch (Exception)
            {

                return HttpNotFound();
            }
        }

        public ActionResult Historial(int id, string name)
        {
            ViewBag.name = name;
            var list = from a in db.HistClinico
                       where a.Consulta.CodPaciente == id
                       select a;
            return View(list.ToList());
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
