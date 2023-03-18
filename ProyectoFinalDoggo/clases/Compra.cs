using ProyectoFinalDoggo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalDoggo.clases
{
    public class Compra
    {
        public IEnumerable<compras> Consultar()
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                return db.compras.ToList();
            }
        }
        public void Eliminar(compras modelo)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

            }

        }
        public void Guardar(compras modelo)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                db.compras.Add(modelo);
                db.SaveChanges();
            }

        }

        public void Modificar(compras modelo)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

        }

        public compras Consulta(int id)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                return db.compras.FirstOrDefault(x => x.IDTrans == id);
            }

        }
    }
}