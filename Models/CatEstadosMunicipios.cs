using System;
using System.Collections.Generic;

namespace CocontroladorAPI.Models
{

    /**
     * Clase CatCategorias
     * 
     * Esta clase es la base para el objeto de la tabla con el mismo nombre,
     * todas las variables en el son las columans de la tabla y una dos listas
     * que son las tablas foraneas a esta.
     * 
     */
    public partial class CatEstadosMunicipios
    {
        public int IdestadoMunicipio { get; set; }
        public int Idestado { get; set; }
        public int Idmunicipio { get; set; }

        public virtual CatEstados IdestadoNavigation { get; set; }
        public virtual CatMunicipios IdmunicipioNavigation { get; set; }
    }
}
