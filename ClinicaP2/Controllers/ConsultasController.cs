using ClinicaP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaP2.Controllers
{
    public class ConsultasController : Controller
    {

        private BDCLINICAEntities db = new BDCLINICAEntities();

        // GET: Consultas
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ListConsultaMedico()
        {
            var trabaja = (Trabajador)Session["Trabajador"];
            int id = trabaja.TraCodigo;

            var consultas = from con in db.Consulta where con.CodTrabajador == id select con;

            return View(consultas.ToList());
        }


        public ActionResult DetailsConsulta(int id)
        {
            //var detalleconsulta = from con in db.Consulta where con.ConsCodigo == id select con;
            Consulta detalleconsulta = db.Consulta.Find(id);

            return View(detalleconsulta);
        }
    }
}