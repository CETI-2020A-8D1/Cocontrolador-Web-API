using System;
using System.Collections.Generic;

namespace CocontroladorAPI.Models
{
    /// <summary>
    /// Este es el modelo que relaciona la tabla Libros
    /// </summary>
    public partial class MtoCatLibros
    {
        /// <summary>
        /// Aqui se relaciona la llave foranea de compras
        /// </summary>
        public MtoCatLibros()
        {
            TraConceptoCompra = new HashSet<TraConceptoCompra>();
        }

        public int Idlibro { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Sinopsis { get; set; }
        public bool Descontinuado { get; set; }
        public int Paginas { get; set; }
        public int Revision { get; set; }
        public int Ano { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int Ideditorial { get; set; }
        public int Idpais { get; set; }
        public int Idcategoria { get; set; }
        public string Imagen { get; set; }

        public virtual CatCategorias IdcategoriaNavigation { get; set; }
        public virtual CatEditorial IdeditorialNavigation { get; set; }
        public virtual CatPaises IdpaisNavigation { get; set; }
        public virtual ICollection<TraConceptoCompra> TraConceptoCompra { get; set; }
    }
}
