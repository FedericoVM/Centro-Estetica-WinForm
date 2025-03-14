using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using basesDatos;

namespace negocio
{
    public class ClienteNegocio
    {

		public List<Cliente> listarClientes()
		{
			accesoBD baseDatos = new accesoBD();

			List<Cliente> clientes = new List<Cliente>();

			try
			{
				baseDatos.setConsulta("Select * from Clientes");
				baseDatos.solicitarDatos();

                while (baseDatos.Lector.Read())
                {
					Cliente auxiliar = new Cliente();
					auxiliar.IdCliente = (int)baseDatos.Lector["IdCliente"];
					auxiliar.Nombre = (string)baseDatos.Lector["Nombre"];
					auxiliar.Apellido = (string)baseDatos.Lector["Apellido"];
					auxiliar.Dni = (string)baseDatos.Lector["DNI"];
					auxiliar.Telefono = (string)baseDatos.Lector["Telefono"];
					auxiliar.Email = (string)baseDatos.Lector["Email"];
					auxiliar.FechaNacimiento = (DateTime)baseDatos.Lector["FechaNacimiento"];
					auxiliar.FechaRegistro = (DateTime)baseDatos.Lector["FechaRegistro"];

					clientes.Add(auxiliar);
                }



                return clientes;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }




    }
}
