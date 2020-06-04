using System;
using System.Collections.Generic;

namespace CocontroladorAPI.Models
{
    /// <summary>
    /// Este es el modelo que se relaciona con la tabla Compras
    /// </summary>
    public partial class TraCompras
    {
        /// <summary>
        /// Esta es la funcion que relaciona las llaves foraneas del concepto de la compra
        /// </summary>
        public TraCompras()
        {
            TraConceptoCompra = new HashSet<TraConceptoCompra>();
        }

        public int Idcompra { get; set; }
        public decimal? PrecioTotal { get; set; }
        public DateTime? FechaCompra { get; set; }
        public bool Pagado { get; set; }
        public int Idusuario { get; set; }

        public virtual MtoCatUsuarios IdusuarioNavigation { get; set; }
        public virtual ICollection<TraConceptoCompra> TraConceptoCompra { get; set; }
    }
}
