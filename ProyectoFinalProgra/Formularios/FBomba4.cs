using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFinalProgra.Formularios
{
    public partial class FBomba4 : Form
    {
        public FBomba4()
        {
            InitializeComponent();
        }

        private void btnSalirB4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 formForm1 = new Form1();
            formForm1.Show();
        }

        private void btnGuardarClienteB4_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Capturamos y limpiamos los textos
                string nombre = txtNombreB4.Text.Trim();
                string nit = txtNitB4.Text.Trim();

                // 2. Validamos que haya seleccionado algo en los ComboBox
                if (comboTipoGasB4.SelectedItem == null || comboTipoAbasB4.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione el tipo de combustible y abastecimiento.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipoGas = comboTipoGasB4.SelectedItem.ToString();
                string tipoAbas = comboTipoAbasB4.SelectedItem.ToString();

                // 3. Validamos campos de texto vacíos
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(nit))
                {
                    MessageBox.Show("El Nombre y el NIT son obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal cantidad = 0;

                if (tipoAbas == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB4.Text, out cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Para prepago, ingrese una cantidad válida mayor a 0.", "Error de cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //___Metodo Auxiliar para bloquear y desploquear___
        private void BloquearControles(bool bloquear)
        {
            txtNombreB4.ReadOnly = bloquear;
            txtNitB4.ReadOnly = bloquear;
            comboTipoGasB4.Enabled = !bloquear;
            comboTipoAbasB4.Enabled = !bloquear;
            txtCantidadAbasB4.ReadOnly = bloquear;
        }
    }
}
