using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Capa_Datos
{
    // Esta clase maneja la conexión a la base de datos utilizando SqlConnection.

    public class DatabaseConnection
    {
        private SqlConnection _connection;

        public DatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conectar"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public void Open()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void Close()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
