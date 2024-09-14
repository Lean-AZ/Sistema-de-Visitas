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
    public partial class Principal : Form

    {
        // Instancia del scope de vida de los objetos para la inyección de dependencias
        private readonly ILifetimeScope _lifetimeScope;
        // Servicio central que se utilizará en el formulario
        private readonly ICentroServicios _centroServicios;

        // Constructor de la clase Principal
        public Principal(ILifetimeScope lifetimeScope, ICentroServicios centroServicios)
        {  try
            {  // Asigna las instancias recibidas a los campos privados
                _lifetimeScope = lifetimeScope;
                InitializeComponent();
                _centroServicios = centroServicios;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al inicializar Principal: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }



        }


        //cierra la aplicacion
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Método para abrir un formulario hijo en el panel
        private void AbrirFormularioHijo(object formHijo)
        {      try
            {
                // Verifica si ya hay algún control en el panel y lo elimina
                if (this.control.Controls.Count > 0)
                    this.control.Controls.RemoveAt(0);

                // Castea el objeto recibido a Form
                Form fh = formHijo as Form;

                // Configura el formulario hijo para que no sea un formulario de nivel superior
                fh.TopLevel = false;

                // Configura el dock del formulario hijo para que llene el panel
                fh.Dock = DockStyle.Fill;

                // Agrega el formulario hijo al panel contenedor
                this.control.Controls.Add(fh);
                this.control.Tag = fh;

                // Muestra el formulario hijo
                fh.Show();
            }
            catch (Exception ex)
            {   // Muestra un mensaje de error con detalles sobre la excepción
                MessageBox.Show($"Ocurrió un error al abrir el formulario hijo: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Manejador de eventos para el clic en el botón de registrar
        private void btegistrar_Click(object sender, EventArgs e)
        {
            try
            // Abre el formulario Registrar en el panel
            {
                AbrirFormularioHijo(new Registrar(_centroServicios));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        // Manejador de eventos para el clic en el botón de consultar
        private void btonsultar_Click(object sender, EventArgs e)
        {    try
            {   // Abre el formulario Consultar en el panel
                AbrirFormularioHijo(new Consultar(_centroServicios));
            }
            catch ( Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Manejador de eventos para el clic en el botón de sesión
        private void btsesion_Click(object sender, EventArgs e)
        {
            var centroServicios = _lifetimeScope.Resolve<ICentroServicios>();
            var lifetimeScope = _lifetimeScope; // O resolverlo si es necesario

            // abrir = new Loginn();//
            var abrir = _lifetimeScope.Resolve<Loginn>();
            abrir.Show();
            this.Hide();
        }
        // Abre el formulario Inicio en el panel
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Inicio());
        }
    }
}
