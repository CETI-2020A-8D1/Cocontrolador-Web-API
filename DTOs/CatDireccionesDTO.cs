using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocontroladorAPI.DTOs
{
    public class CatDireccionesDTO
    {
        public int Iddireccion { get; set; }
        public int Idusuario { get; set; }
        public int Idmunicipio { get; set; }
        public string NoInterior { get; set; }
        public int NoExterior { get; set; }
        public int CodigoPostal { get; set; }
        public string Calle { get; set; }

        public virtual CatMunicipiosDTO IdmunicipioNavigation { get; set; }
        public virtual MtoCatUsuariosDTO IdusuarioNavigation { get; set; }
    }
}
