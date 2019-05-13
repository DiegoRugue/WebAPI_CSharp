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

        public override string ToString() {
            string toString;

            toString = "Dependente: { \n" +
                       "  Id: " + Id + "\n" +
                       "  Nome:" + Nome + "\n" +
                       "  CPF:" + CPF + "\n" +
                       "  DataNascimento:" + DataNascimento + "\n" +
                       "  IdParentesco:" + IdParentesco + "\n" +
                       "  DataCadastro:" + DataCadastro + "\n" +
                       "  DataAlteracao:" + DataAlteracao + "\n" +
                       "} \n";

            return toString;
        }
    }
}
