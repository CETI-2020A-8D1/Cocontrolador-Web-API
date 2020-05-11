using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class TraConceptoCompraDTO
    {
        public int TraCompras { get; set; }
        public int Idcompra { get; set; }
        public int Idlibro { get; set; }
        public int Cantidad { get; set; }

        public virtual TraComprasDTO IdcompraNavigation { get; set; }
        public virtual MtoCatLibrosDTO IdlibroNavigation { get; set; }
    }
}
