using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Invocar las librerias de sql Server
using System.Data;
using System.Data.SqlClient;

//Capas
using MODEL;

namespace CONTROLLER
{
    public class CN_DOCTOR
    {

        //Instanciar la clase CD_MARCAS 
        private CD_DOCTOR myMedico = new CD_DOCTOR();

        public DataTable Medico()
        {
            DataTable tableReg = new DataTable();
            tableReg = myMedico.mostrarMedico();
            return tableReg;
        }

        //Metodo que convierte los datos ingresados en las cajas de texto para ser enviados a la capa modelo
        public void insertarMedico(string codMedico, string nombre, string direccion, string correo, string telefono, string codEspecialidad)
        {

            myMedico.nuevoMedico(codMedico, nombre, direccion, correo, telefono, Convert.ToInt32(codEspecialidad));

        }

        //Extraer el dato de la caja de texto para poder ser evaluada en el modelo
        public void deleteMedico(string codMedico)
        {
            myMedico.eliminarRegistro(Convert.ToInt32(codMedico));
        }

        public void updateMedico(string codMedico, string nombre, string direccion, string correo, string telefono, string codEspecialidad)
        {

            myMedico.actualizarMedico(codMedico, nombre, direccion, correo, telefono, codEspecialidad);

        }

        //Extraer el dato de la caja de texto para poder ser evaluada en el modelo
        public DataTable searchMedico(string codCita)
        {
            DataTable tableReg = new DataTable();
            tableReg = myMedico.buscarRegistro(Convert.ToInt32(codCita));
            return tableReg;
        }

    }
}
