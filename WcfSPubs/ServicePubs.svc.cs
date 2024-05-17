using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfSPubs.Fachada;
using WcfSPubs.Datos;
using System.Data;

namespace WcfSPubs
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IServicePubs
    {
        public List<DetalleUsuario> ValidaUsuario (string Usuario, string Contrasena, bool ValidaAdmin)
        {
            DatosPubs datos = new DatosPubs();

            return datos.ValidaUsuario(Usuario, Contrasena, ValidaAdmin);
        }

        public List<DetalleVistaAutores> VistaAutores()
        {
            DatosPubs datos = new DatosPubs();
            return datos.VistaAutores();
        }
    }
}
