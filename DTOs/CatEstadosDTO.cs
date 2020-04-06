using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class CatEstadosDTO
    {
        public int Idestado { get; set; }
        public string Nombre { get; set; }

        public virtual List<CatEstadosMunicipiosDTO> CatEstadosMunicipios { get; set; }
    }
}
