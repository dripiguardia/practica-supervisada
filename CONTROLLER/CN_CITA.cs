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
    public class CN_CITA
    {

        //Instanciar la clase CD_MARCAS 
        private CD_CITA myCita = new CD_CITA();

        public DataTable Cita()
        {
            DataTable tableReg = new DataTable();
            tableReg = myCita.listarCita();
            return tableReg;
        }

        //Metodo que convierte los datos ingresados en las cajas de texto para ser enviados a la capa modelo
        public void insertarCita(string codCita, string codPaciente, string codMedico, string codMedio, string fecha, string hora, string datos, string observaciones)
        {
            myCita.nuevaCita(codCita, Convert.ToInt32(codPaciente), Convert.ToInt32(codMedico), Convert.ToInt32(codMedio), fecha, hora, datos, observaciones);
        }

        //Extraer el dato de la caja de texto para poder ser evaluada en el modelo
        public void deleteCita(string codCita)
        {
            myCita.eliminarRegistro(Convert.ToInt32(codCita));
        }

        //Captura los datos en las cajas de texto para enviar nuevo valores
        public void updateCita(string codCita, string codPaciente, string codMedico, string codMedio, string fecha, string hora, string datos, string observaciones)
        {
            myCita.actualizarCita(codCita, codPaciente, codMedico, codMedio, fecha, hora, datos, observaciones);
        }

        //Extraer el dato de la caja de texto para poder ser evaluada en el modelo
        public DataTable searchCita(string codCita)
        {
            DataTable tableReg = new DataTable();
            tableReg = myCita.buscarRegistro(Convert.ToInt32(codCita));
            return tableReg;
        }

    }
}
