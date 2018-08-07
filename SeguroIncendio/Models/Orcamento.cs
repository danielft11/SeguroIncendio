using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeguroIncendio.Models
{
    public class Orcamento
    {
        [DisplayName("Cód Orçamento")]
        public int OrcamentoId { get; set; }

        [DisplayName("Inquilino")]
        [MaxLength(150, ErrorMessage = "Este campo aceita, no máximo, 150 caracteres.")]
        [Required(ErrorMessage = "Informe o nome do inquilino.")]
        public string Inquilino { get; set; }

        public int TipoInquilino { get; set; }

        [DisplayName("CPF/CNPJ Inquilino")]
        [Required(ErrorMessage = "Informe o CPF ou CNPJ do inquilino.")]
        public string CpfCnpjInquilino { get; set; }

        [DisplayName("Proprietário")]
        [MaxLength(150, ErrorMessage = "Este campo aceita, no máximo, 150 caracteres.")]
        [Required(ErrorMessage = "Informe o nome do proprietário.")]
        public string Proprietario { get; set; }

        public int TipoProprietario { get; set; }

        [DisplayName("CPF/CNPJ Proprietário")]
        [Required(ErrorMessage = "Informe o CPF ou CNPJ do proprietário.")]
        public string CpfCnpjProprietario { get; set; }

        [Required(ErrorMessage = "Informe o CEP do imóvel.")]
        public string CEP { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "Informe o endereço do imóvel.")]
        public string Endereco { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Informe o número do imóvel.")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe o bairro do imóvel.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a cidade do imóvel.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o estado do imóvel.")]
        public string Estado { get; set; }

        [DisplayName("Valor do aluguel")]
        [Required(ErrorMessage ="Informe o valor do aluguel.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ValorAluguel { get; set; }

        public decimal ImportCobertIncendio { get; set; }
        public decimal PremioCobertIncendio { get; set; }
        public decimal ImportCobertPerda { get; set; }
        public decimal PremioCobertPerda { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Informe a categoria do imóvel.")]
        public int IdentificacaoCategoria { get; set; }

        [DisplayName("Tipo do imóvel")]
        [Required(ErrorMessage = "Informe o tipo do imóvel.")]
        public int TipoImovelId { get; set; }

        public TipoImovel tipoImovel { get; set; }
    }
}