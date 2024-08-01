using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Librerias de las capas como librerias de conexion a Sql
using System.Data;
using System.Data.SqlClient;

namespace MODEL
{
    public class conexion
    {

        private SqlConnection ConexionBD = new SqlConnection("Server=localhost; DataBase=DBCLINICAMEDICA; Integrated Security=true");

        public SqlConnection abrirConexion()
        {
            if (ConexionBD.State == ConnectionState.Closed)
            {
                ConexionBD.Open();
            }
            return ConexionBD;
        }

        public SqlConnection cerrarConexion()
        {
            if (ConexionBD.State == ConnectionState.Closed)
            {
                ConexionBD.Close();
            }
            return ConexionBD;
        }

    }
}
