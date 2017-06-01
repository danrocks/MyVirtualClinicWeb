using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVirtualClinicWeb.Controllers
{
    [AllowAnonymous]
        public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "MyVirtualClinic provides a way for patients, General Practitioners,  Consultants, and other healthcare specialists to securely pass information between each other. Utilising the technology in everyone's pocket it allows patients and GP's to supply the facts, figures and pictures that consultants need to make informed decisions. Consultants and other specialists can also return further information, such as life-style guidance, preventative measures or early intervention approaches.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact details for MyVirtualClinic.";

            return View();
        }
    }
}