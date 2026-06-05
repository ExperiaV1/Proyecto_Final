using ProyectoFinal;
using ProyectoFinalProgra.Clases;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace ProyectoFinalProgra.Formularios
{
    public partial class FBomba2 : Form
    {
        private PanelCentral panelCentral;
        private Form1 formPrincipal;
        private BindingList<Clientes> listaClientes = new BindingList<Clientes>();
        private string rutaClientes;
        private int contadorClientes = 1;

        public FBomba2() : this(new PanelCentral(), null)
        {
        }

        internal FBomba2(PanelCentral panelCompartido, Form1 formPrincipal)
        {
            InitializeComponent();
            panelCentral = panelCompartido;
            this.formPrincipal = formPrincipal;
            rutaClientes = Path.Combine(Application.StartupPath, "clientes_bomba2.txt");

            ConfigurarCombos();
            Configurar_DataGridView();
            Listados.CargarClientes_DesdeTxt(rutaClientes, listaClientes, contadorClientes);
            dataGridViewB2.CellClick += dataGridViewB2_CellClick;

            btnDespacharB2.Click -= btnDespacharB2_Click;
            btnDespacharB2.Click += btnDespacharB2_Click;
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
                // SE OBTIENE EL TEXTO INGRESADO EN LOS TEXTBOX
                string nombre = txtNombreB2.Text.Trim();
                string nit = txtNitB2.Text.Trim();

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
                txtNombreB2.Clear();
                txtNitB2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void btnDespacharB2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosBase(txtNombreB2.Text, txtNitB2.Text, comboTipoGasB2.Text, comboTipoAbasB2.Text))
                    return;

                btnDespacharB2.Enabled = false;

                if (comboTipoAbasB2.Text == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB2.Text, out decimal cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad valida mayor a 0.");
                        return;
                    }

                    string mensaje = await panelCentral.IniciarPrepago(
                        txtNombreB2.Text.Trim(),
                        txtNitB2.Text.Trim(),
                        comboTipoGasB2.Text,
                        2,
                        cantidad
                    );

                    MessageBox.Show("Bomba 2 finalizada.\nOrden enviada: " + mensaje);
                }
                else if (comboTipoAbasB2.Text.Equals("Tanque lleno", StringComparison.OrdinalIgnoreCase) || comboTipoAbasB2.Text.Equals("Tanque Lleno", StringComparison.OrdinalIgnoreCase))
                {
                    string mensaje = await panelCentral.IniciarTanqueLleno(
                        txtNombreB2.Text.Trim(),
                        txtNitB2.Text.Trim(),
                        2,
                        comboTipoGasB2.Text
                    );

                    MessageBox.Show("Bomba 2 finalizada en modo tanque lleno.\nOrden enviada: " + mensaje);
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
                btnDespacharB2.Enabled = true;
            }
        }

        private void ConfigurarCombos()
        {
            comboTipoGasB2.Items.Clear();
            comboTipoGasB2.Items.AddRange(new object[] { "Super", "Regular", "Diesel" });
            comboTipoGasB2.DropDownStyle = ComboBoxStyle.DropDownList;

            comboTipoAbasB2.Items.Clear();
            comboTipoAbasB2.Items.AddRange(new object[] { "Prepago", "Tanque lleno" });
            comboTipoAbasB2.DropDownStyle = ComboBoxStyle.DropDownList;
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

        //FUNCION PARA CONGIGURAR LA DATAGRIDVIEW Y MUESTRE LOS DATOS DEL CLIENTE QUE SE NECESITAN 
        private void Configurar_DataGridView()
        {
            dataGridViewB2.AutoGenerateColumns = false;
            dataGridViewB2.Columns.Clear();

            dataGridViewB2.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Name = "Nombre",
                Width = 180
            });

            dataGridViewB2.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "NIT",
                DataPropertyName = "NIT",
                Name = "NIT",
                Width = 130
            });

            dataGridViewB2.DataSource = listaClientes;
            dataGridViewB2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewB2.MultiSelect = false;
            dataGridViewB2.ReadOnly = true;
        }

        //FUNCION PARA SELECCIONAR CLIENTE DE LA DATAGRIDVIEW
        private void Seleccionar_Cliente(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                Clientes cliente = dataGridViewB2.Rows[rowIndex].DataBoundItem as Clientes;

                if (cliente != null)
                {
                    txtNombreB2.Text = cliente.Nombre;
                    txtNitB2.Text = cliente.NIT;
                }
            }
        }

        //EVENTO DE LA DATAGRIDVIEW
        private void dataGridViewB2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar_Cliente(e.RowIndex);
        }

        private void FBomba2_Load(object sender, EventArgs e)
        {

        }
    }
}
