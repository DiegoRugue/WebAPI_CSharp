namespace WebAPI.Models
{
    public class Dependente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataCadastro { get; set; }
        public string DataAlteracao { get; set; }
        public string DataNascimento { get; set; }
        public int IdFuncionario { get; set; }
        public int IdParentesco { get; set; }

    }
}
