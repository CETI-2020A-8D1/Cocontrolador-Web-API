using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class CatPaisesDTO
    {
        public int Idpais { get; set; }
        public string Nombre { get; set; }
        public string Iso3 { get; set; }

        public virtual List<MtoCatLibrosDTO> MtoCatLibros { get; set; }
    }
}
