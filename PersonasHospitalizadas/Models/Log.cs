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
    
    public partial class Log
    {
        public int idLog { get; set; }
        public Nullable<int> idHospital { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string IP { get; set; }
        public Nullable<int> Resultados { get; set; }
    }
}