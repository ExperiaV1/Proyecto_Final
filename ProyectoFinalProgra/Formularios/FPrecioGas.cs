using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFinalProgra.Formularios
{
    public partial class FPrecioGas : Form
    {
        private Form1 formPrincipal;
        public FPrecioGas(Form1 formPrincipal)
        {
            InitializeComponent();
            this.formPrincipal = formPrincipal;
        }

        private void btnSalirPrecioGas_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarGas_Click(object sender, EventArgs e)
        {
            try
            {
                string precioSuper = txtSuper.Text.Trim();
                string precioRegular = txtRegular.Text.Trim();
                string precioDiesel = txtDiesel.Text.Trim();

                if (string.IsNullOrWhiteSpace(precioSuper) || string.IsNullOrWhiteSpace(precioRegular) || string.IsNullOrWhiteSpace(precioDiesel))
                {
                    MessageBox.Show("Por favor, llena los precios para los 3 tipos de combustible.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (formPrincipal != null)
                {
                    formPrincipal.ActualizarLabelsPrecios(precioSuper, precioRegular, precioDiesel);
                }

                MessageBox.Show("¡Los precios se han actualizado correctamente en todas las bombas!", "Precios Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
