﻿using System;
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
        public List<DetalleUsuario> ValidaUsuario (string Usuario, string Contrasena)
        {
            DatosPubs datos = new DatosPubs();

            return datos.ValidaUsuario(Usuario, Contrasena);
        }

        public List<DetalleVistaAutores> ObtenerAutores()
        {
            DatosPubs datos = new DatosPubs();
            return datos.VistaAutores();
        }

        public string InsertarAutor (string IdAutor, string Nombre, string Apellido, string Telefono, string Direccion, string Ciudad, string Estado, string CodPostal, bool Contrato)
        {
            DatosPubs datos = new DatosPubs();
            return datos.InsertarAutor(IdAutor, Nombre, Apellido, Telefono, Direccion, Ciudad, Estado, CodPostal, Contrato);
        }

        public string ActualizaAutor(string IdAutor, string Nombre, string Apellido, string Telefono, string Direccion, string Ciudad, string Estado, string CodPostal, bool Contrato)
        {
            DatosPubs datos = new DatosPubs();
           return datos.AuctualizarAutor(IdAutor, Nombre, Apellido, Telefono, Direccion, Ciudad, Estado, CodPostal, Contrato);
        }

        public List<DetalleTitulos> ObtenerTitluos()
        {
            DatosPubsTitulo pubsTitulo = new DatosPubsTitulo();
            return pubsTitulo.ObtenerTitulos();
        }
    }

}
