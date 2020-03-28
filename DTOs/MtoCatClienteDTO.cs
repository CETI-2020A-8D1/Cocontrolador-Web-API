using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class MtoCatClienteDTO
    {
        public int Idcliente { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public List<TraComprasDTO> TraCompras { get; set; }
    }
}
