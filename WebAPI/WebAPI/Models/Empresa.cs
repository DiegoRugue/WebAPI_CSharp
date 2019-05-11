using System;

namespace WebAPI.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataCadastro { get; set; }
        public string DataAlteracao { get; set; }
        public string CNPJ { get; set; }

    }
}
