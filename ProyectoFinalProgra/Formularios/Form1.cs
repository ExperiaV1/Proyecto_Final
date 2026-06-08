using ProyectoFinal;
using ProyectoFinalProgra.Clases;
using ProyectoFinalProgra.Formularios;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using System.IO;

namespace ProyectoFinalProgra
{
    public partial class Form1 : Form
    {
        // ---- VARIABLES GLOBALES BOMBA 1 ----
        private PanelCentral panelCentral = new PanelCentral();
        private BindingList<Clientes> listaClientesB1 = new BindingList<Clientes>();
        private string rutaClientesB1;
        private int contadorClientesB1 = 1;

        // ---- VARIABLES GLOBALES BOMBA 2 ----
        private BindingList<Clientes> listaClientesB2 = new BindingList<Clientes>();
        private string rutaClientesB2;
        private int contadorClientesB2 = 1;

        // ---- VARIABLES GLOBALES BOMBA 3 ----
        private BindingList<Clientes> listaClientesB3 = new BindingList<Clientes>();
        private string rutaClientesB3;
        private int contadorClientesB3 = 1;

        // ---- VARIABLE GLOBALES BOMBA 4 ----
        private BindingList<Clientes> listaClientesB4 = new BindingList<Clientes>();
        private string rutaClientesB4;
        private int contadorClientesB4 = 1;

        public Form1()
        {
            InitializeComponent();

            // ---- CONFIGURACION INICIAL BOMBA 1 ----
            rutaClientesB1 = Path.Combine(Application.StartupPath, "clientes_bomba1.txt");
            ConfigurarCombosB1();
            Configurar_DataGridViewB1();
            Listados.CargarClientes_DesdeTxt(rutaClientesB1, listaClientesB1, contadorClientesB1);
            dataGridViewB1.CellClick += dataGridViewB1_CellContentClick;

            // ---- CONFIGURACION INICIAL BOMBA 2 ----
            rutaClientesB2 = Path.Combine(Application.StartupPath, "clientes_bomba2.txt");
            ConfigurarCombosB2();
            Configurar_DataGridViewB2();
            Listados.CargarClientes_DesdeTxt(rutaClientesB2, listaClientesB2, contadorClientesB2);
            dataGridViewB2.CellClick += dataGridViewB2_CellContentClick;

            // ---- CONFIGURACION INICIAL BOMBA 3 ----
            rutaClientesB3 = Path.Combine(Application.StartupPath, "clientes_bomba3.txt");
            ConfigurarCombosB3();
            Configurar_DataGridViewB3();
            Listados.CargarClientes_DesdeTxt(rutaClientesB3, listaClientesB3, contadorClientesB3);
            dataGridViewB3.CellClick += dataGridViewB3_CellContentClick;

            // ---- CONFIGURACION INICIAL BOMBA 4 ----
            rutaClientesB4 = Path.Combine(Application.StartupPath, "clientes_bomba4.txt");
            ConfigurarCombosB4();
            Configurar_DataGridViewB4();
            Listados.CargarClientes_DesdeTxt(rutaClientesB4, listaClientesB4, contadorClientesB4);
            dataGridViewB4.CellClick += dataGridViewB4_CellContentClick;
        }
        private void panCentral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDetener4_Click(object sender, EventArgs e)
        {

        }

        // ---- CONFIGURACION DE EVENTO PARA LOS BOTONER USAR PARA IR A LAS BOMBAS ----
        private void btnBomba1_Click_1(object sender, EventArgs e)
        {
            TabModelBombas.SelectedIndex = 1;
        }

        private void btnBomba2_Click_1(object sender, EventArgs e)
        {
            TabModelBombas.SelectedIndex = 2;
        }

        private void btnBomba3_Click_1(object sender, EventArgs e)
        {
            TabModelBombas.SelectedIndex = 3;
        }

        private void btnBomba4_Click_1(object sender, EventArgs e)
        {
            TabModelBombas.SelectedIndex = 4;
        }

        // ---- CONFIGURACION BOTONES DE ESTADISTICAS Y PRECIO GASOLINA ----
        private void btnEstadistica_Click_1(object sender, EventArgs e)
        {
            FEstadisticas formFEstadisticas = new FEstadisticas();
            formFEstadisticas.ShowDialog();
        }

        private void btnPrecioGas_Click_1(object sender, EventArgs e)
        {
            FPrecioGas formFPrecioGas = new FPrecioGas();
            formFPrecioGas.ShowDialog();
        }

