using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Invocar las librerias de sql Server
using System.Data;
using System.Data.SqlClient;

//Capas
using MODEL;

namespace CONTROLLER
{
    public class CN_PACIENTE
    {

        //Instanciar la clase CD_MARCAS 
        private CD_PACIENTE myPaciente = new CD_PACIENTE();

        public DataTable Paciente()
        {
            DataTable tableReg = new DataTable();
            tableReg = myPaciente.listarPaciente();
            return tableReg;
        }

        //Metodo que convierte los datos ingresados en las cajas de texto para ser enviados a la capa modelo
        public void insertarPaciente(string codPaciente, string nomPaciente, string direccion, string telefonocasa, string telefonomovil, string nomEmergencia, string telefonoemergencia, string observaciones)
        {
            myPaciente.nuevoPaciente(Convert.ToInt32(codPaciente), nomPaciente, direccion, telefonocasa, telefonomovil, nomEmergencia, telefonoemergencia, observaciones );
        }

        //Extraer el dato de la caja de texto para poder ser evaluada en el modelo
        public void deletePaciente(string codPaciente)
        {
            myPaciente.eliminarRegistro(Convert.ToInt32(codPaciente));
        }

        //Captura los datos en las cajas de texto para enviar nuevo valores
        public void updatePaciente(string codPaciente, string nomPaciente, string direccion, string telefonocasa, string telefonomovil, string nomEmergencia, string telefonoemergencia, string observaciones)
        {
            myPaciente.actualizarPaciente(Convert.ToInt32(codPaciente), nomPaciente, direccion, telefonocasa, telefonomovil, nomEmergencia, telefonoemergencia, observaciones);
        }

        //Extraer el dato de la caja de texto para poder ser evaluada en el modelo
        public DataTable searchPaciente(string codPaciente)
        {
            DataTable tableReg = new DataTable();
            tableReg = myPaciente.buscarRegistro(Convert.ToInt32(codPaciente));
            return tableReg;
        }

    }
}
