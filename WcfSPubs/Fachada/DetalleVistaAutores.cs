using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfSPubs.Fachada
{
    public class DetalleVistaAutores
    {
        public string IdAutor { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public bool Contrato { get; set; }

        public string MensajeError { get; set; }
    }
}