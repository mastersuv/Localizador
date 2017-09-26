using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PersonasHospitalizadas.Models;

namespace PersonasHospitalizadas.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        PersonasHospitalizadasEntities dbdata = new PersonasHospitalizadasEntities();

        private List<Hospital> ObtenerHospitales() {
            return dbdata.Hospital.OrderBy(x => x.Nombre).ToList();
        }

        [HttpGet]
        public ActionResult Index(string Nombre, string idHospital) {
            ViewBag.ListaHospitales = ObtenerHospitales();

            if (Nombre != null && idHospital != null) {
                // [!] -- Si la URL viene con parametros
                // Consultar base de datos, esto con la finalidad de permitir compartirse la URL de una búsqueda especifica

                int _idHospital = Int32.Parse(idHospital);  // Se usa en las consultas
                List<InfoPersonaHospital> ListaInfoPersonaHospital = new List<InfoPersonaHospital>();

                if (_idHospital == 0) {
                    // Búsqueda General
                    // idHospital 0 = Todos los hospitales
                    ListaInfoPersonaHospital = dbdata.InfoPersonaHospital.Where(x => x.Nombre.Contains(Nombre)).ToList();
                } else {
                    // Búsqueda por Hospital
                    // Si el Nombre viene vacio (""), SQL Server devolvera todos los registros al consultarse Nombre.Contains("")
                    ListaInfoPersonaHospital = dbdata.InfoPersonaHospital.Where(x => x.Nombre.Contains(Nombre) && x.idHospital == _idHospital).ToList();
                }

                // Agregamos al Log
                try {
                    string IP = (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
                    Log nl = new Log();
                    nl.idHospital = _idHospital;
                    nl.Nombre = Nombre;
                    nl.Fecha = DateTime.Now;
                    nl.IP = IP;
                    nl.Resultados = ListaInfoPersonaHospital.Count;

                    dbdata.Log.Add(nl);
                    dbdata.SaveChanges();
                } catch (Exception ex) { }

                // Pasamos los datos y resultados al ViewBag
                ViewBag.ListaInfoPersonaHospital = ListaInfoPersonaHospital;
                ViewBag.Nombre = Nombre;
                ViewBag.idHospital = idHospital;
            }

            return View();
        }
	}
}