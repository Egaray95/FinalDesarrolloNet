//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicaP2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            this.RESERVACION = new HashSet<RESERVACION>();
        }
    
        public string CodPac { get; set; }
        public string NomPac { get; set; }
        public string ApePac { get; set; }
        public string TelePac { get; set; }
        public string DniPac { get; set; }
        public string Genero { get; set; }
        public string EstaPac { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVACION> RESERVACION { get; set; }
    }
}
