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
    public class CD_RECETA
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

        //Metodo de conexion hacia la base de datos        
        public DataTable mostrarRecetas()
        {

            ejecutar.Connection = conexion.abrirConexion();
            ejecutar.CommandText = "mostrarRECETA";
            ejecutar.CommandType = CommandType.StoredProcedure;
            leerRegistros = ejecutar.ExecuteReader();
            tablaRegistros.Load(leerRegistros);
            leerRegistros.Close();
            conexion.cerrarConexion();
            return tablaRegistros;

        }

        //Metodo que envie los registros a la base de datos, enviados desde el controlador
        public void nuevaReceta(string codigo, int codMedico, int codPaciente, string descripcion, string dosis, string fecha)
        {
            
            ejecutar.Connection = conexion.abrirConexion();

            ejecutar.CommandText = "insertarRECETA";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@numero_receta", codigo);
            ejecutar.Parameters.AddWithValue("@codigo_medico", codMedico);
            ejecutar.Parameters.AddWithValue("@codigo_paciente", codPaciente);
            ejecutar.Parameters.AddWithValue("@descripcion", descripcion);
            ejecutar.Parameters.AddWithValue("@dosis", dosis);
            ejecutar.Parameters.AddWithValue("@fecha_extension", fecha);

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

            ejecutar.CommandText = "eliminarRECETA";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@numero_receta", codigo);

            //Crear una nueva consulta
            ejecutar.ExecuteNonQuery();

            //Limpiar cada caracter
            ejecutar.Parameters.Clear();

            conexion.cerrarConexion();
        }

        //Metodo que actualice los datos en el procedimiento
        public void actualizarReceta(string codigo, string codMedico, string codPaciente, string descripcion, string dosis, string fecha)
        {
            ejecutar.Connection = conexion.abrirConexion();

            ejecutar.CommandText = "actualizarRECETA";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@numero_receta", codigo);
            ejecutar.Parameters.AddWithValue("@codigo_medico", codMedico);
            ejecutar.Parameters.AddWithValue("@codigo_paciente", codPaciente);
            ejecutar.Parameters.AddWithValue("@descripcion", descripcion);
            ejecutar.Parameters.AddWithValue("@dosis", dosis);
            ejecutar.Parameters.AddWithValue("@fecha_extension", fecha);
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

            ejecutar.CommandText = "buscarRECETA";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@numero_receta", codigo);
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
