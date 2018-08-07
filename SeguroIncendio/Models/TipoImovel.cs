using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguroIncendio.Models
{
    public class TipoImovel
    {
        public int TipoImovelId { get; set; }
        public string TipoImovelDesc { get; set; }
        public decimal TipoImovelTaxa { get; set; }

        public int CategoriaImovelId { get; set; }
        public virtual CategoriaImovel CategoriaImovel { get; set; }
    }
}