
using MODEL;

namespace VIEW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            conexion conexion = new conexion();

            conexion.abrirConexion();
            MessageBox.Show("La conexion es exitosa");

        }

        private void btnCita_Click(object sender, EventArgs e)
        {

            Cita cita = new Cita();
            cita.Show();
            this.Hide();
       

        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {

            Doctor doctor = new Doctor();
            doctor.Show();
            this.Hide();

        }

        private void btnReceta_Click(object sender, EventArgs e)
        {

            Receta receta = new Receta();
            receta.Show();
            this.Hide();


        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {

            Paciente paciente = new Paciente();
            paciente.Show();
            Hide();

        }


        public void botonPaciente()
        {

            btnPaciente.Visible = false;  

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Login log = new Login();
            DialogResult respuesta;
            respuesta = MessageBox.Show("Desea salir del sistema", "DB", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (respuesta == DialogResult.Yes)
            {
                log.Show();
                this.Hide();
            }

        }
    }
}