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
    using System;
    using System.Collections.Generic;
    
    public partial class compras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public compras()
        {
            this.carrito = new HashSet<carrito>();
        }
    
        public int IDTrans { get; set; }
        public int IDProd { get; set; }
        public string usuario { get; set; }
        public Nullable<decimal> COSTO { get; set; }
    
        public virtual Productos Productos { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<carrito> carrito { get; set; }
    }
}
