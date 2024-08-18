using CLAVEADMIN1;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace REGISTRO
{
    public partial class Form1 : Form
    {
        // Actualiza la cadena de conexión con la información de tu servidor y base de datos
        private const string connectionString = "Server=ISMAEL;Database=Usuarios;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            this.Text = "Registro de Usuario"; // Establece el texto del formulario
            this.Load += new System.EventHandler(this.Form1_Load); // Maneja el evento Load del formulario
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown); // Maneja el evento MouseDown del formulario
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código a ejecutar cuando se carga el formulario
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Código a ejecutar cuando se hace clic en el formulario
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) // Si se intenta marcar el CheckBox
            {
                using (FormPassword passwordForm = new FormPassword())
                {
                    if (passwordForm.ShowDialog() == DialogResult.OK)
                    {
                        string enteredPassword = passwordForm.Password;
                        string correctPassword = "admin"; // Cambia esto por la contraseña correcta

                        if (enteredPassword == correctPassword)
                        {
                            checkBox1.Checked = true; // Permitir que se marque
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            checkBox1.Checked = false; // Revertir el cambio
                        }
                    }
                    else
                    {
                        checkBox1.Checked = false; // Si cancelaron, no se marca el CheckBox
                    }
                }
            }
            else
            {
                // Opcional: Puedes agregar código aquí para manejar el caso en que desmarcan el CheckBox
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validación simple de los campos
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string userType = checkBox1.Checked ? "Admin" : "Usuario";

            // Guardar en la base de datos
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Usuarios (Usuario, Contraseña, Rol) VALUES (@Usuario, @Contraseña, @Rol)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", textBox2.Text);
                        command.Parameters.AddWithValue("@Contraseña", textBox3.Text); // Considera usar hashing para contraseñas
                        command.Parameters.AddWithValue("@Rol", userType);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Código para manejar el evento de clic en label2
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Código para manejar el cambio de selección en comboBox1
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Código para manejar el evento de clic en label4
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            // Código para manejar el cambio de texto en textBox1
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Validación simple de los campos
            if (string.IsNullOrWhiteSpace(textBox2.Text) || // Usuario
                string.IsNullOrWhiteSpace(textBox3.Text))   // Contraseña
            {
                MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string rol = checkBox1.Checked ? "Admin" : "Usuario"; // Determina si el rol es Admin o Usuario

            // Guardar en la base de datos
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Usuarios (Usuario, Contraseña, Rol) VALUES (@Usuario, @Contraseña, @Rol)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", textBox2.Text);
                        command.Parameters.AddWithValue("@Contraseña", textBox3.Text); // Considera usar hashing para contraseñas
                        command.Parameters.AddWithValue("@Rol", rol);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
