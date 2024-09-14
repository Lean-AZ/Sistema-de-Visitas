using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    // Interfaz que define los métodos para manejar las operaciones relacionadas con edificios
    public interface IEdificioService
    {
        // Método para agregar un nuevo edificio
        void AgregarEdificio(string nombre);
        //metodo para modificar edificio
        void ModificarEdificio(int id, string nombre);
        //metodo para eliminar edificio
        //etc
        void EliminarEdificio(int id);
        //etc
        Edificio BuscarEdificio(int id);
        //etc
        List<Edificio> ObtenerTodosLosEdificios();
    }
    // Implementación de la interfaz IEdificioService
    public class EdificioService : IEdificioService
    {
        // Repositorio que maneja el acceso a los datos de los edificios
        private readonly IEdificioRepository _edificioRepository;

        // Constructor que recibe un repositorio de edificios
        public EdificioService(IEdificioRepository edificioRepository)
        {
            _edificioRepository = edificioRepository;
        }

        public void AgregarEdificio(string nombre)
        {
            // Lógica de negocio, validaciones, etc.
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del edificio no puede estar vacío.");
            }

            _edificioRepository.AgregarEdificio(nombre);  // Llama al método del repositorio para agregar el edificio
        }

        public void ModificarEdificio(int id, string nombre)
        {
            // Lógica de negocio, validaciones, etc.
            if (id <= 0)
            {
                throw new ArgumentException("El ID del edificio no es válido.");
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del edificio no puede estar vacío.");
            }

            _edificioRepository.ModificarEdificio(id, nombre);  // Llama al método del repositorio para modificar el edificio
        }

        public void EliminarEdificio(int id)
        {
            // Lógica de negocio, validaciones, etc.
            if (id <= 0)
            {
                throw new ArgumentException("El ID del edificio no es válido.");
            }

            _edificioRepository.EliminarEdificio(id); // Llama al método del repositorio para eliminar el edificio
        }

        public Edificio BuscarEdificio(int id)
        {
            // Lógica de negocio, validaciones, etc.
            if (id <= 0)
            {
                throw new ArgumentException("El ID del edificio no es válido.");
            }

            return _edificioRepository.BuscarEdificio(id);  // Llama al método del repositorio para buscar el edificio
        }

        public List<Edificio> ObtenerTodosLosEdificios()
        {
            // Lógica de negocio, validaciones, etc.
            try
            {
                return _edificioRepository.ObtenerTodosLosEdificios(); // Llama al método del repositorio para obtener todos los edificios
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new ApplicationException("Ocurrió un error al obtener los edificios.", ex);
            }
        }

    }
}