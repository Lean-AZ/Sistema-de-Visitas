using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;

namespace Capa_Datos
{    // Interfaz que define las operaciones CRUD para el repositorio de Edificios
    public interface IEdificioRepository
    {  //los metodos
        void AgregarEdificio(string nombre);
        void ModificarEdificio(int id, string nombre);
        void EliminarEdificio(int id);
        Edificio BuscarEdificio(int id);
        List<Edificio> ObtenerTodosLosEdificios();

    }        // Implementación de la interfaz IAulaRepository
    public class EdificioRepository : IEdificioRepository
    {
        // Agrega un nuevo edificio a la base de datos
        public void AgregarEdificio(string nombre)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_AgregarEdificio", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", nombre);

                dbConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }
        // Modifica un edificio existente en la base de datos
        public void ModificarEdificio(int id, string nombre)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_ModificarEdificio", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", nombre);

                dbConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }

        // Elimina un edificio existente en la base de datos
        public void EliminarEdificio(int id)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_EliminarEdificio", connection);
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

        // Busca un edificio específico en la base de datos
        public Edificio BuscarEdificio(int id)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_BuscarEdificio", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Edificio
                        {
                            IdEdificio = (int)reader["Id"],
                            NombreEdificio = (string)reader["Nombre"]
                        };
                    }
                    else
                    {
                        return null; // No se encontró el edificio
                    }
                }
            }
            finally
            {
                dbConnection.Close();
            }
            
        }
        // Obtiene una lista de todos los edificios en la base de datos
        public List<Edificio> ObtenerTodosLosEdificios()
        {
            var edificios = new List<Edificio>();

            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_ObtenerTodosLosEdificios", connection); // Asume que tienes este procedimiento almacenado
                command.CommandType = CommandType.StoredProcedure;

                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var edificio = new Edificio
                        {
                            IdEdificio = (int)reader["Id"],
                            NombreEdificio = (string)reader["Nombre"]
                        };
                        edificios.Add(edificio);
                    }
                }
            }
            finally
            {
                dbConnection.Close();
            }

            return edificios;
        }

    }

    // Clase para representar un edificio


}