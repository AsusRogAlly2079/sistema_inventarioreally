using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SistemaInventarioColchones.Controlador
{
    public class ClientesInfo   // ← OBLIGATORIO: public
    {
        public bool Insertar()
        {
            string connString = "Server=bed32989.mysql.database.azure.com;Database=sistema_comercial;Uid=parradosamuel35;Pwd=RTX2080TIxz$;SslMode=Required;";
            using (var con = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                con.Open();
                string insertSql = @"INSERT INTO Cliente
            (Nombre, Apellidos, Documento, Direccion, Telefono, Email)
            VALUES (@nombre, @apellidos, @documento, @direccion, @telefono, @email)";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(insertSql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@apellidos", this.Apellidos);
                    cmd.Parameters.AddWithValue("@documento", this.Documento);
                    cmd.Parameters.AddWithValue("@direccion", this.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", this.Telefono);
                    cmd.Parameters.AddWithValue("@email", this.Email);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public List<ClientesInfo> Clientes()
        {
            List<ClientesInfo> listData = new List<ClientesInfo>();
            string connString = "Server=bed32989.mysql.database.azure.com;Database=sistema_comercial;Uid=parradosamuel35;Pwd=RTX2080TIxz$;SslMode=Required;";

            using (var con = new MySqlConnection(connString))
            {
                con.Open();
                string selectData = "SELECT * FROM Cliente";
                using (var cmd = new MySqlCommand(selectData, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientesInfo info = new ClientesInfo();
                            info.Nombre = reader["Nombre"].ToString();
                            info.Apellidos = reader["Apellidos"].ToString();
                            info.Documento = reader["Documento"].ToString();
                            info.Direccion = reader["Direccion"].ToString();
                            info.Telefono = reader["Telefono"].ToString();
                            info.Email = reader["Email"].ToString();
                            listData.Add(info);
                        }
                    }
                }
            }
            return listData;
        }
    }
}