using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDoggo.Controllers;

namespace ProyectoFinalDoggo.Filtros
{
    public class VerificarProductos : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller is ProductosController == false)
            {

                filterContext.HttpContext.Response.Redirect("~/Productos/Index");
            }
        }

    }
}