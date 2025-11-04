using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SistemaInventarioColchones.Controlador
{
    public class ProductosInfo   // ← OBLIGATORIO: public
    {
        public bool Insertar()
        {
            string connString = "Server=bed32989.mysql.database.azure.com;Database=sistema_comercial;Uid=parradosamuel35;Pwd=RTX2080TIxz$;SslMode=Required;";
            using (var con = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                con.Open();
                string sql = @"INSERT INTO Producto 
            (Nombre, Descripcion, Marca_Id, Tamaño, Material_Id, Stock, Costo, Proveedor_Id) 
            VALUES (@nombre, @desc, @marca, @tamano, @material, @stock, @costo, @proveedor)";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", this.Nombre);
                    cmd.Parameters.AddWithValue("@desc", this.Descripcion);
                    cmd.Parameters.AddWithValue("@marca", this.Marca);        // asume que tienes el ID (int)
                    cmd.Parameters.AddWithValue("@tamano", this.Tamaño);
                    cmd.Parameters.AddWithValue("@material", this.Material);  // asume que tienes el ID (int)
                    cmd.Parameters.AddWithValue("@stock", this.Stock);
                    cmd.Parameters.AddWithValue("@costo", this.Costo);
                    cmd.Parameters.AddWithValue("@proveedor", this.Proveedor);// asume que tienes el ID (int)
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
        public string id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Tamaño { get; set; }
        public string Material { get; set; }
        public string Stock { get; set; }
        public string Costo { get; set; }
        public string Proveedor { get; set; }

        public List<ProductosInfo> Productos()
        {

            List<ProductosInfo> listData = new List<ProductosInfo>();
            string connString = "Server=bed32989.mysql.database.azure.com;Database=sistema_comercial;Uid=parradosamuel35;Pwd=RTX2080TIxz$;SslMode=Required;";

            using (var con = new MySqlConnection(connString))
            {
                con.Open();
                string selectData = "SELECT * FROM Producto";

                using (var cmd = new MySqlCommand(selectData, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductosInfo info = new ProductosInfo();
                            info.id = reader["Producto_Id"].ToString();
                            info.Nombre = reader["Nombre"].ToString();
                            info.Descripcion = reader["Descripcion"].ToString();
                            info.Marca = reader["Marca_Id"].ToString();
                            info.Tamaño = reader["Tamaño"].ToString();
                            info.Material = reader["Material_Id"].ToString();
                            info.Stock = reader["Stock"].ToString();
                            info.Costo = reader["Costo"].ToString();
                            info.Proveedor = reader["Proveedor_Id"].ToString();

                            listData.Add(info);
                        }
                    }
                }
            }
            return listData;
        }
    }
}