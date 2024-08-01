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
    public partial class Cita : Form
    {

        //Variable
        private bool actualizarCita = false;
        public Cita()
        {
            InitializeComponent();
            tlpMensaje.SetToolTip(this.btnGuardar, "Guardar");
        }

        //metodo para mostrar los pacientes en un combobox
        private void listarPaciente()
        {

            CD_CITA myPaciente = new CD_CITA();
            cbPaciente.DataSource = myPaciente.listarPaciente();
            cbPaciente.DisplayMember = "nombre";
            cbPaciente.ValueMember = "codigo_paciente";

        }

        //metodo para mostrar los pacientes en un combobox
        private void listarMedico()
        {

            CD_CITA myMedico = new CD_CITA();
            cbMedico.DataSource = myMedico.listarMedico();
            cbMedico.DisplayMember = "nombre";
            cbMedico.ValueMember = "codigo_medico";

        }

        //metodo para mostrar los pacientes en un combobox
        private void listarMedio()
        {

            CD_CITA myMedio = new CD_CITA();
            cbMedio.DataSource = myMedio.listarMedio();
            cbMedio.DisplayMember = "descripcion";
            cbMedio.ValueMember = "codigo_medio";

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {

            Form1 regresar = new Form1();
            regresar.Show();
            Hide();

        }

        private void Cita_Load(object sender, EventArgs e)
        {
            listarPaciente();
            listarMedico();
            listarMedio();
            mostrarCita();
            mostrarTotalRegistros();
            limpiarCampos();

        }

        private void mostrarCita()
        {

            //Instanciar la clase CN_MARCAS 
            CN_CITA myCita = new CN_CITA();
            dgvRegistros.DataSource = myCita.Cita();

        }
        public void mostrarTotalRegistros()
        {
            int totalRegistros = int.Parse(dgvRegistros.Rows.Count.ToString());
            txtTotal.Text = (totalRegistros - 1).ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //Instanciar la clase CN_MARCAS 
            CN_CITA myCita = new CN_CITA();
            //Condicion que active la variable para poder reguardar el registro
            if (actualizarCita == false)
            {
                try
                {
                    myCita.insertarCita(txtCita.Text, Convert.ToString(cbPaciente.SelectedValue), Convert.ToString(cbMedico.SelectedValue), Convert.ToString(cbMedio.SelectedValue), txtFecha.Text, txtHora.Text, txtDatos.Text, txtObservaciones.Text);
                    MessageBox.Show("Cita Almacenada Correctamente");
                    mostrarCita();
                    mostrarTotalRegistros();
                    limpiarCampos();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Almacenar Cita");
                }
            }

            //Reguardar los registros
            if (actualizarCita == true)
            {
                try
                {
                    myCita.updateCita(txtCita.Text, Convert.ToString(cbPaciente.SelectedValue), Convert.ToString(cbMedico.SelectedValue), Convert.ToString(cbMedio.SelectedValue), txtFecha.Text, txtHora.Text, txtDatos.Text, txtObservaciones.Text);
                    MessageBox.Show("Medico actualiado correctamente");

                    actualizarCita = false;
                    mostrarCita();
                    limpiarCampos();
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
                actualizarCita = true;
                txtCita.Text = dgvRegistros.CurrentRow.Cells["codigo_cita"].Value.ToString();
                cbPaciente.Text = dgvRegistros.CurrentRow.Cells["nombre"].Value.ToString();
                cbMedico.Text = dgvRegistros.CurrentRow.Cells["nombre_medico"].Value.ToString();
                cbMedio.Text = dgvRegistros.CurrentRow.Cells["descripcion"].Value.ToString();
                txtFecha.Text = dgvRegistros.CurrentRow.Cells["fecha"].Value.ToString();
                txtHora.Text = dgvRegistros.CurrentRow.Cells["hora"].Value.ToString();
                txtDatos.Text = dgvRegistros.CurrentRow.Cells["datos_receta"].Value.ToString();
                txtObservaciones.Text = dgvRegistros.CurrentRow.Cells["observaciones"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe de Seleccionar un Registro");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            // Instanciar la clase CN_MARCAS();
            CN_CITA myCita = new CN_CITA();
            if (dgvRegistros.SelectedRows.Count > 0)
            {
                txtCita.Text = dgvRegistros.CurrentRow.Cells["codigo_cita"].Value.ToString();
                myCita.deleteCita(txtCita.Text);
                MessageBox.Show("Registro eliminado correctamente");
                mostrarCita();
                mostrarTotalRegistros();
            }
            else
            {
                MessageBox.Show("Debe de Seleccionar un Registro");
            }

        }

        //Metodo que limpie los campos
        private void limpiarCampos()
        {

            txtCita.Clear();
            cbPaciente.Text = "Click Aqui";
            cbMedico.Text = "Click Aqui";
            cbMedio.Text = "Click Aqui";
            txtFecha.Clear();
            txtHora.Clear();
            txtDatos.Clear();
            txtObservaciones.Clear();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            buscarCita();

        }

        private void buscarCita()
        {

            // Instanciar la clase CN_MARCAS();
            CN_CITA myCita = new CN_CITA();
            dgvRegistros.DataSource = myCita.searchCita(txtBuscar.Text);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            //Instanciar la clase CN_MARCAS 
            CN_CITA myCita = new CN_CITA();
            dgvRegistros.DataSource = myCita.Cita();

        }

        public void botonCita()
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

        private void recetaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Receta receta = new Receta();
            receta.botonReceta();
            receta.Show();
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
