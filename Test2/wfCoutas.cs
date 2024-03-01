using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Test2
{
    public partial class wfCoutas : Form
    {
        public wfCoutas()
        {
            InitializeComponent();
            ConsultarAcces();

        }

        private void wfCoutas_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 Panel = new Form1();
            Panel.Show();
            this.Close();
        }

        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSocios.Visible = false;

        }


        private string ObtenerValorSeleccionado()
        {
            string valorSeleccionado = "";
            // Verificar si hay elementos seleccionados en el ListBox
            if (lbSocios.SelectedItem != null)
            {
                // Obtener el valor seleccionado del ListBox
                valorSeleccionado = lbSocios.SelectedItem.ToString();
                // Aquí puedes usar el valor seleccionado según sea necesario
                // MessageBox.Show("El valor seleccionado es: " + valorSeleccionado);
            }
            return valorSeleccionado;
        }




        private OleDbConnection conexion;

        private void ActualizarResultados(string Nombre)
        {
            // Verificar si la cadena de búsqueda no está vacía
            if (!string.IsNullOrEmpty(Nombre))
            {
                // Construir la consulta SQL para buscar por nombre y apellidos
                string consultaSQL = "SELECT IDsocio, Nombre, ApellidoP, ApellidoM FROM tbSocio WHERE Nombre LIKE @Nombre OR ApellidoP LIKE @Nombre OR ApellidoM LIKE @Nombre";

                // Crear una nueva instancia de OleDbConnection si no existe
                if (conexion == null)
                {
                    // Establecer la cadena de conexión
                    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Roca\Documents\BaseDatos_Socios.accdb;";
                    conexion = new OleDbConnection(connectionString);
                }

                try
                {
                    conexion.Open();
                    OleDbCommand comando = new OleDbCommand(consultaSQL, conexion);
                    comando.Parameters.AddWithValue("@Nombre", "%" + Nombre + "%");

                    OleDbDataReader lector = comando.ExecuteReader();

                    // Limpiar las sugerencias anteriores
                    lbSocios.Items.Clear();

                    // Agregar las sugerencias actuales al ListBox
                    while (lector.Read())
                    {
                        // Construir la cadena que contiene el nombre completo (nombre y apellidos)
                        string nombreCompleto = $"{lector["Nombre"]} {lector["ApellidoP"]} {lector["ApellidoM"]}";
                        lbSocios.Items.Add(nombreCompleto);
                        txtDNI.Text = $"{lector["IDsocio"]}";
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Error al buscar en la base de datos: " + ex.Message);
                }
                finally
                {
                    if (conexion != null && conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
        }



        private void lbSocios_SelectedValueChanged(object sender, EventArgs e)
        {
            txtNombre.Text = ObtenerValorSeleccionado();
            lbSocios.Visible = false;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            // string textoBusqueda = Form1.ValirTexto(txtNombre.Text.Trim(); // Obtener el texto de búsqueda y eliminar espacios en blanco

            txtNombre.Text = wfSocios.ValidarTexto(txtNombre, txtNombre.Text, true);


            // Aquí realizarías la lógica de búsqueda según el texto ingresado
            // Por ejemplo, podrías filtrar una lista de elementos, realizar una consulta a una base de datos, etc.

            // Actualizar los resultados en función de la búsqueda
            ActualizarResultados(txtNombre.Text);
            lbSocios.Visible = true;


            // Establecer el tamaño del ListBox
            lbSocios.Size = new Size(lbSocios.Width, lbSocios.ItemHeight * lbSocios.Items.Count);


        }

        public static string ValidarDecimal(TextBox textBox, string texto)
        {
            string textoValido = string.Empty;
            int indice = 0;
            bool puntoIngresado = false;

            foreach (char character in texto)
            {
                if (char.IsDigit(character))
                {
                    // Verifica si el carácter es un dígito
                    textoValido += character;
                    indice++;
                }
                else if (character == '.' && !puntoIngresado)
                {
                    // Verifica si el carácter es un punto y si no se ha ingresado antes
                    textoValido += character;
                    indice++;
                    puntoIngresado = true;
                }
            }

            // Establece la posición de la selección en el TextBox
            textBox.SelectionStart = indice;

            return textoValido;
        }


        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            txtMonto.Text = ValidarDecimal(txtMonto, txtMonto.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.Text = wfSocios.ValidarTexto(txtDescripcion, txtDescripcion.Text, true);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtMonto.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) || (cbxEstado.TabIndex == 0))
            {
                MessageBox.Show("Uno o más campos están vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String IDSocio = txtDNI.Text;
                Double Monto = Double.Parse(txtMonto.Text);
                String Descripcion = txtDescripcion.Text;
                String Estado = cbxEstado.SelectedItem.ToString().ToUpper();
                DateTime Fecha_Nacimiento = DateTime.Now;
                string fechaLarga = Fecha_Nacimiento.ToShortDateString();

                GuardarAcces(IDSocio, fechaLarga, Monto, Descripcion, Estado);
                ConsultarAcces();
                Limpiar();
            }


        }
        private void ConsultarAcces()
        //IDSocio ApellidoP   ApellidoM Nombre  Direccion Telefono    Fecha_Nacimiento

        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Roca\Documents\BaseDatos_Socios.accdb;";
            string query = "SELECT * FROM tbCouta"; // Reemplaza NombreDeTuTabla por el nombre de la tabla que deseas leer

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dgvCoutas.DataSource = dataTable; // Asigna el DataTable al control DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            // Agregar columnas de botones al DataGridView
            DataGridViewButtonColumn editarButtonColumn = new DataGridViewButtonColumn();
            editarButtonColumn.Name = "Editar";
            editarButtonColumn.HeaderText = "Editar";
            editarButtonColumn.Text = "Editar";
            editarButtonColumn.UseColumnTextForButtonValue = true;
            dgvCoutas.Columns.Add(editarButtonColumn);

            DataGridViewButtonColumn eliminarButtonColumn = new DataGridViewButtonColumn();
            eliminarButtonColumn.Name = "Eliminar";
            eliminarButtonColumn.HeaderText = "Eliminar";
            eliminarButtonColumn.Text = "Eliminar";
            eliminarButtonColumn.UseColumnTextForButtonValue = true;
            dgvCoutas.Columns.Add(eliminarButtonColumn);

            // Manejar el evento CellContentClick del DataGridView
            dgvCoutas.CellContentClick += dgvCoutas_CellContentClick;
        }

        private void dgvCoutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si el clic fue en la columna de editar
            if (e.ColumnIndex == dgvCoutas.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                // Aquí puedes realizar la lógica para editar la fila seleccionada
                MessageBox.Show("Editar fila " + e.RowIndex);
            }
            // Verificar si el clic fue en la columna de eliminar
            else if (e.ColumnIndex == dgvCoutas.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Aquí puedes realizar la lógica para eliminar la fila seleccionada
                MessageBox.Show("Eliminar fila " + e.RowIndex);
            }
        }

        private void Limpiar()
        {
            txtDNI.Text = "";
            txtMonto.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Text = "";
            cbxEstado.SelectedIndex = 0;
        }

        private void GuardarAcces(String ID, String F, Double M, String Des, String Estado)
        {

            string query = "INSERT INTO tbCouta (IdSocio,Fecha_Pago,Monto,Descripcion,Estado) VALUES (?,?,?,?,?)";

            using (OleDbCommand command = new OleDbCommand(query, conexion))
            {
                command.Parameters.AddWithValue("?", $"{ID}"); // Reemplaza "ID" por el valor del ID que quieras insertar
                command.Parameters.AddWithValue("?", $"{F}"); // Reemplaza "ValorNombre" por el valor del nombre que quieras insertar
                command.Parameters.AddWithValue("?", M); // Reemplaza "ValorApellido" por el valor del apellido que quieras insertar
                command.Parameters.AddWithValue("?", $"{Des}");
                command.Parameters.AddWithValue("?", $"{Estado}");
                try
                {
                    conexion.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show($"Se insertaron {rowsAffected} filas.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Console.WriteLine("Error al insertar datos: " + ex.Message);
                }
            }
        }
    }

    
}
