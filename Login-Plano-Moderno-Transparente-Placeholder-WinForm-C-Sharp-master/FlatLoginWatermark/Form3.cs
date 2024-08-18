using System;
using System.Windows.Forms;

namespace FlatLoginWatermark
{
    public partial class Form3 : Form
    {
        public string UserRole { get; set; } // Propiedad para recibir el rol del usuario

        public Form3()
        {
            InitializeComponent();
            ConfigureUserAccess(); // Configura el acceso del usuario según el rol
        }

        private void ConfigureUserAccess()
        {
            // Desactiva la opción de cambiar de paciente por defecto
            cambiarDePacienteToolStripMenuItem.Enabled = false;

            // Habilita la opción si el usuario es admin
            if (UserRole == "admin")
            {
                cambiarDePacienteToolStripMenuItem.Enabled = true;
            }
        }

        private void cambiarDePacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implementa la lógica para cambiar de paciente aquí
            MessageBox.Show("Opción de cambiar de paciente seleccionada.");
        }
    }
}
