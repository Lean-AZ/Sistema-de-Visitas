using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;

namespace Capa_Datos
{   
    // Interfaz que define las operaciones CRUD para el repositorio de aulas
    public interface IAulaRepository
    { //los metodos
        void AgregarAula(string nombre, int edificioId);
        void ModificarAula(int id, string nombre, int edificioId);
        void EliminarAula(int id);
        Aula BuscarAula(int id);
        List<Aula> ObtenerTodasLasAulas();
    }
    // Implementación de la interfaz IAulaRepository
    public class AulaRepository : IAulaRepository
    {

        // Agrega un nuevo aula a la base de datos
        public void AgregarAula(string nombre, int edificioId)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_AgregarAula", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@EdificioId", edificioId);

                dbConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }

        // Modifica un aula existente en la base de datos
        public void ModificarAula(int id, string nombre, int edificioId)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_ModificarAula", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@EdificioId", edificioId);

                dbConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }

        // Elimina un aula existente en la base de datos
        public void EliminarAula(int id)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_EliminarAula", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                dbConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }

        // Busca un aula específica en la base de datos
        public Aula BuscarAula(int id)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_BuscarAula", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Aula
                        {
                            IdAula = (int)reader["Id"],
                            NombreAula = (string)reader["Nombre"],
                            EdificioIdAula = (int)reader["EdificioId"]
                        };
                    }
                    else
                    {
                        return null; // No se encontró el aula
                    }
                }
            }
            finally
            {
                dbConnection.Close();
            }
        }
        // Obtiene una lista de todas las aulas en la base de datos
        public List<Aula> ObtenerTodasLasAulas()
        {
            var aulas = new List<Aula>();
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_ObtenerTodasLasAulas", connection);
                command.CommandType = CommandType.StoredProcedure;

                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var aula = new Aula
                        {
                            IdAula = (int)reader["Id"],
                            NombreAula = (string)reader["Nombre"],
                            EdificioIdAula = (int)reader["EdificioId"]
                        };
                        aulas.Add(aula);
                    }
                }
            }
            finally
            {
                dbConnection.Close();
            }

            return aulas;
        }

    }
    }
    

    // Clase para representar un aula

