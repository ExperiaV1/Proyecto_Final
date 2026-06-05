using ProyectoFinal;
using ProyectoFinalProgra.Clases;
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
        private PanelCentral panelCentral;
        private Form1 formPrincipal;
        private BindingList<Clientes> listaClientes = new BindingList<Clientes>();
        private string rutaClientes;
        private int contadorClientes = 1;

        public FBomba4() : this(new PanelCentral(), null)
        {
        }

        internal FBomba4(PanelCentral panelCompartido, Form1 formPrincipal)
        {
            InitializeComponent();
            panelCentral = panelCompartido;
            this.formPrincipal = formPrincipal;
            rutaClientes = Path.Combine(Application.StartupPath, "clientes_bomba4.txt");

            ConfigurarCombos();
            Configurar_DataGridView();
            Listados.CargarClientes_DesdeTxt(rutaClientes, listaClientes, contadorClientes);
            dataGridViewB4.CellClick += dataGridViewB4_CellClick;

            btnDespacharB4.Click -= btnDespacharB4_Click;
            btnDespacharB4.Click += btnDespacharB4_Click;
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

        //FUNCION PARA CONGIGURAR LA DATAGRIDVIEW Y MUESTRE LOS DATOS DEL CLIENTE QUE SE NECESITAN 
        private void Configurar_DataGridView()
        {
            dataGridViewB4.AutoGenerateColumns = false;
            dataGridViewB4.Columns.Clear();

            dataGridViewB4.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Name = "Nombre",
                Width = 180
            });

            dataGridViewB4.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "NIT",
                DataPropertyName = "NIT",
                Name = "NIT",
                Width = 130
            });

            dataGridViewB4.DataSource = listaClientes;
            dataGridViewB4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewB4.MultiSelect = false;
            dataGridViewB4.ReadOnly = true;
        }

        //FUNCION PARA SELECCIONAR CLIENTE DE LA DATAGRIDVIEW
        private void Seleccionar_Cliente(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                Clientes cliente = dataGridViewB4.Rows[rowIndex].DataBoundItem as Clientes;

                if (cliente != null)
                {
                    txtNombreB4.Text = cliente.Nombre;
                    txtNitB4.Text = cliente.NIT;
                }
            }
        }

        private void FBomba4_Load(object sender, EventArgs e)
        {

        }

        //EVENTO DE LA DATAGRIDVIEW
        private void dataGridViewB4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar_Cliente(e.RowIndex);
        }

        private async void btnDespacharB4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosBase(txtNombreB4.Text, txtNitB4.Text, comboTipoGasB4.Text, comboTipoAbasB4.Text))
                    return;

                btnDespacharB4.Enabled = false;

                if (comboTipoAbasB4.Text == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB4.Text, out decimal cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad valida mayor a 0.");
                        return;
                    }

                    string mensaje = await panelCentral.IniciarPrepago(
                        txtNombreB4.Text.Trim(),
                        txtNitB4.Text.Trim(),
                        comboTipoGasB4.Text,
                        4,
                        cantidad
                    );

                    MessageBox.Show("Bomba 4 finalizada.\nOrden enviada: " + mensaje);
                }
                else if (comboTipoAbasB4.Text.Equals("Tanque lleno", StringComparison.OrdinalIgnoreCase) || comboTipoAbasB4.Text.Equals("Tanque Lleno", StringComparison.OrdinalIgnoreCase))
                {
                    string mensaje = await panelCentral.IniciarTanqueLleno(
                        txtNombreB4.Text.Trim(),
                        txtNitB4.Text.Trim(),
                        4,
                        comboTipoGasB4.Text
                    );

                    MessageBox.Show("Bomba 4 finalizada en modo tanque lleno.\nOrden enviada: " + mensaje);
                }
                else
                {
                    MessageBox.Show("Selecciona una opcion valida.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btnDespacharB4.Enabled = true;
            }
        }

        private void ConfigurarCombos()
        {
            comboTipoGasB4.Items.Clear();
            comboTipoGasB4.Items.AddRange(new object[] { "Super", "Regular", "Diesel" });
            comboTipoGasB4.DropDownStyle = ComboBoxStyle.DropDownList;

            comboTipoAbasB4.Items.Clear();
            comboTipoAbasB4.Items.AddRange(new object[] { "Prepago", "Tanque lleno" });
            comboTipoAbasB4.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool ValidarDatosBase(string nombre, string nit, string tipoGas, string tipoAbas)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingresar nombre del cliente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(nit))
            {
                MessageBox.Show("Ingresar el NIT del cliente.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tipoGas))
            {
                MessageBox.Show("Selecciona el tipo de combustible.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tipoAbas))
            {
                MessageBox.Show("Selecciona el tipo de abastecimiento.");
                return false;
            }

            return true;
        }

    }
}
