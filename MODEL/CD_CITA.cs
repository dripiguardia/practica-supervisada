using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Invocar las librerias de sql Server
using System.Data;
using System.Data.SqlClient;

namespace MODEL
{
    public class CD_CITA
    {

        //Instanciar la clase conexion
        private conexion conexion = new conexion();

        //Lineas de comando de conexion en sql server y visual studio
        SqlDataReader leerRegistros;
        DataTable tablaRegistros = new DataTable();
        SqlCommand ejecutar = new SqlCommand();

        //Metodos de conexion hacia la base de datos
        public DataTable listarPaciente()
        {
            ejecutar.Connection = conexion.abrirConexion();
            ejecutar.CommandText = "listarPACIENTE";
            ejecutar.CommandType = CommandType.StoredProcedure;
            leerRegistros = ejecutar.ExecuteReader();
            tablaRegistros.Load(leerRegistros);
            leerRegistros.Close();
            conexion.cerrarConexion();
            return tablaRegistros;
        }

        //Metodos de conexion hacia la base de datos
        public DataTable listarMedico()
        {
            ejecutar.Connection = conexion.abrirConexion();
            ejecutar.CommandText = "listarMEDICO";
            ejecutar.CommandType = CommandType.StoredProcedure;
            leerRegistros = ejecutar.ExecuteReader();
            tablaRegistros.Load(leerRegistros);
            leerRegistros.Close();
            conexion.cerrarConexion();
            return tablaRegistros;
        }

        //Metodos de conexion hacia la base de datos
        public DataTable listarMedio()
        {
            ejecutar.Connection = conexion.abrirConexion();
            ejecutar.CommandText = "listarMEDIO";
            ejecutar.CommandType = CommandType.StoredProcedure;
            leerRegistros = ejecutar.ExecuteReader();
            tablaRegistros.Load(leerRegistros);
            leerRegistros.Close();
            conexion.cerrarConexion();
            return tablaRegistros;
        }

        //Metodo de conexion hacia la base de datos
        public DataTable listarCita()
        {

            ejecutar.Connection = conexion.abrirConexion();
            ejecutar.CommandText = "mostrarCITA";
            ejecutar.CommandType = CommandType.StoredProcedure;
            leerRegistros = ejecutar.ExecuteReader();
            tablaRegistros.Load(leerRegistros);
            leerRegistros.Close();
            conexion.cerrarConexion();
            return tablaRegistros;

        }

        //Metodo que envie los registros a la base de datos, enviados desde el controlador
        public void nuevaCita(string codCita, int codPaciente,  int codMedico, int codMedio, string fecha, string hora, string datos, string observaciones)
        {
            ejecutar.Connection = conexion.abrirConexion();

            ejecutar.CommandText = "insertarCITA";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_cita", codCita);
            ejecutar.Parameters.AddWithValue("@codigo_paciente", codPaciente);
            ejecutar.Parameters.AddWithValue("@codigo_medico", codMedico);
            ejecutar.Parameters.AddWithValue("@codigo_medio", codMedio);
            ejecutar.Parameters.AddWithValue("@fecha", fecha);
            ejecutar.Parameters.AddWithValue("@hora", hora);
            ejecutar.Parameters.AddWithValue("@datos_receta", datos);
            ejecutar.Parameters.AddWithValue("@observaciones", observaciones);

            //Crear una nueva consulta
            ejecutar.ExecuteNonQuery();

            //Limpiar cada caracter
            ejecutar.Parameters.Clear();

            conexion.cerrarConexion();
        }

        //Metodo que envie el codigo para eliminar el registro en la base de datos
        public void eliminarRegistro(int codigo)
        {
            ejecutar.Connection = conexion.abrirConexion();

            ejecutar.CommandText = "eliminarCITA";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_cita", codigo);

            //Crear una nueva consulta
            ejecutar.ExecuteNonQuery();

            //Limpiar cada caracter
            ejecutar.Parameters.Clear();

            conexion.cerrarConexion();
        }

        //Metodo que actualice los datos en el procedimiento
        public void actualizarCita(string codCita, string codPaciente, string codMedico, string codMedio, string fecha, string hora, string datos, string observaciones)
        {
            ejecutar.Connection = conexion.abrirConexion();

            ejecutar.CommandText = "actualizarCITA";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_cita", codCita);
            ejecutar.Parameters.AddWithValue("@codigo_paciente", codPaciente);
            ejecutar.Parameters.AddWithValue("@codigo_medico", codMedico);
            ejecutar.Parameters.AddWithValue("@codigo_medio", codMedio);
            ejecutar.Parameters.AddWithValue("@fecha", fecha);
            ejecutar.Parameters.AddWithValue("@hora", hora);
            ejecutar.Parameters.AddWithValue("@datos_receta", datos);
            ejecutar.Parameters.AddWithValue("@observaciones", observaciones);
            //Crear una nueva consulta
            ejecutar.ExecuteNonQuery();

            //Limpiar cada caracter
            ejecutar.Parameters.Clear();

            conexion.cerrarConexion();

        }

        //Metodo que envie el codigo para eliminar el registro en la base de datos
        public DataTable buscarRegistro(int codigo)
        {
            ejecutar.Connection = conexion.abrirConexion();

            ejecutar.CommandText = "buscarCITA";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_cita", codigo);
            leerRegistros = ejecutar.ExecuteReader();
            tablaRegistros.Load(leerRegistros);
            leerRegistros.Close();

            conexion.cerrarConexion();
            return tablaRegistros;

            //Crear una nueva consulta
            ejecutar.ExecuteNonQuery();

            //Limpiar cada caracter
            ejecutar.Parameters.Clear();

            conexion.cerrarConexion();
        }

    }
}
