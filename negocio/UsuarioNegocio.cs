using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using basesDatos;

namespace negocio
{
    public class UsuarioNegocio
    {

       

        public Usuario ingresoPersonal(string nombre, string contrasenia)
        {
            accesoBD baseDatos = new accesoBD();

            try
            {
                Usuario usuario = null;
           
                baseDatos.setConsulta("Select * from Usuarios where NombreUsuario = @nombre AND Contraseña = @contrasenia");
                baseDatos.setParemtros("@nombre", nombre);
                baseDatos.setParemtros("@contrasenia", contrasenia);
                baseDatos.solicitarDatos();
                
                while (baseDatos.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.UsuarioId = (int)baseDatos.Lector["UsuarioID"];
                    usuario.Nombre = (string)baseDatos.Lector["NombreUsuario"];
                    usuario.Contrasenia = (string)baseDatos.Lector["Contraseña"];
                    usuario.Rol = (string)baseDatos.Lector["Rol"];
                    usuario.EmpleadoId = new Empleado();
                    usuario.EmpleadoId.EmpleadoID = (int)baseDatos.Lector["EmpleadoID"];
                }

                return usuario;
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

    }
}
