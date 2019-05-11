using System;

namespace WebAPI.Models
{
    public class Dependentes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdFuncionario { get; set; }
        public int IdParentesco { get; set; }

    }
}
