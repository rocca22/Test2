using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Test2
{



    public partial class wfSocios : Form
    {
        public wfSocios()
        {
            InitializeComponent();
            ConsultarAcces();
            Limpiar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtDNI.Text) ||
    string.IsNullOrWhiteSpace(txtNombre.Text) ||
    string.IsNullOrWhiteSpace(txtApellidoP.Text) ||
    string.IsNullOrWhiteSpace(txtApellidoM.Text) ||
    string.IsNullOrEmpty(txtDireccion.Text) ||
    string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Uno o más campos están vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String IDSocio = txtDNI.Text;
                String Nombre = txtNombre.Text.ToUpper();
                String ApellidoP = txtApellidoP.Text.ToUpper();
                String ApellidoM = txtApellidoM.Text.ToUpper();
                String Direccion = txtDireccion.Text.ToUpper();
                String Telefono = txtTelefono.Text;
                DateTime Fecha_Nacimiento = dtpFechaNacimiento.Value;
                string fechaCorta = Fecha_Nacimiento.ToShortDateString();

                GuardarAcces(IDSocio, Nombre, ApellidoP, ApellidoM, Direccion, Telefono, fechaCorta);
                ConsultarAcces();
                Limpiar();
            }


        }
        //............................................... METODOS PROPIOS
        private void ConsultarAcces()
        //IDSocio ApellidoP   ApellidoM Nombre  Direccion Telefono    Fecha_Nacimiento

        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Roca\Documents\BaseDatos_Socios.accdb;";
            string query = "SELECT * FROM tbSocio"; // Reemplaza NombreDeTuTabla por el nombre de la tabla que deseas leer

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dgvListaSocios.DataSource = dataTable; // Asigna el DataTable al control DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }








            //..............................



        }

        private void GuardarAcces(String ID, String N, String Ap, String Am, String D, String T, String F)
        {



            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Roca\Documents\BaseDatos_Socios.accdb;";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                string query = "INSERT INTO tbSocio (IDSocio,Nombre,ApellidoP,ApellidoM,Direccion,Telefono,Fecha_Nacimiento) VALUES (?,?,?,?,?,?,?)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", $"{ID}"); // Reemplaza "ID" por el valor del ID que quieras insertar
                    command.Parameters.AddWithValue("?", $"{N}"); // Reemplaza "ValorNombre" por el valor del nombre que quieras insertar
                    command.Parameters.AddWithValue("?", $"{Ap}"); // Reemplaza "ValorApellido" por el valor del apellido que quieras insertar
                    command.Parameters.AddWithValue("?", $"{Am}");
                    command.Parameters.AddWithValue("?", $"{D}");
                    command.Parameters.AddWithValue("?", $"{T}");
                    command.Parameters.AddWithValue("?", F);

                    try
                    {
                        connection.Open();
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

        private void Limpiar()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }


        public string ValidarNumero(TextBox Controlador, string texto, int Max)
        {
            // Verificar si el texto contiene caracteres que no son dígitos
            // Si el texto excede la longitud máxima, truncarlo
            if (texto.Length > Max)
            {
                texto = texto.Substring(0, Max);
                Controlador.Text = texto;
                Controlador.SelectionStart = Max;
            }

            // Verificar si el texto contiene caracteres que no son dígitos
            string newText = string.Empty;
            foreach (char character in texto)
            {
                if (char.IsDigit(character))
                {
                    newText += character;
                }
            }
            return newText;
        }


        public static string ValidarTexto(TextBox textBox, string texto, bool espacio)
        {
            string textoSinNumeros = string.Empty;
            int indice = 0;

            foreach (char character in texto)
            {
                if (espacio)
                {
                    if (char.IsLetter(character) || char.IsWhiteSpace(character))
                    {
                        textoSinNumeros += character;
                        indice++;
                    }
                }
                else
                {
                    if (char.IsLetter(character))
                    {
                        textoSinNumeros += character;
                        indice++;

                    }
                }


            }

            textBox.SelectionStart = indice;
            return textoSinNumeros;
        }



        public static void MostrarLote(String L, String P, String M)
        { 
                MessageBox.Show($"{L}");
        }


        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            txtDNI.Text = ValidarNumero(txtDNI, txtDNI.Text, 7);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            txtTelefono.Text = ValidarNumero(txtTelefono, txtTelefono.Text, 9);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 Panel = new Form1();
            Panel.Show();
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
           txtNombre.Text = ValidarTexto(txtNombre, txtNombre.Text,false);
        }

        private void txtApellidoP_TextChanged(object sender, EventArgs e)
        {
            txtApellidoP.Text = ValidarTexto(txtApellidoP, txtApellidoP.Text, false);
        }

        private void txtApellidoM_TextChanged(object sender, EventArgs e)
        {
            txtApellidoM.Text = ValidarTexto(txtApellidoM, txtApellidoM.Text, false);
        }

        private void btnLote_Click(object sender, EventArgs e)
        {
            wfLote Lote = new wfLote();
            Lote.Show();
        }
    }



}
