using ProyectoFinalDoggo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            try
            {
                using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
                {
                    db.Usuarios.Add(modelo);
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
        }


        public void Modificar(Usuarios modelo)
        {
            try
            {
                using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
                {
                    db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }


            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
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
    public class IDExiste : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            using (g5_ProyectoFinalDoggoEntities2 db = new g5_ProyectoFinalDoggoEntities2())
            {

                string codigo = (string)value;
                if (db.Usuarios.Where(x =>x.usuario == codigo).Count() > 0)
                {

                    return new ValidationResult("El usuario ya existe");
        
        }
                return ValidationResult.Success;
            }

        }
    }

}