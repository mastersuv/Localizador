//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonasHospitalizadas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InfoPersonaHospital
    {
        public int idPersona { get; set; }
        public Nullable<int> idHospital { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Edad { get; set; }
        public string HoraCorte { get; set; }
        public string FechaCorte { get; set; }
        public string NombreHospital { get; set; }
    }
}
