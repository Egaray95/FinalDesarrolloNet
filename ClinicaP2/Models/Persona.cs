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
    
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            this.Paciente = new HashSet<Paciente>();
            this.Trabajador = new HashSet<Trabajador>();
        }
    
        public int PerCodigo { get; set; }
        public string PerNombre { get; set; }
        public string PerApellido { get; set; }
        public string PerDni { get; set; }
        public string PerRuc { get; set; }
        public string PerTelefono { get; set; }
        public string PerCorreo { get; set; }
        public bool PerGenero { get; set; }
        public Nullable<int> PerEstado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente> Paciente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trabajador> Trabajador { get; set; }
    }
}
