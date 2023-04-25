using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProyectoFinalDoggo.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Contact()
        {
            return View("Contact");
        }

        public ActionResult Index()
        {
            return View("Index");
        }
    }
}