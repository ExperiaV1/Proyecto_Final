using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFinalProgra.Formularios
{
    public partial class FBomba2 : Form
    {
        public FBomba2()
        {
            InitializeComponent();
        }

        private void btnSalirB2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 formForm1 = new Form1();
            formForm1.Show();
        }

        private void btnGuardarClienteB2_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Capturamos y limpiamos los textos
                string nombre = txtNombreB2.Text.Trim();
                string nit = txtNitB2.Text.Trim();

                // 2. Validamos que haya seleccionado algo en los ComboBox
                if (comboTipoGasB2.SelectedItem == null || comboTipoAbasB2.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione el tipo de combustible y abastecimiento.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipoGas = comboTipoGasB2.SelectedItem.ToString();
                string tipoAbas = comboTipoAbasB2.SelectedItem.ToString();

                // 3. Validamos campos de texto vacíos
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(nit))
                {
                    MessageBox.Show("El Nombre y el NIT son obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal cantidad = 0;

                if (tipoAbas == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB2.Text, out cantidad) || cantidad <= 0)
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
            txtNombreB2.ReadOnly = bloquear;
            txtNitB2.ReadOnly = bloquear;
            comboTipoGasB2.Enabled = !bloquear;
            comboTipoAbasB2.Enabled = !bloquear;
            txtCantidadAbasB2.ReadOnly = bloquear;
        }
    }
}
