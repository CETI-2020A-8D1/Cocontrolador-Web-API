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
        public int Idcliente { get; set; }

        public MtoCatClienteDTO IdclienteNavigation { get; set; }
        public List<TraConceptoCompraDTO> TraConceptoCompra { get; set; }
    }
}
