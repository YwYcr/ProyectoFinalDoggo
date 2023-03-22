using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDoggo.Models;

namespace ProyectoFinalDoggo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(ProyectoFinalDoggo.Models.Usuarios userModel)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                var userDetails = db.Usuarios.Where(x => x.usuario == userModel.usuario && x.pass == userModel.pass).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Contraseña o Usuario incorrectos";
                    return View("Index", userModel);
                }
                else
                {
                    Session["Usuario"] = userDetails.usuario;
                    return RedirectToAction("Index", "Productos");
                }
            }
        }
        public ActionResult Logout()
        {
            using (var db = new g5_ProyectoFinalDoggoEntities2())
            {
                if (Session != null && Session["usuario"] != null)
                {
                    // Get the current user from the database
                    var currentUser = db.Usuarios.FirstOrDefault(u => u.usuario == Session["usuario"].ToString());

                    // Clear the session
                    Session.Clear();

                    // Save changes to the database
                    db.SaveChanges();
                }

                // Redirect to the login page
                return RedirectToAction("Index", "Login");
            }
        }
    }
}