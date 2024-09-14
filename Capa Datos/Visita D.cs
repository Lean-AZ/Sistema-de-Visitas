using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Collections.ObjectModel;
using System.Data.Odbc;
using Capa_Entidades;

namespace Capa_Datos
{
    // Implementación del patrón Repository para gestionar visita
    public interface IVisitaRepository
    {
        //metodos
        void RegistrarVisita(Visita visita);
        List<Visita> ConsultarVisitasPorEdificio(int edificioId);
        List<Visita> ConsultarTodasLasVisitas();
        void EliminarVisita(int idVisita);
        void ModificarVisita(Visita visita);
        List<Visita> ObtenerVisitas();
    }
    // Implementación de la interfaz IAulaRepositor
    public class VisitaRepository : IVisitaRepository
    {

        //registrar visita
        public void RegistrarVisita(Visita visita)
        {
            var dbConnection = new DatabaseConnection();
            try
            {   // Agrega los parámetros necesarios para registrar una visita
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_RegistrarVisita", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", visita.NombreVisita);
                command.Parameters.AddWithValue("@Apellido", visita.ApellidoVisita);
                command.Parameters.AddWithValue("@Carrera", visita.CarreraVisita ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Correo", visita.CorreoVisita ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@EdificioId", visita.EdificioIdVisita);
                command.Parameters.AddWithValue("@AulaId", visita.AulaIdVisita);
                command.Parameters.AddWithValue("@HoraEntrada", visita.HoraEntradaVisita);
                command.Parameters.AddWithValue("@Motivo", visita.MotivoVisita);


                dbConnection.Open();  //abre la conexion
                command.ExecuteNonQuery();  // Ejecuta el procedimiento almacenado
            }
            finally
            {
                dbConnection.Close();  // Asegura el cierre de la conexión
            }
        }

        // consultar visitas
        public List<Visita> ConsultarVisitasPorEdificio(int edificioId)
        {
            var visitas = new List<Visita>();
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_ConsultarVisitasPorEdificio", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EdificioId", edificioId);

                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var visita = new Visita
                        {
                            IdVisita = Convert.ToInt32(reader["Id"]),
                            NombreVisita = reader["Nombre"].ToString(),
                            ApellidoVisita = reader["Apellido"].ToString(),
                            CarreraVisita = reader["Carrera"].ToString(),
                            CorreoVisita = reader["Correo"].ToString(),
                            HoraEntradaVisita = Convert.ToDateTime(reader["HoraEntrada"]),
                            MotivoVisita = reader["Motivo"].ToString(),
                            AulaIdVisita = Convert.ToInt32(reader["AulaId"]),
                        };
                        visitas.Add(visita);  // Agrega la visita a la lista
                    }
                }
            }
            finally
            {
                dbConnection.Close();
            }
            return visitas;
        }


        //consulta todas las visitas
        public List<Visita> ConsultarTodasLasVisitas()
        {
            var visitas = new List<Visita>();
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_ConsultarTodasLasVisitas", connection);
                command.CommandType = CommandType.StoredProcedure;

                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var visita = new Visita
                        {
                            IdVisita = Convert.ToInt32(reader["IdVisita"]),
                            NombreVisita = reader["NombreVisitante"].ToString(),
                            ApellidoVisita = reader["ApellidoVisitante"].ToString(),
                            CarreraVisita = reader["CarreraVisitante"].ToString(),
                            CorreoVisita = reader["CorreoVisitante"].ToString(),
                            EdificioIdVisita = Convert.ToInt32(reader["NombreEdificio"]),
                            AulaIdVisita= Convert.ToInt32(reader["NombreAula"]),
                            HoraEntradaVisita = Convert.ToDateTime(reader["HoraEntrada"]),
                            MotivoVisita = reader["MotivoVisita"].ToString()
                        };
                        visitas.Add(visita);  // Agrega la visita a la list
                    }
                }
            }
            finally
            {
                dbConnection.Close();
            }
            return visitas;
        }


        //elimina una visita
        public void EliminarVisita(int idVisita)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_EliminarVisita", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Agrega el parámetro necesario para eliminar una visita
                command.Parameters.AddWithValue("@IdVisita", idVisita);

                dbConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }

        //modificar las visitas
        public void ModificarVisita(Visita visita)
        {
            var dbConnection = new DatabaseConnection();
            try
            {           // Agrega los parámetros necesarios para modificar una visita
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_ModificarVisita", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdVisita", visita.IdVisita);
                command.Parameters.AddWithValue("@Nombre", visita.NombreVisita);
                command.Parameters.AddWithValue("@Apellido", visita.ApellidoVisita);
                command.Parameters.AddWithValue("@Carrera", visita.CarreraVisita ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Correo", visita.CorreoVisita ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@EdificioId", visita.EdificioIdVisita);
                command.Parameters.AddWithValue("@AulaId", visita.AulaIdVisita);
                command.Parameters.AddWithValue("@HoraEntrada", visita.HoraEntradaVisita);
                command.Parameters.AddWithValue("@Motivo", visita.MotivoVisita);
            

                dbConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();

            }
            }
           
           //obtiene todas las visitas
            public List<Visita> ObtenerVisitas()
            {
                var visitas = new List<Visita>();
                var dbConnection = new DatabaseConnection();
                try
                {
                    var connection = dbConnection.GetConnection();
                    var command = new SqlCommand("sp_ObtenerVisitas", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    dbConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var visita = new Visita
                            {
                                IdVisita = reader["IdVisita"] != DBNull.Value ? Convert.ToInt32(reader["IdVisita"]) : 0,
                                NombreVisita = reader["NombreVisita"].ToString(),
                                ApellidoVisita = reader["ApellidoVisita"].ToString(),
                                CarreraVisita = reader["CarreraVisita"].ToString(),
                                CorreoVisita = reader["CorreoVisita"].ToString(),
                                EdificioVisita = reader["EdificioVisita"].ToString(),
                                AulaVisita = reader["AulaVisita"].ToString(),
                                HoraEntradaVisita = reader["HoraEntradaVisita"] != DBNull.Value ? Convert.ToDateTime(reader["HoraEntradaVisita"]) : DateTime.Now,
                                MotivoVisita = reader["MotivoVisita"].ToString()
                            };
                            visitas.Add(visita);
                        }
                    }
                }
                finally
                {
                    dbConnection.Close();
                }
                return visitas;
            }


        }
    }
