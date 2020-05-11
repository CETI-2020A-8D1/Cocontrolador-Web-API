using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class CatCategoriasDTO
    {
        public int Idcategoria { get; set; }
        public string Nombre { get; set; }

        public virtual List<MtoCatLibrosDTO> MtoCatLibros { get; set; }
    }
}
