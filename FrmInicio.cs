using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Xml;
using System.IO;

namespace ExportacionDB
{
    public partial class FrmInicio : Form
    {
        private string dbPath = string.Empty;
        private SQLiteConnection connection;
        private DataTable currentData;

        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos SQLite (*.db;*.sqlite;*.sqlite3)|*.db;*.sqlite;*.sqlite3|Todos los archivos (*.*)|*.*";
                openFileDialog.Title = "Seleccionar Base de Datos SQLite";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        dbPath = openFileDialog.FileName;

                        // Cerrar conexión previa si existe
                        if (connection != null && connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                            connection.Dispose();
                        }

                        // Crear nueva conexión
                        connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
                        connection.Open();

                        // Cargar las tablas disponibles
                        LoadTables();

                        cbTablas.Enabled = true;

                        // Mostrar nombre del archivo en el título
                        this.Text = $"Exportación de Datos - {Path.GetFileName(dbPath)}";

                        MessageBox.Show($"Base de datos cargada correctamente: {Path.GetFileName(dbPath)}",
                            "Base de datos cargada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al abrir la base de datos: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadTables()
        {
            // Limpiar combobox
            cbTablas.Items.Clear();

            // Consultar las tablas disponibles
            DataTable tables = connection.GetSchema("Tables");

            // Agregar las tablas al combobox
            foreach (DataRow row in tables.Rows)
            {
                string tableName = row["TABLE_NAME"].ToString();
                if (!tableName.StartsWith("sqlite_")) // Ignorar tablas del sistema
                {
                    cbTablas.Items.Add(tableName);
                }
            }

            if (cbTablas.Items.Count > 0)
            {
                cbTablas.SelectedIndex = 0;
            }
        }

        private void cbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTablas.SelectedItem != null)
            {
                LoadTableData(cbTablas.SelectedItem.ToString());
            }
        }

        private void LoadTableData(string tableName)
        {
            try
            {
                if (connection == null || connection.State != ConnectionState.Open)
                {
                    MessageBox.Show("No hay conexión a la base de datos.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = $"SELECT * FROM [{tableName}]";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                currentData = new DataTable();
                adapter.Fill(currentData);

                dtgDatos.DataSource = currentData;

                btnGuardarCSV.Enabled = true;
                btnGuardarTXT.Enabled = true;
                btnGuardarXML.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la tabla: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarCSV_Click(object sender, EventArgs e)
        {
            if (currentData == null || currentData.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExportToFile("csv");
        }

        private void btnGuardarTXT_Click_1(object sender, EventArgs e)
        {
            if (currentData == null || currentData.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExportToFile("txt");
        }

        private void btnGuardarXML_Click(object sender, EventArgs e)
        {
            if (currentData == null || currentData.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExportToFile("xml");
        }

        private void ExportToFile(string fileType)
        {
            if (cbTablas.SelectedItem == null) return;

            string tableName = cbTablas.SelectedItem.ToString();
            string defaultFileName = $"{tableName}.{fileType}";

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                switch (fileType.ToLower())
                {
                    case "csv":
                        saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                        break;
                    case "txt":
                        saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
                        break;
                    case "xml":
                        saveFileDialog.Filter = "Archivos XML (*.xml)|*.xml";
                        break;
                }

                saveFileDialog.FileName = defaultFileName;
                saveFileDialog.Title = $"Guardar como {fileType.ToUpper()}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string path = saveFileDialog.FileName;

                        switch (fileType.ToLower())
                        {
                            case "csv":
                                ExportToCSV(path);
                                break;
                            case "txt":
                                ExportToTXT(path);
                                break;
                            case "xml":
                                ExportToXML(path);
                                break;
                        }

                        MessageBox.Show($"Archivo {fileType.ToUpper()} generado correctamente en:\n{path}",
                            "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar los datos: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportToCSV(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                // Escribir cabeceras
                for (int i = 0; i < currentData.Columns.Count; i++)
                {
                    sw.Write(currentData.Columns[i].ColumnName);
                    if (i < currentData.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.WriteLine();

                foreach (DataRow row in currentData.Rows)
                {
                    for (int i = 0; i < currentData.Columns.Count; i++)
                    {
                        string value = row[i].ToString();
                        if (value.Contains(";") || value.Contains("\"") || value.Contains("\n"))
                        {
                            value = $"\"{value.Replace("\"", "\"\"")}\"";
                        }
                        sw.Write(value);
                        if (i < currentData.Columns.Count - 1)
                        {
                            sw.Write(";");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }

        private void ExportToTXT(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                int[] columnWidths = new int[currentData.Columns.Count];

                for (int i = 0; i < currentData.Columns.Count; i++)
                {
                    columnWidths[i] = currentData.Columns[i].ColumnName.Length;

                    foreach (DataRow row in currentData.Rows)
                    {
                        int length = row[i].ToString().Length;
                        if (length > columnWidths[i])
                        {
                            columnWidths[i] = length;
                        }
                    }
                }

                // Escribir cabeceras
                for (int i = 0; i < currentData.Columns.Count; i++)
                {
                    sw.Write(currentData.Columns[i].ColumnName.PadRight(columnWidths[i] + 2));
                }
                sw.WriteLine();

                for (int i = 0; i < currentData.Columns.Count; i++)
                {
                    sw.Write(new string('-', columnWidths[i]) + "  ");
                }
                sw.WriteLine();

                foreach (DataRow row in currentData.Rows)
                {
                    for (int i = 0; i < currentData.Columns.Count; i++)
                    {
                        sw.Write(row[i].ToString().PadRight(columnWidths[i] + 2));
                    }
                    sw.WriteLine();
                }
            }
        }

        private void ExportToXML(string path)
        {
            currentData.WriteXml(path, XmlWriteMode.WriteSchema);
        }

    }
}
