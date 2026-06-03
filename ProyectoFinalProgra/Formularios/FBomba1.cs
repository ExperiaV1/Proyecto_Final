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

        private async Task btnDespacharB1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombreB1.Text))
                {
                    MessageBox.Show("Ingresar nombre del cliente.");
                }

                if (string.IsNullOrWhiteSpace(txtNitB1.Text))
                {
                    MessageBox.Show("Ingresar el NIT del cliente.");
                }

                if (comboTipoAbasB1.Text == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB1.Text, out decimal monto))
                    {
                        MessageBox.Show("Ingrese una cantidad valida ");
                        return;
                    }
                    string Mensaje = await panelCentral.IniciarPrepago(txtNombreB1.Text, txtCantidadAbasB1.Text, "", 1, monto);

                    MessageBox.Show("El despacho del tanque inicio. \nOrden enviada: " + Mensaje);
                }

                else if (comboTipoAbasB1.Text == "Tanque lleno")
                {
                    string Mensaje = await panelCentral.IniciarTanqueLleno(txtNombreB1.Text, txtCantidadAbasB1.Text, 1);
                    MessageBox.Show("El despacho para llenar el tanque se inicio. \nOrden enviada: " + Mensaje);

                }

                else
                {
                    MessageBox.Show("Selecciona un aopcion valida.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void btnGuardarClienteB1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("clientes listos para descpachar");
        }   

        
    }
}
