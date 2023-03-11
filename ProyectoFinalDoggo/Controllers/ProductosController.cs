using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDoggo.Models;
using ProyectoFinalDoggo.clases;


namespace ProyectoFinalDoggo.Controllers
{
    public class ProductosController : Controller
    {
        Producto producto = new Producto();

        // GET: Productos
        public ActionResult Index()
        {
            
                IEnumerable<Productos> lst = producto.Consultar();

                return View(lst);
            
        }


        public ActionResult Eliminar(int id)
        {
            Productos modelo = new Productos()
            {
                IDProd = id
            };
            producto.Eliminar(modelo);
            ViewBag.valor = " El Productos fue eliminado ";
            IEnumerable<Productos> lst = producto.Consultar();

            return View("Index", lst);
        }

        public ActionResult Guardar(Productos modelo)
        {
            ViewBag.valor = " ";
            return View(modelo);
        }
        public ActionResult Nuevo(Productos modelo)
        {
            producto.Guardar(modelo);
            ViewBag.mensaje = "Se guardo Correctamente";
            return View("Guardar", modelo);
        }

        public ActionResult Modificar(int id)
        {
            Productos modelo = producto.Consulta(id);
            ViewBag.valor = " ";
            return View(modelo);

        }

        public ActionResult Cambiar(Productos modelo)
        {
            producto.Modificar(modelo);
            ViewBag.valor = " ";
            return View("Modificar", modelo);
        }

        public ActionResult Detalle(int id)
        {
            Productos modelo = producto.Consulta(id);
            return View(modelo);

        }

    }

}