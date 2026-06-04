namespace ProyectoFinalProgra.Formularios
{
    partial class FBomba1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnSalirB1 = new Button();
            pictureBox1 = new PictureBox();
            dataGridViewB1 = new DataGridView();
            txtNombreB1 = new TextBox();
            comboTipoGasB1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtNitB1 = new TextBox();
            comboTipoAbasB1 = new ComboBox();
            txtCantidadAbasB1 = new TextBox();
            btnGuardarClienteB1 = new Button();
            btnDespacharB1 = new Button();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewB1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1004, 58);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(230, 30);
            label1.TabIndex = 0;
            label1.Text = "Datos del cliente";
            // 
            // btnSalirB1
            // 
            btnSalirB1.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalirB1.Location = new Point(1095, 674);
            btnSalirB1.Margin = new Padding(4, 4, 4, 4);
            btnSalirB1.Name = "btnSalirB1";
            btnSalirB1.Size = new Size(165, 58);
            btnSalirB1.TabIndex = 1;
            btnSalirB1.Text = "Salir";
            btnSalirB1.UseVisualStyleBackColor = true;
            btnSalirB1.Click += btnSalirB1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bomba_1;
            pictureBox1.Location = new Point(1516, 112);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(502, 562);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewB1
            // 
            dataGridViewB1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewB1.Location = new Point(16, 112);
            dataGridViewB1.Margin = new Padding(4, 4, 4, 4);
            dataGridViewB1.Name = "dataGridViewB1";
            dataGridViewB1.RowHeadersWidth = 51;
            dataGridViewB1.Size = new Size(584, 562);
            dataGridViewB1.TabIndex = 3;
            // 
            // txtNombreB1
            // 
            txtNombreB1.Location = new Point(1162, 176);
            txtNombreB1.Margin = new Padding(4, 4, 4, 4);
            txtNombreB1.Name = "txtNombreB1";
            txtNombreB1.Size = new Size(228, 35);
            txtNombreB1.TabIndex = 4;
            txtNombreB1.TextChanged += txtNombreB1_TextChanged;
            // 
            // comboTipoGasB1
            // 
            comboTipoGasB1.FormattingEnabled = true;
            comboTipoGasB1.Items.AddRange(new object[] { "Super", "Regular", "Dicel" });
            comboTipoGasB1.Location = new Point(1164, 352);
            comboTipoGasB1.Margin = new Padding(4, 4, 4, 4);
            comboTipoGasB1.Name = "comboTipoGasB1";
            comboTipoGasB1.Size = new Size(224, 38);
            comboTipoGasB1.TabIndex = 5;
            comboTipoGasB1.SelectedIndexChanged += comboTipoGasB1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(704, 176);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(127, 30);
            label2.TabIndex = 6;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(704, 276);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 30);
            label3.TabIndex = 7;
            label3.Text = "Nit:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(704, 352);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(284, 30);
            label4.TabIndex = 8;
            label4.Text = "Tipo de combustible:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(704, 440);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(324, 30);
            label5.TabIndex = 9;
            label5.Text = "Tipo de abastecimiento:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(704, 524);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(386, 30);
            label6.TabIndex = 10;
            label6.Text = "Cantidad de abastecimiento:";
            // 
            // txtNitB1
            // 
            txtNitB1.Location = new Point(1164, 266);
            txtNitB1.Margin = new Padding(4, 4, 4, 4);
            txtNitB1.Name = "txtNitB1";
            txtNitB1.Size = new Size(228, 35);
            txtNitB1.TabIndex = 11;
            txtNitB1.TextChanged += txtNitB1_TextChanged;
            // 
            // comboTipoAbasB1
            // 
            comboTipoAbasB1.FormattingEnabled = true;
            comboTipoAbasB1.Items.AddRange(new object[] { "Prepago", "Tanque lleno" });
            comboTipoAbasB1.Location = new Point(1166, 436);
            comboTipoAbasB1.Margin = new Padding(4, 4, 4, 4);
            comboTipoAbasB1.Name = "comboTipoAbasB1";
            comboTipoAbasB1.Size = new Size(224, 38);
            comboTipoAbasB1.TabIndex = 12;
            comboTipoAbasB1.SelectedIndexChanged += comboTipoAbasB1_SelectedIndexChanged;
            // 
            // txtCantidadAbasB1
            // 
            txtCantidadAbasB1.Location = new Point(1166, 524);
            txtCantidadAbasB1.Margin = new Padding(4, 4, 4, 4);
            txtCantidadAbasB1.Name = "txtCantidadAbasB1";
            txtCantidadAbasB1.Size = new Size(228, 35);
            txtCantidadAbasB1.TabIndex = 13;
            txtCantidadAbasB1.TextChanged += txtCantidadAbasB1_TextChanged;
            // 
            // btnGuardarClienteB1
            // 
            btnGuardarClienteB1.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarClienteB1.Location = new Point(910, 674);
            btnGuardarClienteB1.Margin = new Padding(4, 4, 4, 4);
            btnGuardarClienteB1.Name = "btnGuardarClienteB1";
            btnGuardarClienteB1.Size = new Size(159, 58);
            btnGuardarClienteB1.TabIndex = 14;
            btnGuardarClienteB1.Text = "Guardar";
            btnGuardarClienteB1.UseVisualStyleBackColor = true;
            btnGuardarClienteB1.Click += btnGuardarClienteB1_Click;
            // 
            // btnDespacharB1
            // 
            btnDespacharB1.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDespacharB1.Location = new Point(1702, 712);
            btnDespacharB1.Margin = new Padding(4, 4, 4, 4);
            btnDespacharB1.Name = "btnDespacharB1";
            btnDespacharB1.Size = new Size(192, 68);
            btnDespacharB1.TabIndex = 15;
            btnDespacharB1.Text = "Despachar";
            btnDespacharB1.UseVisualStyleBackColor = true;
            btnDespacharB1.Click += btnDespacharB1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(152, 58);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(270, 30);
            label7.TabIndex = 16;
            label7.Text = "Clientes Frecuentes";
            // 
            // FBomba1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(2052, 832);
            Controls.Add(label7);
            Controls.Add(btnDespacharB1);
            Controls.Add(btnGuardarClienteB1);
            Controls.Add(txtCantidadAbasB1);
            Controls.Add(comboTipoAbasB1);
            Controls.Add(txtNitB1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboTipoGasB1);
            Controls.Add(txtNombreB1);
            Controls.Add(dataGridViewB1);
            Controls.Add(pictureBox1);
            Controls.Add(btnSalirB1);
            Controls.Add(label1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FBomba1";
            Text = "FBomba1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewB1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnGuardarClienteB1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private Button btnSalirB1;
        private PictureBox pictureBox1;
        private DataGridView dataGridViewB1;
        private TextBox txtNombreB1;
        private ComboBox comboTipoGasB1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtNitB1;
        private ComboBox comboTipoAbasB1;
        private TextBox txtCantidadAbasB1;
        private Button btnGuardarClienteB1;
        private Button btnDespacharB1;
        private Label label7;
    }
}