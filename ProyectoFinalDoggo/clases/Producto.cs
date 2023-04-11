using ProyectoFinalDoggo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace ProyectoFinalDoggo.clases
{
    public class Producto
    {
        public IEnumerable<Productos> Consultar()
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                return db.Productos.ToList();
            }
        }
        public void Eliminar(Productos modelo)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;              
                db.SaveChanges();

            }

        }
        public void Guardar(Productos modelo)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                db.Productos.Add(modelo);
                db.SaveChanges();
            }

        }

        public void Modificar(Productos modelo)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

        }

        public Productos Consulta(int id)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                return db.Productos.FirstOrDefault(x => x.IDProd == id);
            }

        }
    }

}