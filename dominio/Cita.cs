using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Cita
    {

        public int CitaID { get; set; }        
        public int ClienteID { get; set; }       
        public int ServicioID { get; set; }     
        public int EmpleadoID { get; set; }      
        public DateTime FechaHora { get; set; }  
        public string Estado { get; set; }

    }
}
