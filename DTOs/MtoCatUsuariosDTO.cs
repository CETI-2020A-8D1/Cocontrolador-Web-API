using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class MtoCatUsuariosDTO
    {
        public int Idusuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual List<CatDireccionesDTO> CatDirecciones { get; set; }
        public virtual List<TraComprasDTO> TraCompras { get; set; }
    }
}
