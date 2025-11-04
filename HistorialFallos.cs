using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace SistemaInventarioColchones
{
    public partial class HistorialFallos : Form
    {
        MySqlConnection con = new MySqlConnection("Server=bed32989.mysql.database.azure.com;Database=sistema_comercial;Uid=parradosamuel35;Pwd=RTX2080TIxz$;SslMode=Required;");

        public HistorialFallos()
        {
            InitializeComponent();
        }

        private void HistorialFallos_Load(object sender, EventArgs e)
        {
            CargarHistorialFallidos();
        }

        private void CargarHistorialFallidos()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string sql = "SELECT UsuarioIntentado AS 'Usuario', FechaHora AS 'Fecha y Hora', Mensaje FROM HistorialLoginFallido ORDER BY FechaHora DESC";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                dgvHistorialFallos.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void dgvHistorialFallos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
