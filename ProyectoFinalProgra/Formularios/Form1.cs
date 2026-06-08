using ProyectoFinalProgra.Formularios;

namespace ProyectoFinalProgra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBomba1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FBomba1 formFBomba1 = new FBomba1();
            formFBomba1.Show();
        }

        private void btnBomba2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FBomba2 formFBomba2 = new FBomba2();
            formFBomba2.Show();
        }

        private void btnBomba3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FBomba3 formFBomba3 = new FBomba3();
            formFBomba3.Show();
        }

        private void btnBomba4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FBomba4 formFBomba4 = new FBomba4();
            formFBomba4.Show();
        }

        private void btnEstadistica_Click(object sender, EventArgs e)
        {
            this.Hide();
            FEstadisticas formFEstadisticas = new FEstadisticas();
            formFEstadisticas.Show();
        }

        private void btnPrecioGas_Click(object sender, EventArgs e)
        {
            this.Hide();
            FPrecioGas formFPrecioGas = new FPrecioGas();
            formFPrecioGas.Show();
        }

        private void panCentral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDetener4_Click(object sender, EventArgs e)
        {

        }

        private void btnBomba1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
