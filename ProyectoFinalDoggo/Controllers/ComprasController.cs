using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDoggo.Models;
using ProyectoFinalDoggo.clases;

namespace ProyectoFinalDoggo.Controllers
{
    public class ComprasController : Controller
    {
        Compra compra = new Compra();
        // GET: Compras
        public ActionResult Index()
        {

            IEnumerable<compras> lst = compra.Consultar();

            return View(lst);

        }


        public ActionResult Eliminar(int id)
        {
            compras modelo = new compras()
            {
                IDTrans = id
            };
            compra.Eliminar(modelo);
            ViewBag.valor = " La Compra fue eliminada ";
            IEnumerable<compras> lst = compra.Consultar();

            return View("Index", lst);
        }

        public ActionResult Guardar(compras modelo)
        {
            ViewBag.valor = " ";
            return View(modelo);
        }
        public ActionResult Nuevo(compras modelo)
        {
            compra.Guardar(modelo);
            ViewBag.mensaje = "Se guardo Correctamente";
            return View("Guardar", modelo);
        }

        public ActionResult Modificar(int id)
        {
            compras modelo = compra.Consulta(id);
            ViewBag.valor = " ";
            return View(modelo);

        }

        public ActionResult Cambiar(compras modelo)
        {
            compra.Modificar(modelo);
            ViewBag.valor = " ";
            return View("Modificar", modelo);
        }

        public ActionResult Detalle(int id)
        {
            compras modelo = compra.Consulta(id);
            return View(modelo);

        }
    }
}