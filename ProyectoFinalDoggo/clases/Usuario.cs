using ProyectoFinalDoggo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalDoggo.clases
{
    public class Usuario
    {
        public IEnumerable<Usuarios> Consultar()
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                return db.Usuarios.ToList();
            }
        }
        public void Eliminar(Usuarios modelo)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

            }

        }
        public void Guardar(Usuarios modelo)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                db.Usuarios.Add(modelo);
                db.SaveChanges();
            }

        }

        public void Modificar(Usuarios modelo)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

        }

        public Usuarios Consulta(string id)
        {
            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {
                return db.Usuarios.FirstOrDefault(x => x.usuario == id);
            }

        }
    }
}