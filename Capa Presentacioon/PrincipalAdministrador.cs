using Autofac;
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
    public partial class PrincipalAdministrador : Form
    {    // Instancia del scope de vida de los objetos para la inyección de dependencias
        private readonly ILifetimeScope _lifetimeScope;
        // Servicio central que se utilizará en el formulario
        private readonly ICentroServicios _centroServicios;

        // Constructor de la clase PrincipalAdministrador
        public PrincipalAdministrador(ILifetimeScope lifetimeScope, ICentroServicios centroServicios)
        {
            // Asigna las instancias recibidas a los campos privados
            _lifetimeScope = lifetimeScope;
            InitializeComponent();
            _centroServicios = centroServicios;
        }

        //evento para salir de la aplicacion
        private void btsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //eventos para el clic en el botón que abre el formulario de inicio de sesión
        private void button3_Click(object sender, EventArgs e)
        {
            // Obtener las dependencias del lifetimeScope
            var centroServicios = _lifetimeScope.Resolve<ICentroServicios>();
            var lifetimeScope = _lifetimeScope; // O resolverlo si es necesario

            // abrir = new Loginn();//
            var abrir = _lifetimeScope.Resolve<Loginn>();
            abrir.Show();
            this.Hide();
        }


        // Método para abrir un formulario hijo en el panel
        private void AbrirFormularioHijo(object formHijo)
        {
            // Verifica si ya hay algún control en el panel y lo elimina
            if (this.inicio.Controls.Count > 0)
                this.inicio.Controls.RemoveAt(0);

            // Castea el objeto recibido a Form
            Form fh = formHijo as Form;

            // Configura el formulario hijo para que no sea un formulario de nivel superior
            fh.TopLevel = false;

            // Configura el dock del formulario hijo para que llene el panel
            fh.Dock = DockStyle.Fill;

            // Agrega el formulario hijo al panel contenedor
            this.inicio.Controls.Add(fh);
            this.inicio.Tag = fh;

            // Muestra el formulario hijo
            fh.Show();
        }


        //evento para el clic en el botón de visitas
        private void btvisitas_Click_1(object sender, EventArgs e)
        {
            var visitasForm = new Visitas(_centroServicios);
            AbrirFormularioHijo(visitasForm); // Abre el formulario de visitas en el panel
        }

        // evento para el clic en el botón de edificios
        private void btedificio_Click(object sender, EventArgs e)
        {
            var edificioForm = new Edificio(_centroServicios);
            AbrirFormularioHijo(edificioForm);   // Abre el formulario de edificios en el panel
        }
        //evento para el clic en el botón de usuarios
        private void btusuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Usuarios(_centroServicios)); // Abre el formulario de usuarios en el panel
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            AbrirFormularioHijo(new InicioAdmin());  // Abre el formulario de inicio de administración en el panel
        }
    }
}
