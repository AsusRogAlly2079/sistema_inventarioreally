using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SistemaInventarioColchones.Controlador
{
    public class ProveedoresInfo // ← OBLIGATORIO: public
    {
        public bool Insertar()
        {
            string connString = "Server=bed32989.mysql.database.azure.com;Database=sistema_comercial;Uid=parradosamuel35;Pwd=RTX2080TIxz$;SslMode=Required;";
            using (var con = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                con.Open();
                string insertSql = "INSERT INTO Proveedor (Nombre, NIT, Telefono, Direccion) VALUES (@nombre, @nit, @telefono, @direccion)";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(insertSql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@nit", this.Nit);
                    cmd.Parameters.AddWithValue("@telefono", this.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", this.Direccion);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        public string id { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public List<ProveedoresInfo> Proveedores()
        {
            List<ProveedoresInfo> listData = new List<ProveedoresInfo>();
            string connString = "Server=bed32989.mysql.database.azure.com;Database=sistema_comercial;Uid=parradosamuel35;Pwd=RTX2080TIxz$;SslMode=Required;";

            using (var con = new MySqlConnection(connString))
            {
                con.Open();
                string selectData = "SELECT * FROM Proveedor";

                using (var cmd = new MySqlCommand(selectData, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProveedoresInfo info = new ProveedoresInfo();
                            info.id = reader["Proveedor_Id"].ToString();
                            info.Nombre = reader["Nombre"].ToString();
                            info.Nit = reader["NIT"].ToString();
                            info.Telefono = reader["Telefono"].ToString();
                            info.Direccion = reader["Direccion"].ToString();

                            listData.Add(info);
                        }
                    }
                }
            }
            return listData;
        }
    }
}