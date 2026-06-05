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
    public partial class FBomba3 : Form
    {
        private PanelCentral panelCentral;
        private Form1 formPrincipal;
        private BindingList<Clientes> listaClientes = new BindingList<Clientes>();
        private string rutaClientes;
        private int contadorClientes = 1;

        public FBomba3() : this(new PanelCentral(), null)
        {
        }

        internal FBomba3(PanelCentral panelCompartido, Form1 formPrincipal)
        {
            InitializeComponent();
            panelCentral = panelCompartido;
            this.formPrincipal = formPrincipal;
            rutaClientes = Path.Combine(Application.StartupPath, "clientes_bomba3.txt");

            ConfigurarCombos();
            Configurar_DataGridView();
            Listados.CargarClientes_DesdeTxt(rutaClientes, listaClientes, contadorClientes);
            dataGridViewB3.CellClick += dataGridViewB3_CellClick;

            btnDespacharB3.Click -= btnDespacharB3_Click;
            btnDespacharB3.Click += btnDespacharB3_Click;
        }

        private void btnSalirB3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 formForm1 = new Form1();
            formForm1.Show();
        }

        private void btnGuardarClienteB3_Click(object sender, EventArgs e)
        {
            try
            {
                // SE OBTIENE EL TEXTO INGRESADO EN LOS TEXTBOX
                string nombre = txtNombreB3.Text.Trim();
                string nit = txtNitB3.Text.Trim();

                // SE VALIDA QUE EL CAMPO NOMBRE NO ESTE VACIO
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Ingrese el nombre del cliente.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // SE VALIDA QUE EL CAMPO NIT NO ESTE VACIO
                if (string.IsNullOrWhiteSpace(nit))
                {
                    MessageBox.Show("Ingrese el NIT del cliente.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // SE CREA EL OBJETO CLIENTE CON EL ID, NOMBRE Y NIT Y SE VAN LLAMANDO LAS FUNCIONES
                Clientes cliente = new Clientes(contadorClientes, nombre, nit);

                listaClientes.Add(cliente);

                contadorClientes++;

                Listados.GuardarClientes_EnTxt(rutaClientes, listaClientes);
                MessageBox.Show("Cliente guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // SE LIMPIAN LOS TEXTBOX
                txtNombreB3.Clear();
                txtNitB3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //___Metodo Auxiliar para bloquear y desploquear___
        private void BloquearControles(bool bloquear)
        {
            txtNombreB3.ReadOnly = bloquear;
            txtNitB3.ReadOnly = bloquear;
            comboTipoGasB3.Enabled = !bloquear;
            comboTipoAbasB3.Enabled = !bloquear;
            txtCantidadAbasB3.ReadOnly = bloquear;
        }

        //FUNCION PARA CONGIGURAR LA DATAGRIDVIEW Y MUESTRE LOS DATOS DEL CLIENTE QUE SE NECESITAN 
        private void Configurar_DataGridView()
        {
            dataGridViewB3.AutoGenerateColumns = false;
            dataGridViewB3.Columns.Clear();

            dataGridViewB3.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Name = "Nombre",
                Width = 180
            });

            dataGridViewB3.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "NIT",
                DataPropertyName = "NIT",
                Name = "NIT",
                Width = 130
            });

            dataGridViewB3.DataSource = listaClientes;
            dataGridViewB3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewB3.MultiSelect = false;
            dataGridViewB3.ReadOnly = true;
        }

        //FUNCION PARA SELECCIONAR CLIENTE DE LA DATAGRIDVIEW
        private void Seleccionar_Cliente(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                Clientes cliente = dataGridViewB3.Rows[rowIndex].DataBoundItem as Clientes;

                if (cliente != null)
                {
                    txtNombreB3.Text = cliente.Nombre;
                    txtNitB3.Text = cliente.NIT;
                }
            }
        }

        private void FBomba3_Load(object sender, EventArgs e)
        {

        }

        //EVENTO DE LA DATAGRIDVIEW
        private void dataGridViewB3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar_Cliente(e.RowIndex);
        }

        private async void btnDespacharB3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosBase(txtNombreB3.Text, txtNitB3.Text, comboTipoGasB3.Text, comboTipoAbasB3.Text))
                    return;

                btnDespacharB3.Enabled = false;

                if (comboTipoAbasB3.Text == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB3.Text, out decimal cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad valida mayor a 0.");
                        return;
                    }

                    string mensaje = await panelCentral.IniciarPrepago(
                        txtNombreB3.Text.Trim(),
                        txtNitB3.Text.Trim(),
                        comboTipoGasB3.Text,
                        3,
                        cantidad
                    );

                    MessageBox.Show("Bomba 3 finalizada.\nOrden enviada: " + mensaje);
                }
                else if (comboTipoAbasB3.Text.Equals("Tanque lleno", StringComparison.OrdinalIgnoreCase) || comboTipoAbasB3.Text.Equals("Tanque Lleno", StringComparison.OrdinalIgnoreCase))
                {
                    string mensaje = await panelCentral.IniciarTanqueLleno(
                        txtNombreB3.Text.Trim(),
                        txtNitB3.Text.Trim(),
                        3,
                        comboTipoGasB3.Text
                    );

                    MessageBox.Show("Bomba 3 finalizada en modo tanque lleno.\nOrden enviada: " + mensaje);
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
                btnDespacharB3.Enabled = true;
            }
        }

        private void ConfigurarCombos()
        {
            comboTipoGasB3.Items.Clear();
            comboTipoGasB3.Items.AddRange(new object[] { "Super", "Regular", "Diesel" });
            comboTipoGasB3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboTipoAbasB3.Items.Clear();
            comboTipoAbasB3.Items.AddRange(new object[] { "Prepago", "Tanque lleno" });
            comboTipoAbasB3.DropDownStyle = ComboBoxStyle.DropDownList;
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
