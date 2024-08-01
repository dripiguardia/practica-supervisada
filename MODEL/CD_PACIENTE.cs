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
    public class CD_PACIENTE
    {

        //Instanciar la clase conexion
        private conexion conexion = new conexion();

        //Lineas de comando de conexion en sql server y visual studio
        SqlDataReader leerRegistros;
        DataTable tablaRegistros = new DataTable();
        SqlCommand ejecutar = new SqlCommand();

        //Metodo de conexion hacia la base de datos
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

        //Metodo que envie los registros a la base de datos, enviados desde el controlador
        public void nuevoPaciente(int codigo, string nombre, string direccion, string telefonocasa, string telefonomovil, string emergencia, string telefonoemergencia, string observaciones)
        {
            ejecutar.Connection = conexion.abrirConexion();

            ejecutar.CommandText = "insertarPACIENTE";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_paciente", codigo);
            ejecutar.Parameters.AddWithValue("@nombre", nombre);
            ejecutar.Parameters.AddWithValue("@direccion", direccion);
            ejecutar.Parameters.AddWithValue("@telefono_casa", telefonocasa);
            ejecutar.Parameters.AddWithValue("@telefono_movil", telefonomovil);
            ejecutar.Parameters.AddWithValue("@nombre_emergencia", emergencia);
            ejecutar.Parameters.AddWithValue("@telefono_emergencia", telefonoemergencia);
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

            ejecutar.CommandText = "eliminarPACIENTE";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_paciente", codigo);

            //Crear una nueva consulta
            ejecutar.ExecuteNonQuery();

            //Limpiar cada caracter
            ejecutar.Parameters.Clear();

            conexion.cerrarConexion();
        }

        //Metodo que actualice los datos en el procedimiento
        public void actualizarPaciente(int codigo, string nombre, string direccion, string telefonocasa, string telefonomovil, string emergencia, string telefonoemergencia, string observaciones)
        {
            ejecutar.Connection = conexion.abrirConexion();

            ejecutar.CommandText = "actualizarPACIENTE";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_paciente", codigo);
            ejecutar.Parameters.AddWithValue("@nombre", nombre);
            ejecutar.Parameters.AddWithValue("@direccion", direccion);
            ejecutar.Parameters.AddWithValue("@telefono_casa", telefonocasa);
            ejecutar.Parameters.AddWithValue("@telefono_movil", telefonomovil);
            ejecutar.Parameters.AddWithValue("@nombre_emergencia", emergencia);
            ejecutar.Parameters.AddWithValue("@telefono_emergencia", telefonoemergencia);
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

            ejecutar.CommandText = "buscarPACIENTE";
            ejecutar.CommandType = CommandType.StoredProcedure;
            ejecutar.Parameters.AddWithValue("@codigo_paciente", codigo);
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
