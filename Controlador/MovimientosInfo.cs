using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioColchones.Controlador
{
    public class MovimientosInfo
    {
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public int ProveedorId { get; set; }
        public string Especificacion { get; set; }
        public string Venta { get; set; }            // "venta" o "compra"
        public int UsuarioId { get; set; }

        public bool Insertar()
        {
            string connString = "Server=bed32989.mysql.database.azure.com;Database=sistema_comercial;Uid=parradosamuel35;Pwd=RTX2080TIxz$;SslMode=Required;";
            using (var con = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                con.Open();
                string sql = @"INSERT INTO Movimientos
                (Producto_Id, Cliente_Id, Proveedor_Id, Especificacion, Venta, Usuario_Id)
                VALUES (@producto, @cliente, @proveedor, @especificacion, @venta, @usuario)";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@producto", ProductoId);
                    cmd.Parameters.AddWithValue("@cliente", ClienteId);
                    cmd.Parameters.AddWithValue("@proveedor", ProveedorId);
                    cmd.Parameters.AddWithValue("@especificacion", Especificacion);
                    cmd.Parameters.AddWithValue("@venta", Venta);
                    cmd.Parameters.AddWithValue("@usuario", UsuarioId);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }
    }
}
