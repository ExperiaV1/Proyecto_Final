using ProyectoFinal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using ProyectoFinalProgra.Clases;
using System.IO;

namespace ProyectoFinalProgra.Formularios
{
    public partial class FBomba1 : Form
    {
        private PanelCentral panelCentral;
        private Form1 formPrincipal;
        private BindingList<Clientes> listaClientes = new BindingList<Clientes>();
        private string rutaClientes;
        private int contadorClientes = 1;

        public FBomba1() : this(new PanelCentral(), null)
        {
        }

        internal FBomba1(PanelCentral panelCompartido, Form1 formPrincipal)
        {
            InitializeComponent();
            panelCentral = panelCompartido;
            this.formPrincipal = formPrincipal;
            rutaClientes = Path.Combine(Application.StartupPath, "clientes_bomba1.txt");

            ConfigurarCombos();
            Configurar_DataGridView();
            Listados.CargarClientes_DesdeTxt(rutaClientes, listaClientes, contadorClientes);
            dataGridViewB1.CellClick += dataGridViewB1_CellClick;
        }

        private void btnSalirB1_Click(object sender, EventArgs e)
        {
            this.Close();

            if (formPrincipal != null)
            {
                formPrincipal.Show();
            }
            else
            {
                Form1 formForm1 = new Form1();
                formForm1.Show();
            }
        }

        private async void btnDespacharB1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosBase(txtNombreB1.Text, txtNitB1.Text, comboTipoGasB1.Text, comboTipoAbasB1.Text))
                    return;

                btnDespacharB1.Enabled = false;

                if (comboTipoAbasB1.Text == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB1.Text, out decimal cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad valida mayor a 0.");
                        return;
                    }

                    string mensaje = await panelCentral.IniciarPrepago(
                        txtNombreB1.Text.Trim(),
                        txtNitB1.Text.Trim(),
                        comboTipoGasB1.Text,
                        1,
                        cantidad
                    );

                    MessageBox.Show("Bomba 1 finalizada.\nOrden enviada: " + mensaje);
                }
                else if (comboTipoAbasB1.Text.Equals("Tanque lleno", StringComparison.OrdinalIgnoreCase) || comboTipoAbasB1.Text.Equals("Tanque Lleno", StringComparison.OrdinalIgnoreCase))
                {
                    string mensaje = await panelCentral.IniciarTanqueLleno(
                        txtNombreB1.Text.Trim(),
                        txtNitB1.Text.Trim(),
                        1,
                        comboTipoGasB1.Text
                    );

                    MessageBox.Show("Bomba 1 finalizada en modo tanque lleno.\nOrden enviada: " + mensaje);
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
                btnDespacharB1.Enabled = true;
            }
        }


        private void ConfigurarCombos()
        {
            comboTipoGasB1.Items.Clear();
            comboTipoGasB1.Items.AddRange(new object[] { "Super", "Regular", "Diesel" });
            comboTipoGasB1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboTipoAbasB1.Items.Clear();
            comboTipoAbasB1.Items.AddRange(new object[] { "Prepago", "Tanque lleno" });
            comboTipoAbasB1.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void btnGuardarClienteB1_Click(object sender, EventArgs e)
        {
            try
            {
                // SE OBTIENE EL TEXTO INGRESADO EN LOS TEXTBOX
                string nombre = txtNombreB1.Text.Trim();
                string nit = txtNitB1.Text.Trim();

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
                txtNombreB1.Clear();
                txtNitB1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //___Metodo Auxiliar para bloquear y desploquear___
        private void BloquearControles(bool bloquear)
        {
            txtNombreB1.ReadOnly = bloquear;
            txtNitB1.ReadOnly = bloquear;
            comboTipoGasB1.Enabled = !bloquear;
            comboTipoAbasB1.Enabled = !bloquear;
            txtCantidadAbasB1.ReadOnly = bloquear;
        }

        //FUNCION PARA CONGIGURAR LA DATAGRIDVIEW Y MUESTRE LOS DATOS DEL CLIENTE QUE SE NECESITAN 
        private void Configurar_DataGridView()
        {
            dataGridViewB1.AutoGenerateColumns = false;
            dataGridViewB1.Columns.Clear();

            dataGridViewB1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Name = "Nombre",
                Width = 180
            });

            dataGridViewB1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "NIT",
                DataPropertyName = "NIT",
                Name = "NIT",
                Width = 130
            });

            dataGridViewB1.DataSource = listaClientes;
            dataGridViewB1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewB1.MultiSelect = false;
            dataGridViewB1.ReadOnly = true;
        }

        // FUNCION PARA GUARDAR LOS DATOS DEL CLIENTE EN UN TXT Y LUEGO LLAMARLO SIEMPRE QUE SE INICIE EL PROGRAMA
        private void GuardarClientes_EnTxt()
        {
            using (StreamWriter writer = new StreamWriter(rutaClientes, false))
            {
                foreach (Clientes cliente in listaClientes)
                {
                    writer.WriteLine(cliente.Nombre + "|" + cliente.NIT);
                }
            }
        }

        //FUNCION PARA CARGAR LOS DATOS DEL CLIENTE CADA VEZ QUE SE INICIE EL PROGRAMA
        private void CargarClientes_DesdeTxt()
        {
            if (!File.Exists(rutaClientes))
            {
                return;
            }

            string[] lineas = File.ReadAllLines(rutaClientes);

            foreach (string linea in lineas)
            {
                string[] datos = linea.Split('|');

                if (datos.Length == 2)
                {
                    string nombre = datos[0];
                    string nit = datos[1];

                    Clientes cliente = new Clientes(contadorClientes, nombre, nit);
                    listaClientes.Add(cliente);

                    contadorClientes++;
                }
            }
        }

        //FUNCION PARA SELECCIONAR CLIENTE DE LA DATAGRIDVIEW
        private void Seleccionar_Cliente(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                Clientes cliente = dataGridViewB1.Rows[rowIndex].DataBoundItem as Clientes;

                if (cliente != null)
                {
                    txtNombreB1.Text = cliente.Nombre;
                    txtNitB1.Text = cliente.NIT;
                }
            }
        }

        //EVENTO DE LA DATAGRIDVIEW
        private void dataGridViewB1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            Seleccionar_Cliente(e.RowIndex);
        }
        private void FBomba1_Load(object sender, EventArgs e) { }
        private void txtNombreB1_TextChanged(object sender, EventArgs e) { }
        private void txtNitB1_TextChanged(object sender, EventArgs e) { }
        private void comboTipoGasB1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboTipoAbasB1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtCantidadAbasB1_TextChanged(object sender, EventArgs e) { }

    }
}