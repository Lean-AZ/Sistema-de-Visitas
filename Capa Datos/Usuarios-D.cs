using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using System.Configuration;
using System.Data;
using System.Security.Cryptography.X509Certificates;



namespace Capa_Datos
{      // Interfaz que define las operaciones CRUD para el repositorio de usuarios
    public interface IUsuarioRepository
    {
        void RegistrarUsuario(Usuarios usuario); //metodo para registrarse
        Usuarios AutenticarUsuario(string usuario, string contraseña); //metodos para autenticarse
        void ModificarUsuario(Usuarios usuario); // Método agregado para modificar usuarios
        void EliminarUsuario(int id); // Método agregado para eliminar usuarios
        List<Usuarios> BuscarTodosLosUsuarios(); // Método agregado para buscar todos los usuarios
    }
    // Implementación de la interfaz IUsuarioRepository
    public class UsuarioRepository : IUsuarioRepository
    {
        // Registra un nuevo usuario en la base de datos
        public void RegistrarUsuario(Usuarios usuario) 
        {
            var dbConnection = new DatabaseConnection();  // Crear una instancia de la clase de conexión a la base de datos
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_RegistrarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@Apellido", usuario.ApellidoUsuario);
                command.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimientoUsuario);
                command.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                command.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);

                dbConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }
        // Autentica a un usuario con las credenciales proporcionadas
        public Usuarios AutenticarUsuario(string usuario, string contraseña)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_AutenticarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Contraseña", contraseña);

                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuarios
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            NombreUsuario = reader["Nombre"].ToString(),
                            ApellidoUsuario = reader["Apellido"].ToString(),
                            TipoUsuario = reader["TipoUsuario"].ToString()
                        };
                    }
                }
            }
            finally
            {
                dbConnection.Close();
            }
            return null;
        }


        // Modifica un usuario existente en la base de datos
        public void ModificarUsuario(Usuarios usuario)
        {
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_ModificarUsuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                command.Parameters.AddWithValue("@Nombre", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@Apellido", usuario.ApellidoUsuario);
                command.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimientoUsuario);
                command.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);
                command.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña ?? (object)DBNull.Value); // Usa DBNull.Value para valores nulos

                dbConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }
        }
        // Elimina un usuario existente en la base de datos
        public void EliminarUsuario(int id)
            {
                var dbConnection = new DatabaseConnection();
                try
                {
                    var connection = dbConnection.GetConnection();
                    var command = new SqlCommand("sp_EliminarUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    dbConnection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        // Obtiene una lista de todos los usuarios en la base de datos
        public List<Usuarios> BuscarTodosLosUsuarios()
        {
            var usuarios = new List<Usuarios>();
            var dbConnection = new DatabaseConnection();
            try
            {
                var connection = dbConnection.GetConnection();
                var command = new SqlCommand("sp_BuscarTodosLosUsuarios", connection);
                command.CommandType = CommandType.StoredProcedure;

                dbConnection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuarios
                        {
                            IdUsuario = Convert.ToInt32(reader["Id"]),
                            NombreUsuario = reader["Nombre"].ToString(),
                            ApellidoUsuario = reader["Apellido"].ToString(),
                            FechaNacimientoUsuario = Convert.ToDateTime(reader["FechaNacimiento"]),
                            TipoUsuario = reader["TipoUsuario"].ToString(),
                            Usuario = reader["Usuario"].ToString(),
                            Contraseña = reader["Contraseña"].ToString()
                        });
                    }
                }
            }
            finally
            {
                dbConnection.Close();
            }
            return usuarios;
        }
    }
    }
