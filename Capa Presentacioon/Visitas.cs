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
    public partial class Visitas : Form
    {           // Servicio que proporciona acceso a las operaciones de datos
        private readonly ICentroServicios _centroServicios;
        // Constructor del formulario
        public Visitas(ICentroServicios centroServicios)
        {
            _centroServicios = centroServicios;  // Asignación del servicio proporcionado
            InitializeComponent();  // Inicialización de los componentes del formulario
            InitializeDataGridViews();  // Configuración inicial del DataGridView
            LoadData();  // Carga los datos en el DataGridView
            LoadComboBoxes();     // Llena los combo boxes con datos
            registro.CellClick += registro_CellClick;  // Asocia el evento CellClick con el manejador correspondiente


        }
        // Método para llenar los combo boxes con datos de edificios y aulas
        private void LoadComboBoxes()
        {
            comboedificio.DataSource = _centroServicios.ObtenerTodosLosEdificios();
            comboedificio.DisplayMember = "NombreEdificio";
            comboedificio.ValueMember = "IdEdificio";

            comboaula.DataSource = _centroServicios.ObtenerTodasLasAulas();
            comboaula.DisplayMember = "NombreAula";
            comboaula.ValueMember = "IdAula";
        }

        // Método que maneja el clic en el botón de guardar
        private void btguardar_Click(object sender, EventArgs e)
        {
            try
            {          // Crea una nueva instancia de Visita con los datos del formulario
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
                // Llama al servicio para registrar la nueva visita
                _centroServicios.RegistrarVisita(visita);
                MessageBox.Show("Visita registrada exitosamente.");
                LimpiarCampos();
                LoadData();  // Recarga los datos para mostrar la nueva visita
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar visita: " + ex.Message);
            }
        }

        // Método que maneja el clic en el botón de actualizar
        private void btactualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (registro.SelectedRows.Count > 0)
                {
                    // Obtener el ID de la visita seleccionada
                    int id = Convert.ToInt32(registro.SelectedRows[0].Cells["IdVisita"].Value);

                    // Crear una nueva instancia de Visita con los datos actualizados
                    var visita = new Visita
                    {
                        IdVisita = id,
                        NombreVisita = txtnombre.Text,
                        ApellidoVisita = txtapellido.Text,
                        CarreraVisita = txtcarrera.Text,
                        CorreoVisita = txtcorreo.Text,
                        EdificioIdVisita = (int)comboedificio.SelectedValue, // ID del edificio seleccionado
                        AulaIdVisita = (int)comboaula.SelectedValue, // ID del aula seleccionado
                        HoraEntradaVisita = datefecha.Value,
                        MotivoVisita = txtmotivo.Text,

                    };

                    // Llamar al método para modificar la visita en el negocio
                    _centroServicios.ModificarVisita(visita);

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("Visita actualizada exitosamente.");

                    // Limpiar los campos y recargar los datos
                    LimpiarCampos();
                    LoadData(); // Recarga los datos para mostrar la visita actualizada
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una visita para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar visita: " + ex.Message);
            }
        }

        // Método que maneja el clic en el botón de eliminar
        private void bteliminar_Click(object sender, EventArgs e)
        {
            if (registro.SelectedRows.Count > 0)
            {
                // Obtener el ID de la visita seleccionada
                int id = Convert.ToInt32(registro.SelectedRows[0].Cells["IdVisita"].Value);

                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta visita?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar al método para eliminar la visita
                        _centroServicios.EliminarVisita(id);

                        // Mostrar un mensaje de éxito
                        MessageBox.Show("Visita eliminada exitosamente.");

                        // Recargar los datos para reflejar la eliminación
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar visita: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una visita para eliminar.");
            }
        }



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

        // Configura las columnas del DataGridView
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

        // Carga los datos en el DataGridView
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

        // Limpia los campos del formulario
        private void LimpiarCampos()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txtcarrera.Clear();
            txtcorreo.Clear();
            datefecha.Value = DateTime.Now;
            txtmotivo.Clear();
        }


        // Maneja el evento CellClick del DataGridView
        private void registro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que se haya seleccionado una fila válida
            {
                DataGridViewRow row = registro.Rows[e.RowIndex];
                // Rellena los campos del formulario con los datos de la fila seleccionada
                txtnombre.Text = row.Cells["NombreVisita"].Value?.ToString() ?? string.Empty;
                txtapellido.Text = row.Cells["ApellidoVisita"].Value?.ToString() ?? string.Empty;
                txtcarrera.Text = row.Cells["CarreraVisita"].Value?.ToString() ?? string.Empty;
                txtcorreo.Text = row.Cells["CorreoVisita"].Value?.ToString() ?? string.Empty;
                comboedificio.SelectedValue = row.Cells["EdificioVisita"].Value ?? -1;
                comboaula.SelectedValue = row.Cells["AulaVisita"].Value ?? -1;

                // Manejo de la fecha
                if (row.Cells["HoraEntradVisita"].Value != DBNull.Value && row.Cells["HoraEntradVisita"].Value != null)
                {
                    if (DateTime.TryParse(row.Cells["HoraEntradVisita"].Value.ToString(), out DateTime fechaEntrada))
                    {
                        if (fechaEntrada >= datefecha.MinDate && fechaEntrada <= datefecha.MaxDate)
                        {
                            datefecha.Value = fechaEntrada;
                        }
                        else
                        {
                            datefecha.Value = DateTime.Now;
                            MessageBox.Show("La fecha en la celda está fuera del rango permitido. Se asignará la fecha actual.");
                        }
                    }
                    else
                    {
                        datefecha.Value = DateTime.Now;
                        MessageBox.Show("La fecha en la celda no es válida. Se asignará la fecha actual.");
                    }
                }
                else
                {
                    datefecha.Value = DateTime.Now;
                }

                txtmotivo.Text = row.Cells["MotivoVisita"].Value?.ToString() ?? string.Empty;
            }
        }
    }
}