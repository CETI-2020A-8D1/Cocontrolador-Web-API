using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class TraComprasDTO
    {
        public int Idcompra { get; set; }
        public decimal? PrecioTotal { get; set; }
        public DateTime? FechaCompra { get; set; }
        public bool Pagado { get; set; }
        public int Idusuario { get; set; }

        public virtual MtoCatUsuariosDTO IdusuarioNavigation { get; set; }
        public virtual List<TraConceptoCompraDTO> TraConceptoCompra { get; set; }
    }
}
