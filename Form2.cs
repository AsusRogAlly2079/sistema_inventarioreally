using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;




namespace SistemaInventarioColchones
{
    public partial class Form2 : Form
    {
       
        string nombreContenedor ="backups";
        BlobServiceClient blobServiceClient;
        BlobContainerClient containerClient;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         // blobServiceClient = new BlobServiceClient(cadenaConexion);
            containerClient = blobServiceClient.GetBlobContainerClient(nombreContenedor);
            CargarListaBackups();
        }

        // Método para cargar archivos al DataGridView
        private async void CargarListaBackups()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("Nombre", "Nombre");
            dataGridView2.Columns.Add("Tamanio", "Tamaño (bytes)");
            dataGridView2.Columns.Add("Fecha", "Fecha");

            await foreach (BlobItem blob in containerClient.GetBlobsAsync())
            {
                dataGridView2.Rows.Add(
                    blob.Name,
                    blob.Properties.ContentLength ?? 0,
                    blob.Properties.LastModified?.LocalDateTime.ToString() ?? ""
                );
            }
        }

        // Botón SUBIR
        private async void btnSubir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos SQL (*.sql)|*.sql|Todos los archivos (*.*)|*.*";
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                string archivoLocal = dialogo.FileName;
                string fecha = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string nombreRemoto = $"Backup_{fecha}_{Path.GetFileName(archivoLocal)}";
                var blobClient = containerClient.GetBlobClient(nombreRemoto);

                using (var fileStream = System.IO.File.OpenRead(archivoLocal))
                {
                    await blobClient.UploadAsync(fileStream);
                }
                MessageBox.Show($"Backup {nombreRemoto} subido correctamente.");
                CargarListaBackups();
            }
        }

        // Botón DESCARGAR
        private async void btnDescargar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                string nombre = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = nombre;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var blobClient = containerClient.GetBlobClient(nombre);
                    await blobClient.DownloadToAsync(saveDialog.FileName);
                    MessageBox.Show("Backup descargado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un backup para descargar.");
            }
        }

        // Botón ELIMINAR
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                string nombre = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                var confirm = MessageBox.Show($"¿Eliminar el archivo {nombre}?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var blobClient = containerClient.GetBlobClient(nombre);
                    await blobClient.DeleteIfExistsAsync();
                    MessageBox.Show("Backup eliminado.");
                    CargarListaBackups();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un backup para eliminar.");
            }
        }

        // Botón REFRESCAR
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarListaBackups();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Selección de archivo en la tabla
            if (dataGridView2.SelectedRows.Count > 0)
            {
                string nombreArchivo = dataGridView2.SelectedRows[0].Cells["Nombre"].Value.ToString();

                // 2. Ruta local donde guardas los dumps (.sql)
                string rutaCarpeta = @"C:\Users\TU_USUARIO\Documents\dumps"; // <- Cambia TU_USUARIO por tu usuario real de Windows
                string rutaDump = Path.Combine(rutaCarpeta, nombreArchivo);

                // 3. Configuración MySQL
                string usuario = "TU_USUARIO_MYSQL";
                string password = "TU_PASSWORD_MYSQL";
                string bd = "TU_BASEDEDATOS";
                string servidor = "localhost"; // o el host correspondiente
                string mysqlExe = @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe"; // Cambia si es otro path

                // 4. Ejecutar el dump usando cmd
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                psi.Arguments = $"/c \"{mysqlExe} -h {servidor} -u {usuario} -p{password} {bd} < \\\"{rutaDump}\\\"\"";
                psi.UseShellExecute = true;
                psi.CreateNoWindow = true;

                try
                {
                    Process.Start(psi);
                    MessageBox.Show("Base de datos restablecida con el dump seleccionado.", "Éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al restablecer el dump:\n" + ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un archivo de backup en la tabla antes de restablecer");
            }
        }
    }
}