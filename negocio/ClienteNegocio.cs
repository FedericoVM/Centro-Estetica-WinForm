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
			finally
			{
				baseDatos.cerrarConexion();
			}
        }

		public bool dniExistente(string dni)
		{
			accesoBD baseDatos = new accesoBD();
			try
			{
				baseDatos.setConsulta("Select DNI Clientes where DNI = @dni");
				baseDatos.setParemtros("@dni", dni);
				baseDatos.solicitarDatos();

                if (baseDatos.Lector.Read())
                {
					return true;
                }
                else
                {
					return false;
                }

            }
			catch (Exception)
			{

				throw;
			}

			finally
			{
				baseDatos.cerrarConexion();
			}
		}
		public void agregarCliente(Cliente cliente)
		{
			accesoBD baseDatos = new accesoBD();
			try
			{

                if (dniExistente(cliente.Dni))
                {
                    throw new Exception("Ya existe un cliente con el mismo DNI.");
                }


                baseDatos.setConsulta("Insert Into Clientes (Nombre, Apellido, DNI, Telefono, Email, FechaNacimiento, FechaRegistro, Activo) VALUES(@nombre,@apellido,@dni,@telefono,@email,@fechaNacimiento,@fechaRegistro,1)");
				baseDatos.setParemtros("@nombre",cliente.Nombre);
                baseDatos.setParemtros("@apellido",cliente.Apellido);
                baseDatos.setParemtros("@dni", cliente.Dni);
                baseDatos.setParemtros("@telefono",cliente.Telefono);
                baseDatos.setParemtros("@email",cliente.Email);
                baseDatos.setParemtros("@fechaNacimiento",cliente.FechaNacimiento);
				baseDatos.setParemtros("@fechaRegistro", cliente.FechaRegistro);

				baseDatos.ejecutarLectura();
            }
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				baseDatos.cerrarConexion();
			}
		}

		
    }
}
