using System;
using System.Windows.Forms;

namespace CLAVEADMIN1
{
    public partial class FormPassword : Form
    {
        public string Password { get; private set; }

        public FormPassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Password = txtPassword.Text;

            // Verifica si la contraseña ingresada es "admin"
            if (Password == "admin")
            {
                this.DialogResult = DialogResult.OK; // Acepta el diálogo si la contraseña es correcta
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password = string.Empty; // Limpia la contraseña si es incorrecta
                txtPassword.Focus(); // Focaliza el campo de texto de la contraseña
                this.DialogResult = DialogResult.None; // No cierra el diálogo
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Opcional: Puedes agregar código aquí si deseas manejar eventos de cambio de texto
        }
    }
}
