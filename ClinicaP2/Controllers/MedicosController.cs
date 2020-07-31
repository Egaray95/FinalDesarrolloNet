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

            var medico = from tra in db.Trabajador where tra.EspCodigo != 1 select tra;

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

    }
}
