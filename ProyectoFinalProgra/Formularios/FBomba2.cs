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
    public partial class FBomba2 : Form
    {
        private PanelCentral panelCentral;
        private BindingList<Clientes> listaClientes = new BindingList<Clientes>();
        private string rutaClientes;
        private int contadorClientes = 1;

        public FBomba2()
        {
            InitializeComponent();
            panelCentral = new PanelCentral();
            rutaClientes = Path.Combine(Application.StartupPath, "clientes_bomba1.txt");

            Configurar_DataGridView();
            //CargarClientes_DesdeTxt();
            Listados.CargarClientes_DesdeTxt(rutaClientes, listaClientes, contadorClientes);

            dataGridViewB2.CellClick += dataGridViewB2_CellClick;

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

        private void btnDespacharB2_Click(object sender, EventArgs e)
        {

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
    }
}
