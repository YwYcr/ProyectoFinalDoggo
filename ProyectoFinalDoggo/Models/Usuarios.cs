//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinalDoggo.Models
{
    using ProyectoFinalDoggo.clases;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using ProyectoFinalDoggo.Models;
    using System.Linq;
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.compras = new HashSet<compras>();
        }

        [Required(ErrorMessage = "Dato requerido")]
        
        public string usuario { get; set; }
        [Required(ErrorMessage = "Dato requerido1")]
        public string pass { get; set; }
        
        public string correo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string rol { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string LoginErrorMessage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compras> compras { get; set; }



    }
}
