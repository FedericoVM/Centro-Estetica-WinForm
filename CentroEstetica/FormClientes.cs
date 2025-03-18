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
    public partial class FormClientes: Form
    {
        private string rolUsuario;
        public FormClientes()
        {
            InitializeComponent();
        }
        public FormClientes(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;
        }

        private void visualizarBtnCrudAdm(bool ver)
        {
            btnBorrar.Visible = ver;
            btnEditar.Visible = ver;
        }

        private void clientesActivosInactivos()
        {
            List<Cliente> clientesAlta = new List<Cliente>();
            List<Cliente> clientesBaja = new List<Cliente>();
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                foreach (Cliente aux in negocio.listarClientes())
                {
                    if (aux.Activo == false)
                    {
                        clientesBaja.Add(aux);
                    }
                    else
                    {
                        clientesAlta.Add(aux);
                    }
                }

                mostrarCantidadClientesActivos(clientesAlta.Count());
                mostrarCantidadClientesInactivos(clientesBaja.Count());
                mostrarCantidadClientesTotales(clientesAlta.Count() + clientesBaja.Count());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarClientes()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {
                List<Cliente> clientes;
                clientes = negocio.listarClientes();
                DGVClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void mostrarCantidadClientesActivos(int num)
        {
            labelNumeroClientesActivos.Text = num.ToString();
        }

        private void mostrarCantidadClientesInactivos(int num)
        {
            labelNumeroClientesInactivos.Text = num.ToString();
        }

        private void mostrarCantidadClientesTotales(int num)
        {
            labelNumerosClientes.Text = num.ToString(); 
        }
        private void FormClientes_Load(object sender, EventArgs e)
        {
            clientesActivosInactivos();
            cargarClientes();
            if (rolUsuario == "Dueña")
            {
                cargarClientes();
            } else
            {
                cargarClientes();
                visualizarBtnCrudAdm(false);
            }
               
        }
    }
}
