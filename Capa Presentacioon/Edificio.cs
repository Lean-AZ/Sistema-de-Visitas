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
using Autofac;
using Autofac.Core.Lifetime;

namespace Capa_Presentacioon
{
    public partial class Edificio : Form
    {
        // Inyectamos la dependencia ICentroServicios para interactuar con la capa de servicios.
        private readonly ICentroServicios _centroServicios;

        // Constructor que inicializa el servicio y configura el formulario.
        public Edificio(ICentroServicios centroServicios)
        {
            _centroServicios = centroServicios;  // Inicializa la instancia de ICentroServicios.
            InitializeComponent();
            InitializeDataGridViews(); // Configura las columnas
            LoadData(); // Carga los datos


        }

        private void Edificio_Load(object sender, EventArgs e)
        {
         

        }

        // Evento  para guardar un edificio.
        private void btguardarEdificio_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtedificio.Text;
                _centroServicios.AgregarEdificio(nombre);
                MessageBox.Show("Edificio agregado exitosamente.");
                // Actualizar la vista de datos
                LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //evento para actualizar un edificio
        private void btactualizarEdificio_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si se ha seleccionado un edificio en el DataGridView
                if (ListaEdificio.SelectedRows.Count > 0)
                {
                    // Obtén el ID del edificio seleccionado
                    int id = Convert.ToInt32(ListaEdificio.SelectedRows[0].Cells["IdEdificio"].Value);
                    string nombre = txtedificio.Text;

                    // Llama al servicio para modificar el edificio
                    _centroServicios.ModificarEdificio(id, nombre);
                    MessageBox.Show("Edificio actualizado exitosamente.");
                    LimpiarCampos(); // Limpiar campos


                    // Actualiza la vista de datos
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un edificio para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar edificio: " + ex.Message);
            }
        }



        // Configura los DataGridView para mostrar las columnas correctamente.
        private void InitializeDataGridViews()
        {
            // Configuración para dataGridViewAulas
            ConfigureDataGridView(ListaAula, new[]
            {
            new { Name = "IdAula", HeaderText = "ID Aula", Width = 100 },
            new { Name = "NombreAula", HeaderText = "Nombre Aula", Width = 200 },
            new { Name = "EdificioIdAula", HeaderText = "ID Edificio", Width = 100 }
        });

            // Configuración para dataGridViewEdificios
            ConfigureDataGridView(ListaEdificio, new[]
            {
            new { Name = "IdEdificio", HeaderText = "ID Edificio", Width = 100 },
            new { Name = "NombreEdificio", HeaderText = "Nombre Edificio", Width = 200 }
        });
        }

        // Configuración para DataGridView de Edificios.
        private void ConfigureDataGridView(DataGridView dataGridView, params dynamic[] columns)
        {
            dataGridView.AutoGenerateColumns = false; // Evita que se generen columnas automáticamente
            dataGridView.Columns.Clear(); // Limpia las columnas existentes

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

        // Carga los datos desde el servicio y los muestra en los DataGridView.
        private void LoadData()
        {
            try
            {
                ListaAula.DataSource = _centroServicios.ObtenerTodasLasAulas();
                ListaEdificio.DataSource = _centroServicios.ObtenerTodosLosEdificios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

 
       
        //evento para eliminar un edificio
        private void bteliminarEdificio_Click(object sender, EventArgs e)
        {

            if (ListaEdificio.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(ListaEdificio.SelectedRows[0].Cells["IdEdificio"].Value);
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este edificio?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _centroServicios.EliminarEdificio(id); // Eliminar el edificio por ID
                        MessageBox.Show("Edificio eliminado exitosamente.");
                        LoadData(); // Recargar datos
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar edificio: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un edificio para eliminar.");
            }
        }

        //evento para guardar una aula
        private void btguardarAula_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtaula.Text;
                int edificioId = int.Parse(idedificio.Text);
                _centroServicios.AgregarAula(nombre, edificioId);
                MessageBox.Show("Aula agregada exitosamente.");
                LimpiarCampos(); // Limpiar campos

                // Actualizar la vista de datos
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //evento para actualizar aula
        private void btactualizarAula_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si se ha seleccionado un aula
                if (ListaAula.SelectedRows.Count > 0 && ListaEdificio.SelectedRows.Count > 0)
                {
                    // Obtén el ID del aula y el nuevo nombre
                    int id = Convert.ToInt32(ListaAula.SelectedRows[0].Cells["IdAula"].Value);
                    string nombre = txtaula.Text;
                    int edificioId = Convert.ToInt32(ListaEdificio.SelectedRows[0].Cells["IdEdificio"].Value);

                    // Modifica el aula
                    _centroServicios.ModificarAula(id, nombre, edificioId);
                    MessageBox.Show("Aula actualizada exitosamente.");
                    LimpiarCampos(); // Limpiar campos


                    // Actualiza la vista de datos
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Selecciona un aula y un edificio para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar aula: {ex.Message}");
            }

        }

        //evento para eliminar aula
        private void bteliminarAula_Click(object sender, EventArgs e)
        {
            if (ListaAula.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(ListaAula.SelectedRows[0].Cells["IdAula"].Value);
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta aula?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _centroServicios.EliminarAula(id); // Eliminar el aula por ID
                        MessageBox.Show("Aula eliminada exitosamente.");
                        LoadData(); // Recargar datos
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar aula: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un aula para eliminar.");
            }




        }

        //limpiar controles

        private void LimpiarCampos()
        {
            txtedificio.Clear();
            txtaula.Clear();
            idedificio.Clear();
        }
    }


}
    


    

