using ProyectoFinal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFinalProgra.Formularios
{
    public partial class FBomba1 : Form
    {
        private PanelCentral panelCentral;
        public FBomba1()
        {
            InitializeComponent();
            panelCentral = new PanelCentral();

            
        }

        private void btnSalirB1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 formForm1 = new Form1();
            formForm1.Show();
        }

        private void txtNombreB1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNitB1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboTipoGasB1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboTipoAbasB1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidadAbasB1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDespacharB1_Click(object sender, EventArgs e)
        {

        }
    }
}
