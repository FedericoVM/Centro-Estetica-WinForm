using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using basesDatos;

namespace negocio
{
    internal class UsuarioNegocio
    {
        public Usuario ingresoPersonal(string nombre, string contrasenia)
        {
            accesoBD baseDatos = new accesoBD();

            try
            {
                Usuario usuario = new Usuario();
                baseDatos.setConsulta("Select * from Usuarios where NombreUsuario = @nombre AND Contraseña = @contrasenia");
                baseDatos.setParemtros("@nombre", nombre);
                baseDatos.setParemtros("@contrasenia", contrasenia);
                baseDatos.solicitarDatos();


                return usuario;
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
