using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_PERMISO
    {

        public List<Permiso> listar(int idUsuario)
        {
            List<Permiso> list = new List<Permiso>();

            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.IdRol, p.NombreMenu from PERMISO p")
                        .AppendLine("inner join ROL  r on u.IdRol = r.IdRol")
                        .AppendLine("inner join USUARIO  u on u.IdRol = r.IdRol")
                        .AppendLine("where u.IdUsuario = @idusuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), connection);
                    cmd.Parameters.AddWithValue("@idusuario", idUsuario);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Permiso()
                            {

                                oRol = new Rol() { IdRol = Convert.ToInt32(reader["IdRol"]) },
                                NombreMenu = reader["NombreMenu"].ToString()


                            });

                        }
                    }


                }

                catch (Exception ex)
                {
                    list = new List<Permiso>();
                }
            }
            return list;

        }

    }

}