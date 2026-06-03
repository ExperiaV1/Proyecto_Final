namespace ProyectoFinalProgra.Formularios
{
    partial class FBomba4
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
            label7 = new Label();
            btnDespacharB4 = new Button();
            btnGuardarClienteB4 = new Button();
            txtCantidadAbasB4 = new TextBox();
            comboTipoAbasB4 = new ComboBox();
            txtNitB4 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            comboTipoGasB4 = new ComboBox();
            txtNombreB4 = new TextBox();
            dataGridViewB4 = new DataGridView();
            pictureBox1 = new PictureBox();
            btnSalirB4 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewB4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(93, 29);
            label7.Name = "label7";
            label7.Size = new Size(153, 18);
            label7.TabIndex = 50;
            label7.Text = "Clientes Frecuentes";
            // 
            // btnDespacharB4
            // 
            btnDespacharB4.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDespacharB4.Location = new Point(998, 356);
            btnDespacharB4.Margin = new Padding(3, 2, 3, 2);
            btnDespacharB4.Name = "btnDespacharB4";
            btnDespacharB4.Size = new Size(112, 34);
            btnDespacharB4.TabIndex = 49;
            btnDespacharB4.Text = "Despachar";
            btnDespacharB4.UseVisualStyleBackColor = true;
            // 
            // btnGuardarClienteB4
            // 
            btnGuardarClienteB4.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarClienteB4.Location = new Point(536, 337);
            btnGuardarClienteB4.Margin = new Padding(3, 2, 3, 2);
            btnGuardarClienteB4.Name = "btnGuardarClienteB4";
            btnGuardarClienteB4.Size = new Size(93, 29);
            btnGuardarClienteB4.TabIndex = 48;
            btnGuardarClienteB4.Text = "Guardar";
            btnGuardarClienteB4.UseVisualStyleBackColor = true;
            btnGuardarClienteB4.Click += btnGuardarClienteB4_Click;
            // 
            // txtCantidadAbasB4
            // 
            txtCantidadAbasB4.Location = new Point(684, 262);
            txtCantidadAbasB4.Margin = new Padding(3, 2, 3, 2);
            txtCantidadAbasB4.Name = "txtCantidadAbasB4";
            txtCantidadAbasB4.Size = new Size(134, 23);
            txtCantidadAbasB4.TabIndex = 47;
            // 
            // comboTipoAbasB4
            // 
            comboTipoAbasB4.FormattingEnabled = true;
            comboTipoAbasB4.Location = new Point(684, 218);
            comboTipoAbasB4.Margin = new Padding(3, 2, 3, 2);
            comboTipoAbasB4.Name = "comboTipoAbasB4";
            comboTipoAbasB4.Size = new Size(133, 23);
            comboTipoAbasB4.TabIndex = 46;
            // 
            // txtNitB4
            // 
            txtNitB4.Location = new Point(683, 133);
            txtNitB4.Margin = new Padding(3, 2, 3, 2);
            txtNitB4.Name = "txtNitB4";
            txtNitB4.Size = new Size(134, 23);
            txtNitB4.TabIndex = 45;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(414, 262);
            label6.Name = "label6";
            label6.Size = new Size(224, 18);
            label6.TabIndex = 44;
            label6.Text = "Cantidad de abastecimiento:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(414, 220);
            label5.Name = "label5";
            label5.Size = new Size(187, 18);
            label5.TabIndex = 43;
            label5.Text = "Tipo de abastecimiento:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(414, 176);
            label4.Name = "label4";
            label4.Size = new Size(164, 18);
            label4.TabIndex = 42;
            label4.Text = "Tipo de combustible:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(414, 138);
            label3.Name = "label3";
            label3.Size = new Size(36, 18);
            label3.TabIndex = 41;
            label3.Text = "Nit:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(414, 88);
            label2.Name = "label2";
            label2.Size = new Size(73, 18);
            label2.TabIndex = 40;
            label2.Text = "Nombre:";
            // 
            // comboTipoGasB4
            // 
            comboTipoGasB4.FormattingEnabled = true;
            comboTipoGasB4.Location = new Point(683, 176);
            comboTipoGasB4.Margin = new Padding(3, 2, 3, 2);
            comboTipoGasB4.Name = "comboTipoGasB4";
            comboTipoGasB4.Size = new Size(133, 23);
            comboTipoGasB4.TabIndex = 39;
            // 
            // txtNombreB4
            // 
            txtNombreB4.Location = new Point(682, 88);
            txtNombreB4.Margin = new Padding(3, 2, 3, 2);
            txtNombreB4.Name = "txtNombreB4";
            txtNombreB4.Size = new Size(134, 23);
            txtNombreB4.TabIndex = 38;
            // 
            // dataGridViewB4
            // 
            dataGridViewB4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewB4.Location = new Point(15, 56);
            dataGridViewB4.Margin = new Padding(3, 2, 3, 2);
            dataGridViewB4.Name = "dataGridViewB4";
            dataGridViewB4.RowHeadersWidth = 51;
            dataGridViewB4.Size = new Size(340, 281);
            dataGridViewB4.TabIndex = 37;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bomba_4;
            pictureBox1.Location = new Point(889, 56);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(293, 281);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // btnSalirB4
            // 
            btnSalirB4.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalirB4.Location = new Point(643, 337);
            btnSalirB4.Margin = new Padding(3, 2, 3, 2);
            btnSalirB4.Name = "btnSalirB4";
            btnSalirB4.Size = new Size(96, 29);
            btnSalirB4.TabIndex = 35;
            btnSalirB4.Text = "Salir";
            btnSalirB4.UseVisualStyleBackColor = true;
            btnSalirB4.Click += btnSalirB4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(590, 29);
            label1.Name = "label1";
            label1.Size = new Size(133, 18);
            label1.TabIndex = 34;
            label1.Text = "Datos del cliente";
            // 
            // FBomba4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1198, 420);
            Controls.Add(label7);
            Controls.Add(btnDespacharB4);
            Controls.Add(btnGuardarClienteB4);
            Controls.Add(txtCantidadAbasB4);
            Controls.Add(comboTipoAbasB4);
            Controls.Add(txtNitB4);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboTipoGasB4);
            Controls.Add(txtNombreB4);
            Controls.Add(dataGridViewB4);
            Controls.Add(pictureBox1);
            Controls.Add(btnSalirB4);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FBomba4";
            Text = "FBomba4";
            ((System.ComponentModel.ISupportInitialize)dataGridViewB4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Button btnDespacharB4;
        private Button btnGuardarClienteB4;
        private TextBox txtCantidadAbasB4;
        private ComboBox comboTipoAbasB4;
        private TextBox txtNitB4;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboTipoGasB4;
        private TextBox txtNombreB4;
        private DataGridView dataGridViewB4;
        private PictureBox pictureBox1;
        private Button btnSalirB4;
        private Label label1;
    }
}