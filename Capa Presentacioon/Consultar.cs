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
    public partial class Consultar : Form
    {    // Variable privada para almacenar el servicio de centro
        private readonly ICentroServicios _centroServicios;

        // Constructor de la clase Consultar, que recibe una instancia de ICentroServicios
        public Consultar(ICentroServicios centroServicios)
        {
            InitializeComponent();   // Inicializa los componentes del formulario
            _centroServicios = centroServicios;  // Asigna el servicio al campo privado
            InitializeDataGridViews();  // Configura los DataGridViews
            LoadData(); // Carga los datos en el DataGridView
            registro.CellClick += registro_CellClick;
            _centroServicios = centroServicios;
        }

        private void registro_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        // Método para inicializar y configurar el DataGridView
        private void InitializeDataGridViews()
        {
            // Configuración para dataGridViewVisitas
            ConfigureDataGridView(registro, new[]
            {
            new { Name = "IdVisita", HeaderText = "ID Visita", Width = 100 },
            new { Name = "NombreVisita", HeaderText = "Nombre Visita", Width = 200 },
            new { Name = "ApellidoVisita", HeaderText = "Apellido Visita", Width = 200 },
            new { Name = "CarreraVisita", HeaderText = "Carrera", Width = 200 },
            new { Name = "CorreoVisita", HeaderText = "Correo", Width = 200 },
            new { Name = "EdificioVisita", HeaderText = "Edificio", Width = 100 },
            new { Name = "AulaVisita", HeaderText = "Aula", Width = 100 },
            new { Name = "HoraEntradVisita", HeaderText = "Fecha Entrada", Width = 150 },
            new { Name = "MotivoVisita", HeaderText = "Motivo", Width = 300 }

        });

        }

        // Método para configurar el DataGridView con las columnas especificadas
        private void ConfigureDataGridView(DataGridView dataGridView, params dynamic[] columns)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();

            foreach (var column in columns)
            {
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = column.Name,
                    HeaderText = column.HeaderText,
                    DataPropertyName = column.Name,
                    Width = column.Width
                });
            }
        }

        // Método para cargar los datos en el DataGridView
        private void LoadData()
        {
            try
            {
                var visitas = _centroServicios.ObtenerVisitas();
                registro.DataSource = visitas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message + "\nStackTrace: " + ex.StackTrace);
            }
        }
    }

}