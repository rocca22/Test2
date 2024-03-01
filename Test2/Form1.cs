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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            wfSocios PanelSocios = new wfSocios();
            PanelSocios.Show();
            this.Hide();
        }

        private void btnCouta_Click(object sender, EventArgs e)
        {
            wfCoutas PaneCoutas = new wfCoutas();
            PaneCoutas.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