        // ---- CONFIGURACION DE BOTONES DE SALIDA 1 AL 4 ----
        private void btnSalirB1_Click(object sender, EventArgs e)
        {
            TabModelBombas.SelectedIndex = 0;
        }

        private void btnSalirB2_Click(object sender, EventArgs e)
        {
            TabModelBombas.SelectedIndex = 0;
        }

        private void btnSalirB3_Click(object sender, EventArgs e)
        {
            TabModelBombas.SelectedIndex = 0;
        }

        private void btnSalirB4_Click(object sender, EventArgs e)
        {
            TabModelBombas.SelectedIndex = 0;
        }

        // ======= LOGICA PARA BOMBA 1 ======
        private void ConfigurarCombosB1()
        {
            comboTipoGasB1.Items.Clear();
            comboTipoGasB1.Items.AddRange(new object[] { "Super", "Regular", "Diesel" });
            comboTipoGasB1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboTipoAbasB1.Items.Clear();
            comboTipoAbasB1.Items.AddRange(new object[] { "Prepago", "Tanque lleno" });
            comboTipoAbasB1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Configurar_DataGridViewB1()
        {
            dataGridViewB1.AutoGenerateColumns = false;
            dataGridViewB1.Columns.Clear();

            dataGridViewB1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Name = "Nombre", Width = 180 });
            dataGridViewB1.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NIT", DataPropertyName = "NIT", Name = "NIT", Width = 130 });

            dataGridViewB1.DataSource = listaClientesB1;
            dataGridViewB1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewB1.MultiSelect = false;
            dataGridViewB1.ReadOnly = true;
        }
        private void BloquearControlesB1(bool bloquear)
        {
            txtNombreB1.ReadOnly = bloquear;
            txtNitB1.ReadOnly = bloquear;
            comboTipoGasB1.Enabled = !bloquear;
            comboTipoAbasB1.Enabled = !bloquear;
            txtCantidadAbasB1.ReadOnly = bloquear;
            btnGuardarClienteB1.Enabled = !bloquear;
        }
        private bool ValidarDatosBaseB1(string nombre, string nit, string tipoGas, string tipoAbas)
        {
            if (string.IsNullOrWhiteSpace(nombre)) { MessageBox.Show("Ingresar nombre del cliente."); return false; }
            if (string.IsNullOrWhiteSpace(nit)) { MessageBox.Show("Ingresar el NIT del cliente."); return false; }
            if (string.IsNullOrWhiteSpace(tipoGas)) { MessageBox.Show("Selecciona el tipo de combustible."); return false; }
            if (string.IsNullOrWhiteSpace(tipoAbas)) { MessageBox.Show("Selecciona el tipo de abastecimiento."); return false; }
            return true;
        }

