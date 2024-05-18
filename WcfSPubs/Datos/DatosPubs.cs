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


                string CadenaConexion;
                bool EsAdmin = false;
                int UsuarioValido;
                CadenaConexion = Conexion;

                using (SqlConnection connection = new SqlConnection(CadenaConexion))
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
    }
}