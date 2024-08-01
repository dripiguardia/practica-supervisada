using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Librerias de las capas como librerias de conexion a Sql
using System.Data;
using System.Data.SqlClient;

//Capas
using MODEL;
using CONTROLLER;

namespace VIEW
{
    public partial class Receta : Form
    {
        //Variable
        private bool actualizarReceta = false;
        public Receta()
        {
            InitializeComponent();
            tlpMensaje.SetToolTip(this.btnGuardar, "Guardar");
        }

        //metodo para mostrar los pacientes en un combobox
        private void listarPaciente()
        {

            CD_RECETA myPaciente = new CD_RECETA();
            cbPaciente.DataSource = myPaciente.listarPaciente();
            cbPaciente.DisplayMember = "nombre";
            cbPaciente.ValueMember = "codigo_paciente";

        }

        //metodo para mostrar los pacientes en un combobox
        private void listarMedico()
        {

            CD_RECETA myMedico = new CD_RECETA();
            cbMedico.DataSource = myMedico.listarMedico();
            cbMedico.DisplayMember = "nombre";
            cbMedico.ValueMember = "codigo_medico";

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {

            Form1 regresar = new Form1();
            regresar.Show();
            Hide();

        }

        private void Receta_Load(object sender, EventArgs e)
        {

            listarPaciente();
            listarMedico();
            mostrarReceta();           
            mostrarTotalRegistros();
            limpiarCampos();

        }

        private void mostrarReceta()
        {

            //Instanciar la clase CN_MARCAS 
            CN_RECETA myReceta = new CN_RECETA();
            dgvRegistros.DataSource = myReceta.Receta();

        }
        public void mostrarTotalRegistros()
        {
            int totalRegistros = int.Parse(dgvRegistros.Rows.Count.ToString());
            txtTotal.Text = (totalRegistros - 1).ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            // Instanciar la clase CN_MARCAS();
            CN_RECETA myReceta = new CN_RECETA();
            if (dgvRegistros.SelectedRows.Count > 0)
            {
                txtReceta.Text = dgvRegistros.CurrentRow.Cells["numero_receta"].Value.ToString();
                myReceta.deleteReceta(txtReceta.Text);
                MessageBox.Show("Registro eliminado correctamente");
                mostrarReceta();
                mostrarTotalRegistros();
            }
            else
            {
                MessageBox.Show("Debe de Seleccionar un Registro");
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //Instanciar la clase CN_MARCAS 
            CN_RECETA myReceta = new CN_RECETA();
            //Condicion que active la variable para poder reguardar el registro
            if (actualizarReceta == false)
            {
                try
                {
                    myReceta.insertarReceta(txtReceta.Text, Convert.ToString(cbMedico.SelectedValue), Convert.ToString(cbPaciente.SelectedValue), txtDescripcion.Text, txtDosis.Text, txtFecha.Text);
                    MessageBox.Show("Receta Almacenada Correctamente");
                    mostrarReceta();
                    limpiarCampos();
                    mostrarTotalRegistros();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Almacenar Receta");
                }
            }

            //Reguardar los registros
            if (actualizarReceta == true)
            {
                try
                {
                    myReceta.updateReceta(txtReceta.Text, Convert.ToString(cbMedico.SelectedValue), Convert.ToString(cbPaciente.SelectedValue), txtDescripcion.Text, txtDosis.Text, txtFecha.Text);
                    MessageBox.Show("Medico actualiado correctamente");

                    actualizarReceta = false;
                    mostrarReceta();
                    limpiarCampos();
                    mostrarTotalRegistros();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Almacenar Paciente");
                }
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (dgvRegistros.SelectedRows.Count > 0)
            {
                //cambiar el valor a la variable actualizar
                actualizarReceta = true;
                txtReceta.Text = dgvRegistros.CurrentRow.Cells["numero_receta"].Value.ToString();
                cbMedico.Text = dgvRegistros.CurrentRow.Cells["nombre_medico"].Value.ToString();
                cbPaciente.Text = dgvRegistros.CurrentRow.Cells["nombre_paciente"].Value.ToString();
                txtDescripcion.Text = dgvRegistros.CurrentRow.Cells["descripcion"].Value.ToString();
                txtDosis.Text = dgvRegistros.CurrentRow.Cells["dosis"].Value.ToString();
                txtFecha.Text = dgvRegistros.CurrentRow.Cells["fecha_extension"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe de Seleccionar un Registro");
            }

        }

        //Metodo que limpie los campos
        private void limpiarCampos()
        {

            txtReceta.Clear();
            cbMedico.Text = "Click Aqui";
            cbPaciente.Text = "Click Aqui";
            txtDescripcion.Clear();
            txtDosis.Clear();
            txtFecha.Clear();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            buscarReceta();

        }

        private void buscarReceta()
        {

            // Instanciar la clase CN_MARCAS();
            CN_RECETA myReceta = new CN_RECETA();
            dgvRegistros.DataSource = myReceta.searchReceta(txtBuscar.Text);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {


            //Instanciar la clase CN_MARCAS 
            CN_RECETA myReceta = new CN_RECETA();
            dgvRegistros.DataSource = myReceta.Receta();

        }

        public void botonReceta()
        {

            btnRegresar.Visible = false;


        }

        private void medicoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Doctor doc = new Doctor();
            doc.botonMedico();
            doc.Show();
            this.Hide();

        }

        private void citaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Cita cita = new Cita();
            cita.botonCita();
            cita.Show();
            this.Hide();

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
