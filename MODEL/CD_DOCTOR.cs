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
    public class CD_DOCTOR
    {

        //Instanciar la clase conexion
        private conexion conexion = new conexion();

        //Lineas de comando de conexion en sql server y visual studio
        SqlDataReader leerRegistros;
        DataTable tablaRegistros = new DataTable();
        SqlCommand ejecutar = new SqlCommand();

        //Metodos de conexion hacia la base de datos
        public DataTable listarEspecialidad()
        {
            ejecutar.Connection = conexion.abrirConexion();
            ejecutar.CommandText = "listarESPECIALIDAD";
            ejecutar.CommandType = CommandType.StoredProcedure;
            leerRegistros = ejecutar.ExecuteReader();
            tablaRegistros.Load(leerRegistros);
            leerRegistros.Close();
            conexion.cerrarConexion();
            return tablaRegistros;
        }

        public DataTable mostrarMedico()
        {

            ejecutar.Connection = conexion.abrirConexion();
            ejecutar.CommandText = "mostrarMEDICO";
            ejecutar.CommandType = CommandType.StoredProcedure;
            leerRegistros = ejecutar.ExecuteReader();
            tablaRegistros.Load(leerRegistros);
            leerRegistros.Close();
            conexion.cerrarConexion();
            return tablaRegistros;

        }

        //Metodo que envie los registros a la base de datos, enviados desde el controlador
        public void nuevoMedico(string codMedico, string nombre, string direccion, string correo, string telefono, int codEspecialidad)
        {
            ejecutar.Connection = conexion.abrirConexion();

            ejecutar.CommandText = "insertarMEDICO";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_medico", codMedico);
            ejecutar.Parameters.AddWithValue("@nombre", nombre);
            ejecutar.Parameters.AddWithValue("@direccion", direccion);
            ejecutar.Parameters.AddWithValue("@correo", correo);
            ejecutar.Parameters.AddWithValue("@telefono", telefono);
            ejecutar.Parameters.AddWithValue("@codigo_especialidad", codEspecialidad);
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

            ejecutar.CommandText = "eliminarMEDICO";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_medico", codigo);

            //Crear una nueva consulta
            ejecutar.ExecuteNonQuery();

            //Limpiar cada caracter
            ejecutar.Parameters.Clear();

            conexion.cerrarConexion();
        }

        //Metodo que actualice los datos en el procedimiento
        public void actualizarMedico(string codMedico, string nombre, string direccion, string correo, string telefono, string codEspecialidad)
        {
            ejecutar.Connection = conexion.abrirConexion();

            ejecutar.CommandText = "actualizarMEDICO";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_medico", codMedico);
            ejecutar.Parameters.AddWithValue("@nombre", nombre);
            ejecutar.Parameters.AddWithValue("@direccion", direccion);
            ejecutar.Parameters.AddWithValue("@correo", correo);
            ejecutar.Parameters.AddWithValue("@telefono", telefono);
            ejecutar.Parameters.AddWithValue("@codigo_especialidad", codEspecialidad);
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

            ejecutar.CommandText = "buscarMEDICO";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_medico", codigo);
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
