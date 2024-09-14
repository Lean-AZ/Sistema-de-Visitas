using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    // Interfaz que define los servicios disponibles en el centro de servicios
    public interface ICentroServicios
    {
        // Servicios de Aula
        void AgregarAula(string nombre, int edificioId);
        void ModificarAula(int id, string nombre, int edificioId);
        void EliminarAula(int id);
        Aula BuscarAula(int id);
        List<Aula> ObtenerTodasLasAulas();

        // Servicios de Edificio
        void AgregarEdificio(string nombre);
        void ModificarEdificio(int id, string nombre);
        void EliminarEdificio(int id);
        Edificio BuscarEdificio(int id);
        List<Edificio> ObtenerTodosLosEdificios(); 



        // Servicios de Autenticación
        Usuarios Login(string usuario, string contraseña);
        void Registrar(Usuarios usuario);
        // Servicios de Usuario
        void ModificarUsuario(Usuarios usuario);
        void EliminarUsuario(int id);
        List<Usuarios> BuscarTodosLosUsuarios();


        // Servicios de Visita
        void RegistrarVisita(Visita visita);
        List<Visita> ConsultarVisitasPorEdificio(int edificioId);
        List<Visita> ConsultarTodasLasVisitas();
        void EliminarVisita(int idVisita);
        void ModificarVisita(Visita visita);
        List<Visita> ObtenerVisitas();
    }

    // Implementación de la interfaz ICentroServicios
    public class CentroServicios : ICentroServicios
    {
        private readonly IAulaService _aulaService;
        private readonly IEdificioService _edificioService;
        private readonly IAuthService _authService;
        private readonly IVisitaService _visitaService;

        // Constructor que recibe las dependencias de servicios
        public CentroServicios(
            IAulaService aulaService,
            IEdificioService edificioService,
            IAuthService authService,
            IVisitaService visitaService)
        {
            _aulaService = aulaService;
            _edificioService = edificioService;
            _authService = authService;
            _visitaService = visitaService;
        }

        // Métodos de Aula
        public void AgregarAula(string nombre, int edificioId)
        {
            _aulaService.AgregarAula(nombre, edificioId);
        }

        public void ModificarAula(int id, string nombre, int edificioId)
        {
            _aulaService.ModificarAula(id, nombre, edificioId);
        }

        public void EliminarAula(int id)
        {
            _aulaService.EliminarAula(id);
        }

        public Aula BuscarAula(int id)
        {
            return _aulaService.BuscarAula(id);

        }
        public List<Aula> ObtenerTodasLasAulas()
        {
            try
            {
                return _aulaService.ObtenerTodasLasAulas(); // Llama al método del servicio de aula
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new ApplicationException("Ocurrió un error al obtener todas las aulas.", ex);
            }
        }

        // Métodos de Edificio
        public void AgregarEdificio(string nombre)
        {
            _edificioService.AgregarEdificio(nombre);
        }

        public void ModificarEdificio(int id, string nombre)
        {
            _edificioService.ModificarEdificio(id, nombre);
        }

        public void EliminarEdificio(int id)
        {
            _edificioService.EliminarEdificio(id);
        }

        public Edificio BuscarEdificio(int id)
        {
            return _edificioService.BuscarEdificio(id);

        }
        public List<Edificio> ObtenerTodosLosEdificios()
        {
            try
            {
                return _edificioService.ObtenerTodosLosEdificios(); // Llama al método del servicio de edificio
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new ApplicationException("Ocurrió un error al obtener todos los edificios.", ex);
            }
        }


        // Métodos de Autenticación
        public Usuarios Login(string usuario, string contraseña)
        {
            return _authService.Login(usuario, contraseña);
        }  // Métodos de Usuario
        public void ModificarUsuario(Usuarios usuario)
        {
            _authService.ModificarUsuario(usuario);
        }

        public void EliminarUsuario(int id)
        {
            _authService.EliminarUsuario(id);
        }

        public List<Usuarios> BuscarTodosLosUsuarios()
        {
            return _authService.BuscarTodosLosUsuarios();
        }
        public void Registrar(Usuarios usuario)
        {
            _authService.Registrar(usuario);
        }

        // Métodos de Visita
        public void RegistrarVisita(Visita visita)
        {
            _visitaService.RegistrarVisita(visita);
        }

        public List<Visita> ConsultarVisitasPorEdificio(int edificioId)
        {
            return _visitaService.ConsultarVisitasPorEdificio(edificioId);
        }

        public List<Visita> ConsultarTodasLasVisitas()
        {
            return _visitaService.ConsultarTodasLasVisitas();
        }

        public void EliminarVisita(int idVisita)
        {
            _visitaService.EliminarVisita(idVisita);
        }

        public void ModificarVisita(Visita visita)
        {
            _visitaService.ModificarVisita(visita);
        }

        public List<Visita> ObtenerVisitas()
        {
            return _visitaService.ObtenerVisitas();
        }
    }
}