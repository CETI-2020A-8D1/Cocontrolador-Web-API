using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class CatEstadosMunicipiosDTO
    {
        public int IdestadoMunicipio { get; set; }
        public int Idestado { get; set; }
        public int Idmunicipio { get; set; }

        public virtual CatEstadosDTO IdestadoNavigation { get; set; }
        public virtual CatMunicipiosDTO IdmunicipioNavigation { get; set; }
    }
}
