using Autofac;
using Autofac.Core.Lifetime;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacioon
{
    public partial class Loginn : Form
    {
        // Inyectamos las dependencias de ICentroServicios e ILifetimeScope mediante el constructor.
        private readonly ICentroServicios _centroServicios;
        private readonly ILifetimeScope _lifetimeScope;

        // Constructor que inicializa los servicios inyectados
        public Loginn(ICentroServicios centroServicios, ILifetimeScope lifetimeScope)
        {
            _centroServicios = centroServicios;  // Inicializa la instancia del servicio central
            _lifetimeScope = lifetimeScope;  // Inicializa la instancia del contenedor de dependencias (LifetimeScope).


            InitializeComponent();   // Inicializa los componentes del formulario.
        }
        // Evento que se dispara cuando se hace clic en el botón de ocultar la contraseña.
        private void pbocultar_Click(object sender, EventArgs e)
        {
            //imagen mostrandose
            pbmostrar.BringToFront();
            // ocultamos la contraseña
            txtcontraseña.PasswordChar = '*';
        }

        // Evento que se dispara cuando se hace clic en el botón de mostrar la contraseña.
        private void pbmostrar_Click(object sender, EventArgs e)
        {
            //imagen ocultada
            pbocultar.BringToFront();
            //mostrando contraseña
            txtcontraseña.PasswordChar = '\0';
        }

        // Evento que se dispara cuando se hace clic en el botón de iniciar sesión.
        private void btinciar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = txtusuario.Text;
                var contraseña = txtcontraseña.Text;

                // Autenticar el usuario utilizando el servicio central
                var user = _centroServicios.Login(usuario, contraseña);

                if (user != null)
                {
                   MessageBox.Show($"Bienvenido {user.NombreUsuario} {user.ApellidoUsuario}.");

                    // Determinar el formulario a abrir basado en el tipo de usuario
                    Form formToOpen;
                    if (user.TipoUsuario == "Administrador")
                    {
                        formToOpen = _lifetimeScope.Resolve<PrincipalAdministrador>();
                    }
                    else if (user.TipoUsuario == "General")
                    {
                        formToOpen = _lifetimeScope.Resolve<Principal>();
                    }
                    else
                    {
                        MessageBox.Show("Tipo de usuario no válido.");
                        return;
                    }

                    // Mostrar el formulario y ocultar el formulario de login actual
                    formToOpen.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

    
