namespace ProyectoFinalProgra.Formularios
{
    partial class FPrecioGas
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
            btnGuardarGas = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            btnSalirPrecioGas = new Button();
            lblSuper = new Label();
            lblRegular = new Label();
            lblDiesel = new Label();
            txtSuper = new TextBox();
            txtRegular = new TextBox();
            txtDiesel = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Gill Sans Ultra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(436, 28);
            label1.Name = "label1";
            label1.Size = new Size(294, 23);
            label1.TabIndex = 0;
            label1.Text = "Tarifas de gasolina por galón";
            // 
            // btnGuardarGas
            // 
            btnGuardarGas.AutoSize = true;
            btnGuardarGas.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarGas.Location = new Point(458, 338);
            btnGuardarGas.Margin = new Padding(3, 2, 3, 2);
            btnGuardarGas.Name = "btnGuardarGas";
            btnGuardarGas.Size = new Size(141, 44);
            btnGuardarGas.TabIndex = 1;
            btnGuardarGas.Text = "Guardar Precios";
            btnGuardarGas.UseVisualStyleBackColor = true;
            btnGuardarGas.Click += btnGuardarGas_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.super;
            pictureBox1.Location = new Point(265, 94);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(148, 134);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Regular;
            pictureBox2.Location = new Point(514, 94);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(148, 134);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Diesel;
            pictureBox3.Location = new Point(735, 94);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(148, 134);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // btnSalirPrecioGas
            // 
            btnSalirPrecioGas.AutoSize = true;
            btnSalirPrecioGas.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalirPrecioGas.Location = new Point(623, 338);
            btnSalirPrecioGas.Margin = new Padding(3, 2, 3, 2);
            btnSalirPrecioGas.Name = "btnSalirPrecioGas";
            btnSalirPrecioGas.Size = new Size(102, 44);
            btnSalirPrecioGas.TabIndex = 5;
            btnSalirPrecioGas.Text = "Salir";
            btnSalirPrecioGas.UseVisualStyleBackColor = true;
            btnSalirPrecioGas.Click += btnSalirPrecioGas_Click;
            // 
            // lblSuper
            // 
            lblSuper.AutoSize = true;
            lblSuper.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSuper.Location = new Point(323, 245);
            lblSuper.Name = "lblSuper";
            lblSuper.Size = new Size(53, 18);
            lblSuper.TabIndex = 6;
            lblSuper.Text = "Super";
            // 
            // lblRegular
            // 
            lblRegular.AutoSize = true;
            lblRegular.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegular.Location = new Point(569, 245);
            lblRegular.Name = "lblRegular";
            lblRegular.Size = new Size(68, 18);
            lblRegular.TabIndex = 7;
            lblRegular.Text = "Regular";
            // 
            // lblDiesel
            // 
            lblDiesel.AutoSize = true;
            lblDiesel.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiesel.Location = new Point(797, 245);
            lblDiesel.Name = "lblDiesel";
            lblDiesel.Size = new Size(52, 18);
            lblDiesel.TabIndex = 8;
            lblDiesel.Text = "Diesel";
            // 
            // txtSuper
            // 
            txtSuper.Location = new Point(288, 274);
            txtSuper.Margin = new Padding(3, 2, 3, 2);
            txtSuper.Name = "txtSuper";
            txtSuper.Size = new Size(110, 23);
            txtSuper.TabIndex = 9;
            // 
            // txtRegular
            // 
            txtRegular.Location = new Point(536, 274);
            txtRegular.Margin = new Padding(3, 2, 3, 2);
            txtRegular.Name = "txtRegular";
            txtRegular.Size = new Size(110, 23);
            txtRegular.TabIndex = 10;
            // 
            // txtDiesel
            // 
            txtDiesel.Location = new Point(763, 274);
            txtDiesel.Margin = new Padding(3, 2, 3, 2);
            txtDiesel.Name = "txtDiesel";
            txtDiesel.Size = new Size(110, 23);
            txtDiesel.TabIndex = 11;
            // 
            // FPrecioGas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1197, 417);
            Controls.Add(txtDiesel);
            Controls.Add(txtRegular);
            Controls.Add(txtSuper);
            Controls.Add(lblDiesel);
            Controls.Add(lblRegular);
            Controls.Add(lblSuper);
            Controls.Add(btnSalirPrecioGas);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnGuardarGas);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FPrecioGas";
            Text = "FPrecioGas";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnGuardarGas;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button btnSalirPrecioGas;
        private Label lblSuper;
        private Label lblRegular;
        private Label lblDiesel;
        private TextBox txtSuper;
        private TextBox txtRegular;
        private TextBox txtDiesel;
    }
}