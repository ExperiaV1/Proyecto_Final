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
            label1.Location = new Point(498, 38);
            label1.Name = "label1";
            label1.Size = new Size(368, 29);
            label1.TabIndex = 0;
            label1.Text = "Tarifas de gasolina por galón";
            // 
            // btnGuardarGas
            // 
            btnGuardarGas.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarGas.Location = new Point(523, 451);
            btnGuardarGas.Name = "btnGuardarGas";
            btnGuardarGas.Size = new Size(127, 58);
            btnGuardarGas.TabIndex = 1;
            btnGuardarGas.Text = "Guardar Precios";
            btnGuardarGas.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.super;
            pictureBox1.Location = new Point(303, 125);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(169, 179);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Regular;
            pictureBox2.Location = new Point(588, 125);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(169, 179);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.Diesel;
            pictureBox3.Location = new Point(840, 125);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(169, 179);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // btnSalirPrecioGas
            // 
            btnSalirPrecioGas.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalirPrecioGas.Location = new Point(712, 451);
            btnSalirPrecioGas.Name = "btnSalirPrecioGas";
            btnSalirPrecioGas.Size = new Size(116, 58);
            btnSalirPrecioGas.TabIndex = 5;
            btnSalirPrecioGas.Text = "Salir";
            btnSalirPrecioGas.UseVisualStyleBackColor = true;
            btnSalirPrecioGas.Click += btnSalirPrecioGas_Click;
            // 
            // lblSuper
            // 
            lblSuper.AutoSize = true;
            lblSuper.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSuper.Location = new Point(369, 327);
            lblSuper.Name = "lblSuper";
            lblSuper.Size = new Size(67, 20);
            lblSuper.TabIndex = 6;
            lblSuper.Text = "label2";
            // 
            // lblRegular
            // 
            lblRegular.AutoSize = true;
            lblRegular.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegular.Location = new Point(650, 327);
            lblRegular.Name = "lblRegular";
            lblRegular.Size = new Size(67, 20);
            lblRegular.TabIndex = 7;
            lblRegular.Text = "label3";
            // 
            // lblDiesel
            // 
            lblDiesel.AutoSize = true;
            lblDiesel.Font = new Font("Gill Sans Ultra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiesel.Location = new Point(911, 327);
            lblDiesel.Name = "lblDiesel";
            lblDiesel.Size = new Size(67, 20);
            lblDiesel.TabIndex = 8;
            lblDiesel.Text = "label4";
            // 
            // txtSuper
            // 
            txtSuper.Location = new Point(329, 366);
            txtSuper.Name = "txtSuper";
            txtSuper.Size = new Size(125, 27);
            txtSuper.TabIndex = 9;
            // 
            // txtRegular
            // 
            txtRegular.Location = new Point(613, 366);
            txtRegular.Name = "txtRegular";
            txtRegular.Size = new Size(125, 27);
            txtRegular.TabIndex = 10;
            // 
            // txtDiesel
            // 
            txtDiesel.Location = new Point(872, 366);
            txtDiesel.Name = "txtDiesel";
            txtDiesel.Size = new Size(125, 27);
            txtDiesel.TabIndex = 11;
            // 
            // FPrecioGas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1368, 556);
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