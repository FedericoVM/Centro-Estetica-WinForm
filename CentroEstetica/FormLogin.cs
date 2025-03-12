using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace CentroEstetica
{
    public partial class FormLogin : Form
    {
        FormPrincipal paginaPrincipal = new FormPrincipal();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCerrarLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            labelUsuarioContraseniaIncorrecto.Text = "";

            string nombreUsuario = txtUsuario.Text;
            string contraseniaUsuario = txtContrasenia.Text;


            if (string.IsNullOrEmpty(nombreUsuario) && string.IsNullOrEmpty(contraseniaUsuario) )
            {
                labelUsuarioContraseniaIncorrecto.Text = "LOS CAMPOS NO PUEDEN ESTAR VACIOS";
                return;
            }

            try
            {

                UsuarioNegocio negocioUsuario = new UsuarioNegocio();

                Usuario usuario = negocioUsuario.ingresoPersonal(nombreUsuario, contraseniaUsuario);

          
                if (usuario == null)
                {
                    labelUsuarioContraseniaIncorrecto.Text = "USUARIO O CONTRASEÑA INCORRECTA";
                    return;

                }


                switch (usuario.Rol)
                {

                    case "Dueña":
                        this.Hide();
                        paginaPrincipal.ShowDialog();
                        
                        break;
                    case "Empleado":
                        this.Hide();
                        paginaPrincipal.ShowDialog();
                        
                        break;
                    default:
                        MessageBox.Show("Rol no reconocido");
                        break;
                }

                Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
            }

        }

        private void txtContrasenia_Enter(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "Contraseña")
            {
                txtContrasenia.Text = "";
            }
        }
    }
}
