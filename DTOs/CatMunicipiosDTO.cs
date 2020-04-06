using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class CatMunicipiosDTO
    {
        public int Idmunicipio { get; set; }
        public string Nombre { get; set; }

        public virtual List<CatDireccionesDTO> CatDirecciones { get; set; }
        public virtual List<CatEstadosMunicipiosDTO> CatEstadosMunicipios { get; set; }
    }
}
