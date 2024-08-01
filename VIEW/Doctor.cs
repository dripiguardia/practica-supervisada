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
    public partial class Doctor : Form
    {

        //Variable
        private bool actualizarMedico = false;
        public Doctor()
        {
            InitializeComponent();
            tlpMensaje.SetToolTip(this.btnGuardar, "Guardar");

        }

        //metodo para mostrar los empleados en un combobox
        private void listarEspecialidad()
        {

            CD_DOCTOR myEspecialidad = new CD_DOCTOR();
            cbEspecialidad.DataSource = myEspecialidad.listarEspecialidad();
            cbEspecialidad.DisplayMember = "especialidad";
            cbEspecialidad.ValueMember = "codigo_especialidad";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 regresar = new Form1();
            regresar.Show();
            Hide();

        }

        private void Doctor_Load(object sender, EventArgs e)
        {

            listarEspecialidad();
            mostrarMedico();
            mostrarTotalRegistros();
            LimpiarCampos();

        }
        private void mostrarMedico()
        {

            //Instanciar la clase CN_MARCAS 
            CN_DOCTOR myDoctor = new CN_DOCTOR();
            dgvRegistros.DataSource = myDoctor.Medico();

        }
        public void mostrarTotalRegistros()
        {
            int totalRegistros = int.Parse(dgvRegistros.Rows.Count.ToString());
            txtTotal.Text = (totalRegistros - 1).ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //Instanciar la clase CN_MARCAS 
            CN_DOCTOR myDoctor = new CN_DOCTOR();


            if (actualizarMedico == false)
            {
                try
                {
                    myDoctor.insertarMedico(txtCodigo.Text, txtNombre.Text, txtDireccion.Text, txtCorreo.Text, txtTelefonoMovil.Text, Convert.ToString(cbEspecialidad.SelectedValue));
                    MessageBox.Show("Paciente Almacenada Correctamente");
                    mostrarMedico();
                    mostrarTotalRegistros();
                    LimpiarCampos();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Almacenar Paciente");
                }
                mostrarMedico();
            }

            //Reguardar los registros
            if (actualizarMedico == true)
            {
                try
                {
                    myDoctor.updateMedico(txtCodigo.Text, txtNombre.Text, txtDireccion.Text, txtCorreo.Text, txtTelefonoMovil.Text, Convert.ToString(cbEspecialidad.SelectedValue));
                    MessageBox.Show("Medico actualiado correctamente");

                    actualizarMedico = false;
                    mostrarMedico();
                    LimpiarCampos();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Almacenar Paciente");
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            // Instanciar la clase CN_MARCAS();
            CN_DOCTOR myDoctor = new CN_DOCTOR();
            if (dgvRegistros.SelectedRows.Count > 0)
            {
                txtCodigo.Text = dgvRegistros.CurrentRow.Cells["codigo_medico"].Value.ToString();
                myDoctor.deleteMedico(txtCodigo.Text);
                MessageBox.Show("Registro eliminado correctamente");
                mostrarMedico();
                mostrarTotalRegistros();
            }
            else
            {
                MessageBox.Show("Debe de Seleccionar un Registro");
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (dgvRegistros.SelectedRows.Count > 0)
            {
                //cambiar el valor a la variable actualizar
                actualizarMedico = true;
                txtCodigo.Text = dgvRegistros.CurrentRow.Cells["codigo_medico"].Value.ToString();
                txtNombre.Text = dgvRegistros.CurrentRow.Cells["nombre"].Value.ToString();
                txtDireccion.Text = dgvRegistros.CurrentRow.Cells["direccion"].Value.ToString();
                txtCorreo.Text = dgvRegistros.CurrentRow.Cells["correo"].Value.ToString();
                txtTelefonoMovil.Text = dgvRegistros.CurrentRow.Cells["telefono"].Value.ToString();
                cbEspecialidad.Text = dgvRegistros.CurrentRow.Cells["especialidad"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Debe de Seleccionar un Registro");
            }

        }

        //Metodo que limpie los campos
        private void LimpiarCampos()
        {

            txtCodigo.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            txtTelefonoMovil.Clear();
            cbEspecialidad.Text = "Click Aqui";

        }

        public void botonMedico()
        {

            btnRegresar.Visible = false;

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {

            buscarMedico();

        }

        private void buscarMedico()
        {

            // Instanciar la clase CN_MARCAS();
            CN_DOCTOR myMedico = new CN_DOCTOR();
            dgvRegistros.DataSource = myMedico.searchMedico(txtBuscar.Text);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            //Instanciar la clase CN_MARCAS 
            CN_DOCTOR myDoctor = new CN_DOCTOR();
            dgvRegistros.DataSource = myDoctor.Medico();

        }

        private void recetaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Receta receta = new Receta();
            receta.botonReceta();
            receta.Show();
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