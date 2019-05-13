namespace WebAPI.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public int IdProfissao { get; set; }
        public string Telefone { get; set; }
        public int IdEmpresa { get; set; }
        public string DataCadastro { get; set; }
        public string DataAlteracao { get; set; }
        public int IdEstadoCivil { get; set; }
        public string EnderecoRua { get; set; }
        public int EnderecoNumero { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoEstado { get; set; }
        public string EnderecoCep { get; set; }
        public string EnderecoComplemento { get; set; }

        public override string ToString() {
            string toString;

            toString = "Funcionario: { \n" +
                       "  Id: " + Id + "\n" +
                       "  Nome:" + Nome + "\n" +
                       "  CPF:" + CPF + "\n" +
                       "  DataNascimento:" + DataNascimento + "\n" +
                       "  IdProfissao:" + IdProfissao + "\n" +
                       "  Telefone:" + Telefone + "\n" +
                       "  IdEmpresa:" + IdEmpresa + "\n" +
                       "  IdEstadoCivil:" + IdEstadoCivil + "\n" +
                       "  EnderecoRua:" + EnderecoRua + "\n" +
                       "  EnderecoNumero:" + EnderecoNumero + "\n" +
                       "  EnderecoBairro:" + EnderecoBairro + "\n" +
                       "  EnderecoCidade:" + EnderecoCidade + "\n" +
                       "  EnderecoEstado:" + EnderecoEstado + "\n" +
                       "  EnderecoCep:" + EnderecoCep + "\n" +
                       "  EnderecoComplemento:" + EnderecoComplemento + "\n" +
                       "  DataCadastro:" + DataCadastro + "\n" +
                       "  DataAlteracao:" + DataAlteracao + "\n" +
                       "} \n";

            return toString;
        }
    }
}
