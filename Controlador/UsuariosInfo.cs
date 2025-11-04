using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SistemaInventarioColchones.Controlador
{
    public class UsuariosInfo
    {
        public bool Insertar()
        {
            string connString = "Server=bed32989.mysql.database.azure.com;Database=sistema_comercial;Uid=parradosamuel35;Pwd=RTX2080TIxz$;SslMode=Required;";
            using (var con = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                con.Open();
                string insertSql = "INSERT INTO Usuario (Nombre, Contraseña, Rol) VALUES (@nombre, @clave, @rol)";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(insertSql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@clave", this.Contraseña);
                    cmd.Parameters.AddWithValue("@rol", this.Rol);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
        public string Fecha { get; set; }

        public List<UsuariosInfo> Usuarios()
        {
            List<UsuariosInfo> listData = new List<UsuariosInfo>();
            string connString = "Server=bed32989.mysql.database.azure.com;Database=sistema_comercial;Uid=parradosamuel35;Pwd=RTX2080TIxz$;SslMode=Required;";

            using (var con = new MySqlConnection(connString))
            {
                con.Open();
                string selectData = "SELECT * FROM Usuario";

                using (var cmd = new MySqlCommand(selectData, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsuariosInfo info = new UsuariosInfo();
                            info.Id = reader["Usuario_Id"].ToString();
                            info.Nombre = reader["Nombre"].ToString();
                            info.Contraseña = reader["Contraseña"].ToString();
                            info.Rol = reader["Rol"].ToString();
                            info.Fecha = reader["Fecha_Creacion"].ToString();

                            listData.Add(info);
                        }
                    }
                }
            }
            return listData;
        }
    }
}