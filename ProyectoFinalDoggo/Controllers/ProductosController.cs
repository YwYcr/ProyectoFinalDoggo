using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalDoggo.Filtros;
using ProyectoFinalDoggo.Models;
using System.Drawing;
using System.IO;
using ProyectoFinalDoggo.clases;

namespace ProyectoFinalDoggo.Controllers
{
    [VerificarProductos]
    public class ProductosController : Controller
    {
        public IEnumerable<Productos> cart = new List<Productos>();
        private g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2();

        // GET: Productos
        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }



        public ActionResult modificarCantidad(int id, int cantidad)
        {
            List<Productos> listaCart = Session["cart"] as List<Productos>;
            if (listaCart != null)
            {         
                Productos producto = listaCart.FirstOrDefault(p => p.IDProd == id);
                if (producto != null)
                {                  
                    producto.cantidad = cantidad;                  
                    Session["cart"] = listaCart;
                    return RedirectToAction("Carrito");
                }
            }
            return RedirectToAction("Carrito");
        }


        public ActionResult AddToCart(int id)
        {

            Productos prod = db.Productos.Find(id);
            prod.cantidad = 1;
            List<Productos> listaCart = Session["cart"] as List<Productos>;

            if (listaCart == null)
            {
                listaCart = new List<Productos>();
            }

            listaCart.Add(prod);

            Session["cart"] = listaCart;
            return RedirectToAction("Index", "Productos");
        }

        public ActionResult deleteItemCarrito(int id)
        {
            {
                List<Productos> listaCart = Session["cart"] as List<Productos>;

                // Buscar el producto en la lista del carrito por su ID
                Productos prod = listaCart.FirstOrDefault(p => p.IDProd == id);

                if (prod != null)
                {
                    // Si se encuentra el producto, eliminarlo de la lista
                    listaCart.Remove(prod);

                    // Actualizar la sesión con la lista de productos modificada
                    Session["cart"] = listaCart;
                }

                // Redirigir a la acción "Carrito" para mostrar el carrito actualizado
                return RedirectToAction("Carrito");
            }
        }

        public ActionResult confirmarCompra()
        {
            List<Productos> listaCart = Session["cart"] as List<Productos>;
            if (listaCart != null)
            {
                // Si el carrito existe, limpiarlo
                listaCart.Clear();
            }

            return RedirectToAction("Carrito");
        }

        public ActionResult limpiarCarrito()
        {
            List<Productos> listaCart = Session["cart"] as List<Productos>;
            if (listaCart != null)
            {
                // Si el carrito existe, limpiarlo
                listaCart.Clear();
            }

            return RedirectToAction("Carrito");
        }


        public ActionResult Carrito()
        {
            List<Productos> listaCart = Session["cart"] as List<Productos>;       
            
            return View(listaCart);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProd,nomProducto,precio,Categoria,detalles,cantidad,imagen")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProd,nomProducto,precio,Categoria,detalles,cantidad,imagen")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
