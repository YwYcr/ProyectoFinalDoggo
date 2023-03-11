using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDoggo.Models;
using ProyectoFinalDoggo.clases;

namespace ProyectoFinalDoggo.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        Usuario usuario = new Usuario();

        // GET: Usuarios
        public ActionResult Index()
        {

            IEnumerable<Usuarios> lst = usuario.Consultar();

            return View(lst);

        }


        public ActionResult Eliminar(string id)
        {
            Usuarios modelo = new Usuarios()
            {
                usuario = id
            };
            usuario.Eliminar(modelo);
            ViewBag.valor = " El Usuarios fue eliminado ";
            IEnumerable<Usuarios> lst = usuario.Consultar();

            return View("Index", lst);
        }

        public ActionResult Guardar(Usuarios modelo)
        {
            ViewBag.valor = " ";
            return View(modelo);
        }
        public ActionResult Nuevo(Usuarios modelo)
        {
            usuario.Guardar(modelo);
            ViewBag.mensaje = "Se guardo Correctamente";
            return View("Guardar", modelo);
        }

        public ActionResult Modificar(string id)
        {
            Usuarios modelo = usuario.Consulta(id);
            ViewBag.valor = " ";
            return View(modelo);

        }

        public ActionResult Cambiar(Usuarios modelo)
        {
            usuario.Modificar(modelo);
            ViewBag.valor = " ";
            return View("Modificar", modelo);
        }

        public ActionResult Detalle(string id)
        {
            Usuarios modelo = usuario.Consulta(id);
            return View(modelo);

        }
    }
}