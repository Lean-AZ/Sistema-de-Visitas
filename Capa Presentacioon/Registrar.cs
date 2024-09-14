using Capa_Entidades;
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
    public partial class Registrar : Form
    {
        // Servicio central que se utilizará en el formulario
        private readonly ICentroServicios _centroServicios;

        // Constructor de la clase Registrar
        public Registrar(ICentroServicios centroServicios)
        {
            _centroServicios = centroServicios; // Asigna el servicio recibido al campo privado
            InitializeComponent();  // Inicializa los componentes del formulario
            LoadComboBoxes();  // Carga los datos en los ComboBoxes

        }

        // Método para cargar los datos en los ComboBoxes
        private void LoadComboBoxes()
        {   // Configura el ComboBox de edificios
            comboedificio.DataSource = _centroServicios.ObtenerTodosLosEdificios();
            comboedificio.DisplayMember = "NombreEdificio";
            comboedificio.ValueMember = "IdEdificio";
            // Configura el ComboBox de aulas
            comboaula.DataSource = _centroServicios.ObtenerTodasLasAulas();
            comboaula.DisplayMember = "NombreAula";
            comboaula.ValueMember = "IdAula";
        }

        //eventos para el clic en el botón de guardar
        private void btguardar_Click(object sender, EventArgs e)
        {
            try
            {    // Crea una nueva instancia de Visita con los datos del formulario
                var visita = new Visita
                {
                    NombreVisita = txtnombre.Text,
                    ApellidoVisita = txtapellido.Text,
                    CarreraVisita = txtcarrera.Text,
                    CorreoVisita = txtcorreo.Text,
                    EdificioIdVisita = (int)comboedificio.SelectedValue, // ID del edificio seleccionado
                    AulaIdVisita = (int)comboaula.SelectedValue, // ID del aula seleccionado
                    HoraEntradaVisita = datefecha.Value,
                    MotivoVisita = txtmotivo.Text,

                };
                // Llama al servicio para registrar la visita
                _centroServicios.RegistrarVisita(visita);
                MessageBox.Show("Visita registrada exitosamente.");
                LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar visita: " + ex.Message);
            }

        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
            {
                txtnombre.Clear();
                txtapellido.Clear();
                txtcarrera.Clear();
                txtcorreo.Clear();
                datefecha.Value = DateTime.Now;
                txtmotivo.Clear();

            }
        }
}

