using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Negocio
{
    // Interfaz que define los métodos para manejar la gestión de visitas
    public interface IVisitaService
    {
        // Método para registrar una nueva visita etc
        void RegistrarVisita(Visita visita);
        List<Visita> ConsultarVisitasPorEdificio(int edificioId);
        List<Visita> ConsultarTodasLasVisitas();
        void EliminarVisita(int idVisita);
        void ModificarVisita(Visita visita);
        List<Visita> ObtenerVisitas();
    }


    // Implementación de la interfaz IVisitaService
    public class VisitaService : IVisitaService
    {
        // Repositorio que maneja el acceso a los datos de las visitas
        private readonly IVisitaRepository _visitaRepository;

        // Constructor que recibe un repositorio de visitas
        public VisitaService(IVisitaRepository visitaRepository)
        {
            _visitaRepository = visitaRepository;  // Asigna el repositorio recibido al campo privado
        }

        public void RegistrarVisita(Visita visita)
        {
            // Lógica de negocio, validaciones, etc.
            if (string.IsNullOrWhiteSpace(visita.NombreVisita))
            {
                throw new ArgumentException("El nombre del visitante no puede estar vacío.");
            }

         

            _visitaRepository.RegistrarVisita(visita);  // Llama al repositorio para registrar la visita
        }

    

    public List<Visita> ConsultarVisitasPorEdificio(int edificioId)
        {
            if (edificioId <= 0)
            {
                throw new ArgumentException("El ID del edificio no es válido.");
            }
            // Llama al repositorio para obtener visitas por edificio
            return _visitaRepository.ConsultarVisitasPorEdificio(edificioId); 
        }

        public List<Visita> ConsultarTodasLasVisitas()
        {
            // Llama al repositorio para obtener todas las visitas
            return _visitaRepository.ConsultarTodasLasVisitas();
        }

        public void EliminarVisita(int idVisita)
        {
            if (idVisita <= 0)
            {
                throw new ArgumentException("El ID de la visita no es válido.");
            }
            // Llama al repositorio para eliminar la visita
            _visitaRepository.EliminarVisita(idVisita);
        }

        public void ModificarVisita(Visita visita)
        {
            if (visita.IdVisita <= 0)
            {
                throw new ArgumentException("El ID de la visita no es válido.");
            }


            // Llama al repositorio para modificar la visita
            _visitaRepository.ModificarVisita(visita);
        }
        public List<Visita> ObtenerVisitas()
        {  // Llama al repositorio para obtener la lista de visitas
            return _visitaRepository.ObtenerVisitas();
        }
    }

}
