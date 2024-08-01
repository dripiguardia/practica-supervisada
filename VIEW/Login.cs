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
    public partial class Login : Form
    {
        //Variables-------------
        String user, contraseña;

        int intentos = 1;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            chkMedico.Checked = false;
            chkUsuario.Checked = false;

            lbUsuario.Visible = true;
            lbContrasena.Visible = true;
            txtContraseña.Visible = true;
            txtUsuario.Visible = true;
            btnIngresar.Visible = true;

        }

        private void chkMedico_CheckedChanged(object sender, EventArgs e)
        {

            chkUsuario.Checked = false;

            lbUsuario.Visible = true;
            lbContrasena.Visible = true;
            txtContraseña.Visible = true;
            txtUsuario.Visible = true;
            btnIngresar.Visible = true;

        }

        private void chkUsuario_CheckedChanged(object sender, EventArgs e)
        {

            chkAdmin.Checked = false;
            chkMedico.Checked = false;
            btnIngresar.Visible = true;

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {

            DialogResult respuesta;
            respuesta = MessageBox.Show("Desea salir del sistema", "DB", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

           if (chkUsuario.Checked == true) 
            {

                Paciente paciente = new Paciente();
                paciente.botonPaciente();
                paciente.Show();
                Hide();

            }
            else       
            {
                if (chkAdmin.Checked == true) 
                {

                    if (intentos == 3)
                    {
                        MessageBox.Show("Ah iniciado incrrectamente 3 veces");
                        Application.Exit();
                    }
                    else
                    {
                        user = txtUsuario.Text;
                        contraseña = txtContraseña.Text;
                        if ((user.Equals("Daniel Iguardia")) && (contraseña.Equals("202020")))
                        {
                        
                            Form1 menu = new Form1();
                            menu.Show();
                            this.Hide();
                            menu.Text = "Bienevenido " + user;
  
                        }
                        else
                        {
                            MessageBox.Show("Datos incorrectos, le restan " + (3 - intentos) + " intentos");
                            limpiar();
                            intentos++;
                        }
                    }

                }

            }
            if (chkMedico.Checked == true)
            {

                if (intentos == 3)
                {
                    MessageBox.Show("Ah iniciado incorrectamente 3 veces");
                    Application.Exit();
                }
                else
                {
                    user = txtUsuario.Text;
                    contraseña = txtContraseña.Text;
                    if ((user.Equals("Doc")) && (contraseña.Equals("123")))
                    {

                        Doctor menu = new Doctor();
                        menu.botonMedico();
                        menu.Show();
                        this.Hide();
                        menu.Text = "Bienevenido " + user;
                                                
                    }
                    else
                    {
                        MessageBox.Show("Datos incorrectos, le restan " + (3 - intentos) + " intentos");
                        limpiar();
                        intentos++;
                    }
                }
            }
        }

        private void limpiar()
        {

            txtUsuario.Clear();
            txtContraseña.Clear();
            txtUsuario.Focus();

        }

    }
}
