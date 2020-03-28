using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class MtoCatLibrosDTO
    {
        public int Idlibro { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
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

        public CatCategoriasDTO IdcategoriaNavigation { get; set; }
        public CatEditorialDTO IdeditorialNavigation { get; set; }
        public CatPaisesDTO IdpaisNavigation { get; set; }
        public List<TraConceptoCompraDTO> TraConceptoCompra { get; set; }
    }
}
