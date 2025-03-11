using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public string Rol { get; set; }
        public Empleado EmpleadoId { get; set; }
    }
}
