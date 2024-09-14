using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{    // Interfaz que define los métodos para manejar las operaciones relacionadas con aulas
    public interface IAulaService
    {      // Método para agregar una nueva aula
        void AgregarAula(string nombre, int edificioId);
        void ModificarAula(int id, string nombre, int edificioId);
        void EliminarAula(int id);
        Aula BuscarAula(int id);
        List<Aula> ObtenerTodasLasAulas();
    }
    // Implementación de la interfaz IAulaService
    public class AulaService : IAulaService
    {       // Repositorio que maneja el acceso a los datos de las aulas
        private readonly IAulaRepository _aulaRepository;


        // Constructor que recibe un repositorio de aulas
        public AulaService(IAulaRepository aulaRepository)
        {
            _aulaRepository = aulaRepository; // Asigna el repositorio recibido al campo privado
        }


        // Método para agregar una nueva aula
        public void AgregarAula(string nombre, int edificioId)
        {
            // Verifica que el nombre no sea nulo o solo espaciosc.
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del aula no puede estar vacío.");
            }
            // Verifica que el ID del edificio sea válido
            if (edificioId <= 0)
            {
                throw new ArgumentException("El ID del edificio no es válido.");   // Lanza una excepción si la validación falla
            }

            _aulaRepository.AgregarAula(nombre, edificioId);  // Llama al método del repositorio para agregar el aula
        }

        // Método para modificar una aula existente
        public void ModificarAula(int id, string nombre, int edificioId)
        {
            //Verifica que el ID del aula sea válido
            if (id <= 0)
            {
                throw new ArgumentException("El ID del aula no es válido.");
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del aula no puede estar vacío.");
            }

            if (edificioId <= 0)
            {
                throw new ArgumentException("El ID del edificio no es válido.");
            }

            _aulaRepository.ModificarAula(id, nombre, edificioId);  // Llama al método del repositorio para modificar el aula
        }

        public void EliminarAula(int id)
        {
            // Lógica de negocio, validaciones, etc.
            if (id <= 0)
            {
                throw new ArgumentException("El ID del aula no es válido.");
            }

            _aulaRepository.EliminarAula(id);  // Llama al método del repositorio para eliminar el aula
        
    }

        public Aula BuscarAula(int id)
        {
            // Lógica de negocio, validaciones, etc.
            if (id <= 0)
            {
                throw new ArgumentException("El ID del aula no es válido.");
            }

            return _aulaRepository.BuscarAula(id);  // Llama al método del repositorio para buscar el aula
        }


        public List<Aula> ObtenerTodasLasAulas()
        {
            // Lógica de negocio, validaciones, etc.
            try
            {
                return _aulaRepository.ObtenerTodasLasAulas();  // Llama al método del repositorio para obtener todas las aulas
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new ApplicationException("Ocurrió un error al obtener las aulas.", ex);
            }
        }

    }
}

