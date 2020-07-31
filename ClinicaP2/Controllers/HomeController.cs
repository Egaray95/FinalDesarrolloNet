using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaP2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page. mensaje para commit probando cumpa desde maquina de edy";

            var hola = "hola a todos";            
            var v = "edy tu papi";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult login(string usurname, string contrasena)
        {


            if (usurname == null)
            {
                ViewBag.Message = "dato nulo";

            }

            return View();

        }

        public ActionResult logout()
        {

            Session["trabajador"] = null;
            return RedirectToAction("index");
        }
    }
}