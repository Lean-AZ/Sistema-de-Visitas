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
using Capa_Entidades;
using System.Diagnostics;

namespace Capa_Presentacioon
{
    public partial class Usuarios : Form
    {
        // Servicio central que se utilizará en el formulario
        private readonly ICentroServicios _centroServicios;

        // Constructor de la clase Usuarios
        public Usuarios(ICentroServicios centroServicios)
        {
            _centroServicios = centroServicios;  // Asigna el servicio recibido al campo privado
            InitializeComponent();    // Inicializa los componentes del formulario
            InitializeDataGridViews();   // Configura el DataGridView
        }

        //eventos para el clic en el botón de guardar
        private void btguardar_Click(object sender, EventArgs e)
        {
            {
                try
                {     // Crea una nueva instancia de Usuario con los datos del formulario
                    var usuario = new Capa_Entidades.Usuarios
                    {
                        NombreUsuario = txtnombre.Text,
                        ApellidoUsuario = txtapellido.Text,
                        FechaNacimientoUsuario = datefecha.Value,
                        TipoUsuario = combotipo.SelectedItem?.ToString(), // Tipo de usuario seleccionado
                        Usuario = txtusuario.Text,
                        Contraseña = txtcontraseña.Text
                    };
                    // Llama al servicio para registrar el nuevo usuario
                    _centroServicios.Registrar(usuario);
                    MessageBox.Show("Usuario registrado exitosamente.");
                    LimpiarCampos();
                    LoadData(); // Refresh data after adding a new user
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar usuario: " + ex.Message);
                }
            }



        }
        // Manejador de evento para el clic en el botón de actualizar
        private void btactualizar_Click(object sender, EventArgs e)
        {
            try
            {          // Verifica si se ha seleccionado una fila en el DataGridView
                if (registro.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(registro.SelectedRows[0].Cells["IdUsuario"].Value);
                    // Crea una instancia de Usuario con los datos del formulario
                    var usuario = new Capa_Entidades.Usuarios
                    {
                        IdUsuario = id,
                        NombreUsuario = txtnombre.Text,
                        ApellidoUsuario = txtapellido.Text,
                        FechaNacimientoUsuario = datefecha.Value,
                        TipoUsuario = combotipo.SelectedItem?.ToString(), // Tipo de usuario seleccionado
                        Usuario = txtusuario.Text,
                        Contraseña = txtcontraseña.Text
                    };
                    // Llama al servicio para modificar el usuario
                    _centroServicios.ModificarUsuario(usuario);
                    MessageBox.Show("Usuario actualizado exitosamente.");
                    LimpiarCampos();
                    LoadData(); // Refresh data after updating a user
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un usuario para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message);
            }
        }

        // Manejador de eventos para el clic en el botón de eliminar
        private void bteliminar_Click(object sender, EventArgs e)
        {     // Verifica si se ha seleccionado una fila en el DataGridView
            if (registro.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(registro.SelectedRows[0].Cells["IdUsuario"].Value);
                // Muestra un mensaje de confirmación para eliminar el usuario
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Llama al servicio para eliminar el usuario
                        _centroServicios.EliminarUsuario(id);
                        MessageBox.Show("Usuario eliminado exitosamente.");
                        LoadData(); // Refresh data after deleting a user
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar usuario: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.");
            }
        }

        // Método para configurar las columnas del DataGridView
        private void InitializeDataGridViews()
        {
            // Configuración para dataGridViewUsuarios
            ConfigureDataGridView(registro, new[]
            {
            new { Name = "IdUsuario", HeaderText = "ID Usuario", Width = 100 },
            new { Name = "NombreUsuario", HeaderText = "Nombre", Width = 200 },
            new { Name = "ApellidoUsuario", HeaderText = "Apellido", Width = 200 },
            new { Name = "FechaNacimientoUsuario", HeaderText = "Fecha Nacimiento", Width = 150 },
            new { Name = "TipoUsuario", HeaderText = "Tipo Usuario", Width = 150 },
            new { Name = "Usuario", HeaderText = "Usuario", Width = 150 },
            new { Name = "Contraseña", HeaderText = "Contraseña", Width = 150 }
        });
        }
        // Método para configurar las columnas del DataGridView
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
                var usuarios = _centroServicios.BuscarTodosLosUsuarios();
                registro.DataSource = usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message + "\nStackTrace: " + ex.StackTrace);
            }
        }

        //metodo para limpiar los controles
        private void LimpiarCampos()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            datefecha.Value = DateTime.Now;
            combotipo.SelectedIndex = -1;
            txtusuario.Clear();
            txtcontraseña.Clear();
        }
        // Manejador de eventos para el clic en una celda del DataGridView
        private void registro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que se haya seleccionado una fila válida
            {
                DataGridViewRow row = registro.Rows[e.RowIndex];
                // Asigna los valores de la fila seleccionada a los controles del formulario
                txtnombre.Text = row.Cells["NombreUsuario"].Value?.ToString() ?? string.Empty;
                txtapellido.Text = row.Cells["ApellidoUsuario"].Value?.ToString() ?? string.Empty;
                if (DateTime.TryParse(row.Cells["FechaNacimientoUsuario"].Value?.ToString(), out DateTime fechaNacimiento))
                {
                    datefecha.Value = fechaNacimiento;
                }
                else
                {
                    datefecha.Value = DateTime.Now;
                }
                combotipo.SelectedItem = row.Cells["TipoUsuario"].Value?.ToString() ?? string.Empty;
                txtusuario.Text = row.Cells["Usuario"].Value?.ToString() ?? string.Empty;
                txtcontraseña.Text = row.Cells["Contraseña"].Value?.ToString() ?? string.Empty;
            }
        }
    }
}