        private void btnGuardarClienteB1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreB1.Text.Trim();
                string nit = txtNitB1.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(nit))
                {
                    MessageBox.Show("Ingrese el nombre y NIT del cliente.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Clientes cliente = new Clientes(contadorClientesB1, nombre, nit);
                listaClientesB1.Add(cliente);
                contadorClientesB1++;

                Listados.GuardarClientes_EnTxt(rutaClientesB1, listaClientesB1);
                MessageBox.Show("Cliente guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombreB1.Clear();
                txtNitB1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDespacharB1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosBaseB1(txtNombreB1.Text, txtNitB1.Text, comboTipoGasB1.Text, comboTipoAbasB1.Text))
                    return;

                btnDespacharB1.Enabled = false;
                BloquearControlesB1(true);

                if (comboTipoAbasB1.Text == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB1.Text, out decimal cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad valida mayor a 0.");
                        return;
                    }

                    string mensaje = await panelCentral.IniciarPrepago(txtNombreB1.Text.Trim(), txtNitB1.Text.Trim(), comboTipoGasB1.Text, 1, cantidad);
                    MessageBox.Show("Bomba 1 finalizada.\nOrden enviada: " + mensaje);
                }
                else if (comboTipoAbasB1.Text.Equals("Tanque lleno", StringComparison.OrdinalIgnoreCase))
                {
                    string mensaje = await panelCentral.IniciarTanqueLleno(txtNombreB1.Text.Trim(), txtNitB1.Text.Trim(), 1, comboTipoGasB1.Text);
                    MessageBox.Show("Bomba 1 finalizada en modo tanque lleno.\nOrden enviada: " + mensaje);
                }
                else
                {
                    MessageBox.Show("Selecciona una opcion valida.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { btnDespacharB1.Enabled = true; BloquearControlesB1(false); }
        }

        private void dataGridViewB1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Clientes cliente = dataGridViewB1.Rows[e.RowIndex].DataBoundItem as Clientes;
                if (cliente != null)
                {
                    txtNombreB1.Text = cliente.Nombre;
                    txtNitB1.Text = cliente.NIT;
                }
            }
        }
        private void txtNombreB1_TextChanged(object sender, EventArgs e) { }
        private void txtNitB1_TextChanged(object sender, EventArgs e) { }
        private void comboTipoGasB1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboTipoAbasB1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtCantidadAbasB1_TextChanged(object sender, EventArgs e) { }

        // ====== LOGICA BOMBA 2 ======
        private void ConfigurarCombosB2()
        {
            comboTipoGasB2.Items.Clear();
            comboTipoGasB2.Items.AddRange(new object[] { "Super", "Regular", "Diesel" });
            comboTipoGasB2.DropDownStyle = ComboBoxStyle.DropDownList;

            comboTipoAbasB2.Items.Clear();
            comboTipoAbasB2.Items.AddRange(new object[] { "Prepago", "Tanque lleno" });
            comboTipoAbasB2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Configurar_DataGridViewB2()
        {
            dataGridViewB2.AutoGenerateColumns = false;
            dataGridViewB2.Columns.Clear();

            dataGridViewB2.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Name = "Nombre", Width = 180 });
            dataGridViewB2.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NIT", DataPropertyName = "NIT", Name = "NIT", Width = 130 });

            dataGridViewB2.DataSource = listaClientesB2;
            dataGridViewB2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewB2.MultiSelect = false;
            dataGridViewB2.ReadOnly = true;
        }
        private void BloquearControlesB2(bool bloquear)
        {
            txtNombreB2.ReadOnly = bloquear;
            txtNitB2.ReadOnly = bloquear;
            comboTipoGasB2.Enabled = !bloquear;
            comboTipoAbasB2.Enabled = !bloquear;
            txtCantidadAbasB2.ReadOnly = bloquear;
            btnGuardarClienteB2.Enabled = !bloquear;
        }

        private bool ValidarDatosBaseB2(string nombre, string nit, string tipoGas, string tipoAbas)
        {
            if (string.IsNullOrWhiteSpace(nombre)) { MessageBox.Show("Ingresar nombre del cliente en Bomba 2."); return false; }
            if (string.IsNullOrWhiteSpace(nit)) { MessageBox.Show("Ingresar el NIT del cliente en Bomba 2."); return false; }
            if (string.IsNullOrWhiteSpace(tipoGas)) { MessageBox.Show("Selecciona el tipo de combustible en Bomba 2."); return false; }
            if (string.IsNullOrWhiteSpace(tipoAbas)) { MessageBox.Show("Selecciona el tipo de abastecimiento en Bomba 2."); return false; }
            return true;
        }

        private void btnGuardarClienteB2_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreB2.Text.Trim();
                string nit = txtNitB2.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(nit))
                {
                    MessageBox.Show("Ingrese el nombre y NIT del cliente.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // CORRECCIÓN: Se usa contadorClientesB2 y listaClientesB2
                Clientes cliente = new Clientes(contadorClientesB2, nombre, nit);
                listaClientesB2.Add(cliente);
                contadorClientesB2++;

                Listados.GuardarClientes_EnTxt(rutaClientesB2, listaClientesB2);
                MessageBox.Show("Cliente guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombreB2.Clear();
                txtNitB2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDespacharB2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosBaseB2(txtNombreB2.Text, txtNitB2.Text, comboTipoGasB2.Text, comboTipoAbasB2.Text))
                    return;

                btnDespacharB2.Enabled = false;
                BloquearControlesB2(true);

                if (comboTipoAbasB2.Text == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB2.Text, out decimal cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad valida mayor a 0.");
                        return;
                    }

                    string mensaje = await panelCentral.IniciarPrepago(txtNombreB2.Text.Trim(), txtNitB2.Text.Trim(), comboTipoGasB2.Text, 2, cantidad);
                    MessageBox.Show("Bomba 2 finalizada.\nOrden enviada: " + mensaje);
                }
                else if (comboTipoAbasB2.Text.Equals("Tanque lleno", StringComparison.OrdinalIgnoreCase))
                {
                    string mensaje = await panelCentral.IniciarTanqueLleno(txtNombreB2.Text.Trim(), txtNitB2.Text.Trim(), 2, comboTipoGasB2.Text);
                    MessageBox.Show("Bomba 2 finalizada en modo tanque lleno.\nOrden enviada: " + mensaje);
                }
                else
                {
                    MessageBox.Show("Selecciona una opcion valida.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { btnDespacharB2.Enabled = true; BloquearControlesB2(false); }
        }

        private void dataGridViewB2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Clientes cliente = dataGridViewB2.Rows[e.RowIndex].DataBoundItem as Clientes;
                if (cliente != null)
                {
                    txtNombreB2.Text = cliente.Nombre;
                    txtNitB2.Text = cliente.NIT;
                }
            }
        }

        // ====== LOGICA BOMBA 3 =======
        private void ConfigurarCombosB3()
        {
            comboTipoGasB3.Items.Clear();
            comboTipoGasB3.Items.AddRange(new object[] { "Super", "Regular", "Diesel" });
            comboTipoGasB3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboTipoAbasB3.Items.Clear();
            comboTipoAbasB3.Items.AddRange(new object[] { "Prepago", "Tanque lleno" });
            comboTipoAbasB3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Configurar_DataGridViewB3()
        {
            dataGridViewB3.AutoGenerateColumns = false;
            dataGridViewB3.Columns.Clear();

            dataGridViewB3.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Name = "Nombre", Width = 180 });
            dataGridViewB3.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NIT", DataPropertyName = "NIT", Name = "NIT", Width = 130 });

            dataGridViewB3.DataSource = listaClientesB3;
            dataGridViewB3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewB3.MultiSelect = false;
            dataGridViewB3.ReadOnly = true;
        }
        private void BloquearControlesB3(bool bloquear)
        {
            txtNombreB3.ReadOnly = bloquear;
            txtNitB3.ReadOnly = bloquear;
            comboTipoGasB3.Enabled = !bloquear;
            comboTipoAbasB3.Enabled = !bloquear;
            txtCantidadAbasB3.ReadOnly = bloquear;
            btnGuardarClienteB3.Enabled = !bloquear;
        }
        private bool ValidarDatosBaseB3(string nombre, string nit, string tipoGas, string tipoAbas)
        {
            if (string.IsNullOrWhiteSpace(nombre)) { MessageBox.Show("Ingresar nombre del cliente en Bomba 3."); return false; }
            if (string.IsNullOrWhiteSpace(nit)) { MessageBox.Show("Ingresar el NIT del cliente en Bomba 3."); return false; }
            if (string.IsNullOrWhiteSpace(tipoGas)) { MessageBox.Show("Selecciona el tipo de combustible en Bomba 3."); return false; }
            if (string.IsNullOrWhiteSpace(tipoAbas)) { MessageBox.Show("Selecciona el tipo de abastecimiento en Bomba 3."); return false; }
            return true;
        }

        private void btnGuardarClienteB3_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreB3.Text.Trim();
                string nit = txtNitB3.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(nit))
                {
                    MessageBox.Show("Ingrese el nombre y NIT del cliente.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Clientes cliente = new Clientes(contadorClientesB3, nombre, nit);
                listaClientesB3.Add(cliente);
                contadorClientesB3++;

                Listados.GuardarClientes_EnTxt(rutaClientesB3, listaClientesB3);
                MessageBox.Show("Cliente guardado correctamente en Bomba 3.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombreB3.Clear();
                txtNitB3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDespacharB3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosBaseB3(txtNombreB3.Text, txtNitB3.Text, comboTipoGasB3.Text, comboTipoAbasB3.Text))
                    return;

                btnDespacharB3.Enabled = false;
                BloquearControlesB3(true);

                if (comboTipoAbasB3.Text == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB3.Text, out decimal cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad valida mayor a 0.");
                        return;
                    }

                    string mensaje = await panelCentral.IniciarPrepago(txtNombreB3.Text.Trim(), txtNitB3.Text.Trim(), comboTipoGasB3.Text, 3, cantidad);
                    MessageBox.Show("Bomba 3 finalizada.\nOrden enviada: " + mensaje);
                }
                else if (comboTipoAbasB3.Text.Equals("Tanque lleno", StringComparison.OrdinalIgnoreCase))
                {
                    string mensaje = await panelCentral.IniciarTanqueLleno(txtNombreB3.Text.Trim(), txtNitB3.Text.Trim(), 3, comboTipoGasB3.Text);
                    MessageBox.Show("Bomba 3 finalizada en modo tanque lleno.\nOrden enviada: " + mensaje);
                }
                else
                {
                    MessageBox.Show("Selecciona una opcion valida.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { btnDespacharB3.Enabled = true; BloquearControlesB3(false); }
        }

        private void dataGridViewB3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Clientes cliente = dataGridViewB3.Rows[e.RowIndex].DataBoundItem as Clientes;
                if (cliente != null)
                {
                    txtNombreB3.Text = cliente.Nombre;
                    txtNitB3.Text = cliente.NIT;
                }
            }
        }

        // ====== LOGICA BOMBA 4 ======
        private void ConfigurarCombosB4()
        {
            comboTipoGasB4.Items.Clear();
            comboTipoGasB4.Items.AddRange(new object[] { "Super", "Regular", "Diesel" });
            comboTipoGasB4.DropDownStyle = ComboBoxStyle.DropDownList;

            comboTipoAbasB4.Items.Clear();
            comboTipoAbasB4.Items.AddRange(new object[] { "Prepago", "Tanque lleno" });
            comboTipoAbasB4.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Configurar_DataGridViewB4()
        {
            dataGridViewB4.AutoGenerateColumns = false;
            dataGridViewB4.Columns.Clear();

            dataGridViewB4.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre", Name = "Nombre", Width = 180 });
            dataGridViewB4.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NIT", DataPropertyName = "NIT", Name = "NIT", Width = 130 });

            dataGridViewB4.DataSource = listaClientesB4;
            dataGridViewB4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewB4.MultiSelect = false;
            dataGridViewB4.ReadOnly = true;
        }
        private void BloquearControlesB4(bool bloquear)
        {
            txtNombreB4.ReadOnly = bloquear;
            txtNitB4.ReadOnly = bloquear;
            comboTipoGasB4.Enabled = !bloquear;
            comboTipoAbasB4.Enabled = !bloquear;
            txtCantidadAbasB4.ReadOnly = bloquear;
            btnGuardarClienteB4.Enabled = !bloquear;
        }
        private bool ValidarDatosBaseB4(string nombre, string nit, string tipoGas, string tipoAbas)
        {
            if (string.IsNullOrWhiteSpace(nombre)) { MessageBox.Show("Ingresar nombre del cliente en Bomba 4."); return false; }
            if (string.IsNullOrWhiteSpace(nit)) { MessageBox.Show("Ingresar el NIT del cliente en Bomba 4."); return false; }
            if (string.IsNullOrWhiteSpace(tipoGas)) { MessageBox.Show("Selecciona el tipo de combustible en Bomba 4."); return false; }
            if (string.IsNullOrWhiteSpace(tipoAbas)) { MessageBox.Show("Selecciona el tipo de abastecimiento en Bomba 4."); return false; }
            return true;
        }

        private void btnGuardarClienteB4_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreB4.Text.Trim();
                string nit = txtNitB4.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(nit))
                {
                    MessageBox.Show("Ingrese el nombre y NIT del cliente.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Clientes cliente = new Clientes(contadorClientesB4, nombre, nit);
                listaClientesB4.Add(cliente);
                contadorClientesB4++;

                Listados.GuardarClientes_EnTxt(rutaClientesB4, listaClientesB4);
                MessageBox.Show("Cliente guardado correctamente en Bomba 4.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombreB4.Clear();
                txtNitB4.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDespacharB4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatosBaseB4(txtNombreB4.Text, txtNitB4.Text, comboTipoGasB4.Text, comboTipoAbasB4.Text))
                    return;

                btnDespacharB4.Enabled = false;
                BloquearControlesB4(true);

                if (comboTipoAbasB4.Text == "Prepago")
                {
                    if (!decimal.TryParse(txtCantidadAbasB4.Text, out decimal cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad valida mayor a 0.");
                        return;
                    }

                    string mensaje = await panelCentral.IniciarPrepago(txtNombreB4.Text.Trim(), txtNitB4.Text.Trim(), comboTipoGasB4.Text, 4, cantidad);
                    MessageBox.Show("Bomba 4 finalizada.\nOrden enviada: " + mensaje);
                }
                else if (comboTipoAbasB4.Text.Equals("Tanque lleno", StringComparison.OrdinalIgnoreCase))
                {
                    string mensaje = await panelCentral.IniciarTanqueLleno(txtNombreB4.Text.Trim(), txtNitB4.Text.Trim(), 4, comboTipoGasB4.Text);
                    MessageBox.Show("Bomba 4 finalizada en modo tanque lleno.\nOrden enviada: " + mensaje);
                }
                else
                {
                    MessageBox.Show("Selecciona una opcion valida.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { btnDespacharB4.Enabled = true; BloquearControlesB4(false); }
        }

        private void dataGridViewB4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Clientes cliente = dataGridViewB4.Rows[e.RowIndex].DataBoundItem as Clientes;
                if (cliente != null)
                {
                    txtNombreB4.Text = cliente.Nombre;
                    txtNitB4.Text = cliente.NIT;
                }
            }
        }
    }
}
