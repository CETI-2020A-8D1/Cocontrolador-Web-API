using System;
using System.Collections.Generic;

namespace CocontroladorAPI.Models
{
    /// <summary>
    /// Este es el modelo que se relaciona con los usuarios
    /// </summary>
    public partial class MtoCatUsuarios
    {
        /// <summary>
        /// Aqui se relaciona la tabla de usuarios con las llaves foraneas de Direcciones y de compras
        /// </summary>
        public MtoCatUsuarios()
        {
            CatDirecciones = new HashSet<CatDirecciones>();
            TraCompras = new HashSet<TraCompras>();
        }

        public int Idusuario { get; set; }
        public string IDidentity { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<CatDirecciones> CatDirecciones { get; set; }
        public virtual ICollection<TraCompras> TraCompras { get; set; }
    }
}
