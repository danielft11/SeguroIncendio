using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguroIncendio.Models
{
    public class CategoriaImovel
    {
        public int CategoriaImovelId { get; set; }
        public string CategoriaDesc { get; set; }

        public virtual ICollection<TipoImovel> TiposImovel { get; set; }
    }
}