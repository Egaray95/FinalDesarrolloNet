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
    
    public partial class RESERVACION
    {
        public string CodReserva { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string CodPac { get; set; }
        public string Codmed { get; set; }
        public Nullable<double> precio { get; set; }
        public string CodPay { get; set; }
        public string Codestado { get; set; }
        public string CodUser { get; set; }
    
        public virtual ESTADO ESTADO { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual PAYMET PAYMET { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
    }
}
