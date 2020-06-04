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
    public partial class CatDirecciones
    {
        public int Iddireccion { get; set; }
        public int Idusuario { get; set; }
        public int Idmunicipio { get; set; }
        public string NoInterior { get; set; }
        public int NoExterior { get; set; }
        public int CodigoPostal { get; set; }
        public string Calle { get; set; }

        public virtual CatMunicipios IdmunicipioNavigation { get; set; }
        public virtual MtoCatUsuarios IdusuarioNavigation { get; set; }
    }
}
