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
    public class CN_RECETA
    {

        //Instanciar la clase CD_MARCAS 
        private CD_RECETA myReceta = new CD_RECETA();

        public DataTable Receta()
        {
            DataTable tableReg = new DataTable();
            tableReg = myReceta.mostrarRecetas();
            return tableReg;
        }

        //Metodo que convierte los datos ingresados en las cajas de texto para ser enviados a la capa modelo
        public void insertarReceta(string codigo, string codMedico, string codPaciente, string descripcion, string dosis, string fecha)
        {
            myReceta.nuevaReceta(codigo, Convert.ToInt32(codMedico), Convert.ToInt32(codPaciente), descripcion, dosis, fecha);
        }

        //Extraer el dato de la caja de texto para poder ser evaluada en el modelo
        public void deleteReceta(string numReceta)
        {
            myReceta.eliminarRegistro(Convert.ToInt32(numReceta));
        }

        //Captura los datos en las cajas de texto para enviar nuevo valores
        public void updateReceta(string codigo, string codMedico, string codPaciente, string descripcion, string dosis, string fecha)
        {
            myReceta.actualizarReceta(codigo, codMedico, codPaciente, descripcion, dosis, fecha);
        }

        //Extraer el dato de la caja de texto para poder ser evaluada en el modelo
        public DataTable searchReceta(string codReceta)
        {

            DataTable tableReg = new DataTable();
            tableReg = myReceta.buscarRegistro(Convert.ToInt32(codReceta));
            return tableReg;

        }

    }
}
