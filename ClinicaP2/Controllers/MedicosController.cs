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


        public ActionResult Index()
        {

            var medico = from tra in db.Trabajador where tra.TraEstado == 1 select tra;

            return View(medico.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.EspCodigo = new SelectList(db.Especialidad, "EspCodigo", "EspEspecialidad");

            return View();
        } 
        
        public ActionResult login()
        {
            return View();
        }

        public ActionResult EspeDoc()
        {

            var especialidad = from esp in db.Especialidad where esp.EspEstado == 1 select esp;

            return View(especialidad.ToList());
        }
        public ActionResult MedicoForespec(int id, string esp)
        {
            ViewBag.esp = esp;
            var list = from c in db.Trabajador
                       where c.EspCodigo == id
                       select c;
            return View(list.ToList());

        }

        [HttpPost]
        public ActionResult Create( Trabajador tra)
        {
            db.InsertTrabajador(
                tra.Persona.PerNombre,
                tra.Persona.PerApellido,
                tra.Persona.PerDni,
                tra.Persona.PerRuc,
                tra.Persona.PerTelefono,
                tra.Persona.PerCorreo,
                tra.Persona.PerGenero,
                tra.EspCodigo,
                tra.TraHorasTrabajo,
                tra.TraUsuario,
                tra.TraContrasena
                );

            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult login(string TraUsuario, string clave)
        {
            int cod = 0;
            var codigo = from tr in db.Trabajador where tr.TraUsuario == TraUsuario
                         select new
                         {
                             codigo = tr.TraCodigo
                         };
            foreach (var item in codigo)
            {
                cod = item.codigo;
            }


            Trabajador tra = db.Trabajador.Find(cod);
            if (tra == null)
            {
                ViewBag.error = "Usuario no existe";
            }
            else
            {
                if (tra.TraContrasena.Trim() == clave.Trim())
                {
                    Session["trabajador"] = tra;
                    return Redirect(Url.Content("~/Home/Index"));
                }
                else
                {
                    ViewBag.error = "Contraseña incorrecta";
                }
            }
            return View();
        }



    }
}
