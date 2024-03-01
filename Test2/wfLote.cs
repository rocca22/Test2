using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public partial class wfLote : Form
    {
        public wfLote()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardaLote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumLote.Text) || string.IsNullOrWhiteSpace(txtNumParcela.Text) || string.IsNullOrWhiteSpace(txtManazana.Text) )
            {
                MessageBox.Show("Uno o más campos están vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String Numlote = txtNumLote.Text.ToUpper();
                String NumParcela = txtNumParcela.Text.ToUpper();
                String Manzana = txtManazana.Text.ToUpper();
                wfSocios.MostrarLote(Numlote, NumParcela, Manzana);
                this.Close();
            }
        }
    }
}
