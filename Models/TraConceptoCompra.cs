using System;
using System.Collections.Generic;

namespace CocontroladorAPI.Models
{
    /// <summary>
    /// Este es el modelo que se relaciona con la tabla de concepto de la compra
    /// </summary>
    public partial class TraConceptoCompra
    {
        public int TraCompras { get; set; }
        public int Idcompra { get; set; }
        public int Idlibro { get; set; }
        public int Cantidad { get; set; }

        public virtual TraCompras IdcompraNavigation { get; set; }
        public virtual MtoCatLibros IdlibroNavigation { get; set; }
    }
}
