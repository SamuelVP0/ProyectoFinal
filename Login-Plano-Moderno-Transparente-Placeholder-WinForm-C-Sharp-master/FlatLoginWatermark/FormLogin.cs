using REGISTRO;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FlatLoginWatermark
{
    public partial class FormLogin : Form
    {
        private const string connectionString = "Server=ISMAEL;Database=Usuarios;Integrated Security=True;";
        private Form3 form3;
        private string userRole;

        public FormLogin()
        {
            InitializeComponent();
            form3 = new Form3();
            form3.Show(); // Muestra Form3 al iniciar la aplicación
            form3.Enabled = false; // Desactiva Form3 para que no sea accesible hasta el inicio de sesión
        }

        #region Drag Form / Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Placeholder or WaterMark
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
                txtuser.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
            }
        }
        #endregion 

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Cualquier inicialización que necesites al cargar el formulario
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpass.Text;

            // Verifica que el usuario y la contraseña no estén vacíos
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingrese el usuario y la contraseña.");
                return;
            }

            // Verifica si el usuario es válido y obtiene el rol
            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Inicio de sesión exitoso.");

                // Muestra Form3 y oculta FormLogin
                form3.UserRole = userRole; // Pasa el rol del usuario a Form3
                form3.Enabled = true;      // Habilita Form3
                form3.BringToFront();     // Lleva Form3 al frente
                this.Hide();              // Oculta FormLogin
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            bool isValid = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Rol FROM Usuarios WHERE Usuario = @username AND Contraseña = @password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        userRole = result.ToString(); // Obtiene el rol del usuario
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); // Crear una instancia de Form1 (o del formulario que quieras abrir)
            form1.Show(); // Mostrar Form1
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Aquí puedes agregar código para dibujar en el panel si es necesario
        }
    }
}
