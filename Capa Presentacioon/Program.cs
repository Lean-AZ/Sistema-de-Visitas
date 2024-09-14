using Autofac.Extensions.DependencyInjection;
using Autofac;
using Capa_Datos;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;


namespace Capa_Presentacioon
{
    namespace Capa_Presentacion
    {
        internal static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var builder = new ContainerBuilder();

                // Llamada al método para registrar servicios
                ConfigureServices(builder);

                var container = builder.Build();
                var serviceProvider = new AutofacServiceProvider(container);

                // Resolviendo el formulario de login con DI
                var loginForm = serviceProvider.GetService<Loginn>();

                Application.Run(loginForm);
            }

            private static void ConfigureServices(ContainerBuilder builder)
            {
                // Registrando repositorios
                builder.RegisterType<AulaRepository>().As<IAulaRepository>();
                builder.RegisterType<EdificioRepository>().As<IEdificioRepository>();
                builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>();
                builder.RegisterType<VisitaRepository>().As<IVisitaRepository>();

                // Registrando servicios
                builder.RegisterType<AulaService>().As<IAulaService>();
                builder.RegisterType<EdificioService>().As<IEdificioService>();
                builder.RegisterType<AuthService>().As<IAuthService>();
                builder.RegisterType<VisitaService>().As<IVisitaService>();

                // Registrando el servicio central
                builder.RegisterType<CentroServicios>().As<ICentroServicios>();

                // Registrando formularios
                builder.RegisterType<Principal>().InstancePerDependency();
                builder.RegisterType<Loginn>().InstancePerDependency();
                builder.RegisterType<PrincipalAdministrador>().InstancePerDependency();
            }
        }
    }
}