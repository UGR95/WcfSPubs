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

        public List<DetalleUsuario> ValidaUsuario(string Usuario, string Contrasena, bool ValidaAdmin)
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
                    command.Parameters.AddWithValue("@count", ValidaAdmin);
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
            string Query = "SELECT * FROM vwAutores with(nolock)";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Conexion))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                    using (IDataReader dr = sqlCommand.ExecuteReader())
                    {
                        List<DetalleVistaAutores> lista = new List<DetalleVistaAutores>();
                        DetalleVistaAutores vistaAutores;
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

                            lista.Add(vistaAutores);
                        }

                        return lista;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            //string conectionString;
            //string Query = "SELECT * FROM vwAutores with(nolock)";

            //conectionString = Conexion;

            //using (SqlConnection connection = new SqlConnection(conectionString))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand(Query, connection);
            //    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            //    DataTable dataTable = new DataTable();

            //    try
            //    {
            //        dataAdapter.Fill(dataTable);

            //        connection.Close();
            //        return dataTable;
            //    }
            //    catch (Exception ex)
            //    {
            //        connection.Close();
            //        return null;
            //    }
            //}
        }

    }
}