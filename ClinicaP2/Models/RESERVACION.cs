//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
