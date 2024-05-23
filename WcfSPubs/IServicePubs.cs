using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfSPubs.Fachada;

namespace WcfSPubs
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicePubs
    {

        [OperationContract]
        List<DetalleUsuario> ValidaUsuario(string Usuario, string Contrasena);

        [OperationContract]
        List<DetalleVistaAutores> ObtenerAutores();

        [OperationContract]
        string InsertarAutor(string IdAutor, string Nombre, string Apellido, string Telefono, string Direccion, string Ciudad, string Estado, string CodPostal, bool Contrato);
        [OperationContract]
        string ActualizaAutor(string IdAutor, string Nombre, string Apellido, string Telefono, string Direccion, string Ciudad, string Estado, string CodPostal, bool Contrato);
    }
}
