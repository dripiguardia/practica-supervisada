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
    public partial class Paciente : Form
    {
        //Variable
        private bool actualizarPaciente = false;
        public Paciente()
        {
            InitializeComponent();
            tlpMensaje.SetToolTip(this.btnGuardar, "Guardar");
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {

            Form1 regresar = new Form1();
            regresar.Show();
            Hide();

        }

        private void Paciente_Load(object sender, EventArgs e)
        {

            mostrarPaciente();
            mostrarTotalRegistros();

        }

        private void mostrarPaciente()
        {

            //Instanciar la clase CN_MARCAS 
            CN_PACIENTE myPaciente = new CN_PACIENTE();
            dgvRegistros.DataSource = myPaciente.Paciente();

        }
        public void mostrarTotalRegistros()
        {
            int totalRegistros = int.Parse(dgvRegistros.Rows.Count.ToString());
            txtTotal.Text = (totalRegistros - 1).ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //Instanciar la clase CN_MARCAS 
            CN_PACIENTE myPaciente = new CN_PACIENTE();

            //Condicion que active la variable para poder reguardar el registro
            if (actualizarPaciente == false)
            {
                try
                {
                    myPaciente.insertarPaciente(txtCodigo.Text, txtNombre.Text, txtDireccion.Text, txtTelefonoCasa.Text, txtTelefonoMovil.Text, txtDatos.Text, txtTelefonoEmergencia.Text, txtObservaciones.Text);
                    MessageBox.Show("Paciente Almacenada Correctamente");
                    mostrarPaciente();
                    mostrarTotalRegistros();
                    limpiarCampos();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al Almacenar Paciente");
                }
            }

            //Reguardar los registros
            if (actualizarPaciente == true)
            {
                try
                {
                    myPaciente.updatePaciente(txtCodigo.Text, txtNombre.Text, txtDireccion.Text, txtTelefonoCasa.Text, txtTelefonoMovil.Text, txtDatos.Text, txtTelefonoEmergencia.Text, txtObservaciones.Text);
                    MessageBox.Show("Paciente Almacenada Correctamente");

                    actualizarPaciente = false;
                    mostrarPaciente();
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
                actualizarPaciente = true;
                txtCodigo.Text = dgvRegistros.CurrentRow.Cells["codigo_paciente"].Value.ToString();
                txtNombre.Text = dgvRegistros.CurrentRow.Cells["nombre"].Value.ToString();
                txtDireccion.Text = dgvRegistros.CurrentRow.Cells["direccion"].Value.ToString();
                txtTelefonoCasa.Text = dgvRegistros.CurrentRow.Cells["telefono_casa"].Value.ToString();
                txtTelefonoMovil.Text = dgvRegistros.CurrentRow.Cells["telefono_movil"].Value.ToString();
                txtDatos.Text = dgvRegistros.CurrentRow.Cells["nombre_emergencia"].Value.ToString();
                txtTelefonoEmergencia.Text = dgvRegistros.CurrentRow.Cells["telefono_emergencia"].Value.ToString();
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
            CN_PACIENTE myPaciente = new CN_PACIENTE();
            if (dgvRegistros.SelectedRows.Count > 0)
            {
                txtCodigo.Text = dgvRegistros.CurrentRow.Cells["codigo_paciente"].Value.ToString();
                myPaciente.deletePaciente(txtCodigo.Text);
                MessageBox.Show("Registro eliminado correctamente");
                mostrarPaciente();
                mostrarTotalRegistros();
            }
            else
            {
                MessageBox.Show("Debe de Seleccionar un Registro");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            buscarPaciente();

        }

        private void buscarPaciente()
        {

            // Instanciar la clase CN_MARCAS();
            CN_PACIENTE myPac = new CN_PACIENTE();
            dgvRegistros.DataSource = myPac.searchPaciente(txtBuscar.Text);

        }

        //Metodo que limpie los campos
        private void limpiarCampos()
        {

            txtCodigo.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefonoCasa.Clear();
            txtTelefonoMovil.Clear();
            txtDatos.Clear();
            txtTelefonoEmergencia.Clear();
            txtObservaciones.Clear();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            //Instanciar la clase CN_MARCAS 
            CN_PACIENTE myPaciente = new CN_PACIENTE();
            dgvRegistros.DataSource = myPaciente.Paciente();

        }

        public void botonPaciente()
        {
            btnRegresar.Visible = false;
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
