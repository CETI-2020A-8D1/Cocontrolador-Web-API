using System;
using System.Collections.Generic;

namespace CocontroladorAPI.Models
{

    /**
     * Clase CatCategorias
     * 
     * Esta clase es la base para el objeto de la tabla con el mismo nombre,
     * todas las variables en el son las columans de la tabla y cuenta con un constructor
     * que regresa la lista con los objeto de la tabla.
     * 
     */
    public partial class CatEstados
    {
        public CatEstados()
        {
            CatEstadosMunicipios = new HashSet<CatEstadosMunicipios>();
        }

        public int Idestado { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CatEstadosMunicipios> CatEstadosMunicipios { get; set; }
    }
}
