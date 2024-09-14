using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;



namespace Capa_Negocio
{
    // Interfaz que define los métodos para manejar la autenticación y gestión de usuarios
    public interface IAuthService
    {     
        Usuarios Login(string usuario, string contraseña);  // Método para autenticar un usuario y devolver el objeto Usuario
        void Registrar(Usuarios usuario);
        void ModificarUsuario(Usuarios usuario); // Método agregado para modificar usuarios
        void EliminarUsuario(int id); // Método agregado para eliminar usuarios
        List<Usuarios> BuscarTodosLosUsuarios(); // Método agregado para buscar todos los usuarios

    }
    // Implementación de la interfaz IAuthService
    public class AuthService : IAuthService
    {
        // Repositorio que maneja el acceso a los datos de los usuarios
        private readonly IUsuarioRepository _usuarioRepository;


        // Constructor que recibe un repositorio de usuarios
        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;  // Asigna el repositorio recibido al campo privado
        }

        public Usuarios Login(string usuario, string contraseña)

        {     // Llama al repositorio para autenticar al usuario
            var user = _usuarioRepository.AutenticarUsuario(usuario, contraseña);
            // Si no se encuentra el usuario, lanza una excepción de acceso no autorizado
            if (user == null)
            {
                throw new UnauthorizedAccessException("Nombre de usuario o contraseña incorrectos.");
            }

            // Verificar el tipo de usuario y otorgar permisos
            switch (user.TipoUsuario)
            {
                case "Administrador":
                    // Otorgar permisos de administrador
                    // ...
                    break;
                case "General":
                    // Otorgar permisos de usuario general
                    // ...
                    break;
                default:
                    throw new UnauthorizedAccessException("Tipo de usuario no válido.");
            }

            return user;


        }
        // Método para registrar un nuevo usuario
        public void Registrar(Usuarios usuario)
        {
            _usuarioRepository.RegistrarUsuario(usuario);// Llama al repositorio para registrar al nuevo usuario
        }
        // Método para modificar un usuario existente
        public void ModificarUsuario(Usuarios usuario)
        {
            _usuarioRepository.ModificarUsuario(usuario);  // Llama al repositorio para modificar los detalles del usuario
        }

        // Método para eliminar un usuario por su ID
        public void EliminarUsuario(int id)
        {
            _usuarioRepository.EliminarUsuario(id);  // Llama al repositorio para eliminar el usuario
        }
        // Método para buscar y devolver una lista de todos los usuarios
        public List<Usuarios> BuscarTodosLosUsuarios()
        {
            return _usuarioRepository.BuscarTodosLosUsuarios();  // Llama al repositorio para obtener todos los usuarios
        }
    }


}
