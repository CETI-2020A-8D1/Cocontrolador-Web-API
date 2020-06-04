using System;
using System.Collections.Generic;

namespace CocontroladorAPI.Models
{
    /// <summary>
    /// Este modelo es el que referencia la tabla paises de la base de datos
    /// </summary>
    public partial class CatPaises
    {
        /// <summary>
        /// Esta función relaciona las llaves foraneas de la tabla de libros con la tabla paises 
        /// </summary>
        public CatPaises()
        {
            MtoCatLibros = new HashSet<MtoCatLibros>();
        }

        public int Idpais { get; set; }
        public string Nombre { get; set; }
        public string Iso3 { get; set; }

        public virtual ICollection<MtoCatLibros> MtoCatLibros { get; set; }
    }
}
