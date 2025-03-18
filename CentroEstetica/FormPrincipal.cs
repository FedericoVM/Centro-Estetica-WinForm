using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace CentroEstetica
{
    public partial class FormPrincipal : Form
    {
        private Usuario usuario;
        private string rolUsuario;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        public FormPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            rolUsuario = usuario.Rol;

        }

        public void mostrarOpcionesSegunRol(string rol)
        {

            switch (rol)
            {
                case "Dueña":

                    btnInventario.Visible = true;
                    btnFinanzas.Visible = true;
                    btnPersonal.Visible = true;
                    break;
                case "Empleado":
                    btnInventario.Visible = false;
                    btnFinanzas.Visible = false;
                    btnPersonal.Visible = false;
                    break;
                default:
                    MessageBox.Show("Rol no reconocido");
                    this.Close();
                    break;
            }

        }


        private void btnCerrarVentana_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizarVentana_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizarVentana.Visible = false;
            btnRestaurarVentana.Visible = true;
        }

        private void btnMinimizarVentana_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurarVentana_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurarVentana.Visible = false;
            btnMaximizarVentana.Visible = true;
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //labelSaludos.Text = $"Bienvenido/a  {usuario.Nombre} - {usuario.Rol}";
            mostrarOpcionesSegunRol(rolUsuario);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            this.Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {

            mostrarFormulario(new FormClientes(rolUsuario));

        }

        private void mostrarFormulario(object formularioHijo)
        {
            if (this.panelContenedorFormulario.Controls.Count > 0)
            {
                this.panelContenedorFormulario.Controls.RemoveAt(0);
            }

            Form formularioH = formularioHijo as Form;
            formularioH.TopLevel = false;
            formularioH.Dock = DockStyle.Fill;
            this.panelContenedorFormulario.Controls.Add(formularioH);
            this.panelContenedorFormulario.Tag = formularioH;
            formularioH.Show();
        }











    }
}
