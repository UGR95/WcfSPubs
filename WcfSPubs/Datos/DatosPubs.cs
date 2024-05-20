using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WcfSPubs.Fachada;

namespace WcfSPubs.Datos
{

    public class DatosPubs
    {
        string Conexion = ConfigurationManager.ConnectionStrings["ConexionPubs"].ConnectionString;

        public List<DetalleUsuario> ValidaUsuario(string Usuario, string Contrasena)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("spr_ValidaUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Ususario", Usuario);
                    command.Parameters.AddWithValue("@Pass", Contrasena);

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        List<DetalleUsuario> lista = new List<DetalleUsuario>();
                        DetalleUsuario detalle;
                        while (dr.Read())
                        {
                            detalle = new DetalleUsuario();
                            detalle.NombreUsuario = dr["NombreUsuario"].ToString();
                            detalle.EsAdmin = Convert.ToBoolean(dr["EsAdministrador"]);

                            lista.Add(detalle);
                        }

                        return lista;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DetalleVistaAutores> VistaAutores()
        {
            List<DetalleVistaAutores> ListaAutor = new List<DetalleVistaAutores>();
            DetalleVistaAutores vistaAutores;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM vwAutores with(nolock)", con);

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            vistaAutores = new DetalleVistaAutores();
                            vistaAutores.IdAutor = dr[0].ToString();
                            vistaAutores.Apellido = dr[1].ToString();
                            vistaAutores.Nombre = dr[2].ToString();
                            vistaAutores.Telefono = dr[3].ToString();
                            vistaAutores.Direccion = dr[4].ToString();
                            vistaAutores.Ciudad = dr[5].ToString();
                            vistaAutores.Estado = dr[6].ToString();
                            vistaAutores.CodigoPostal = dr[7].ToString();
                            vistaAutores.Contrato = Convert.ToBoolean(dr[8].ToString());

                            ListaAutor.Add(vistaAutores);
                        }
                    }
                    return ListaAutor;
                }
            }
            catch (Exception ex)
            {
                List<DetalleVistaAutores> listaAutor = new List<DetalleVistaAutores>();
                vistaAutores = new DetalleVistaAutores();

                vistaAutores.MensajeError = ex.ToString();
                listaAutor.Add(vistaAutores);

                return listaAutor;
            }
        }
    }
}