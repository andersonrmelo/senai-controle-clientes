using Xunit;
namespace ControleClientes
{
    public class PessoaJuridicaTest 
    {
        [Fact]
        public void TesteValidadeCnpjFalso()
        {
            PessoaJuridica pessoaJuridica = new PessoaJuridica();

            for (int i = 0; i <= 9; i++)
            {
                string numeroInvalido = $"{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}";
                pessoaJuridica.cnpj = numeroInvalido;
                Assert.Equal(false, pessoaJuridica.CnpjValido());
            }

            pessoaJuridica.cnpj = "1234567891234";
            Assert.Equal(false, pessoaJuridica.CnpjValido());

            pessoaJuridica.cnpj = "123456789123456";
            Assert.Equal(false, pessoaJuridica.CnpjValido());

            pessoaJuridica.cnpj = "0";
            Assert.Equal(false, pessoaJuridica.CnpjValido());

            pessoaJuridica.cnpj = "-57356558000121";
            Assert.Equal(false, pessoaJuridica.CnpjValido());
        }

        [Fact]
        public void TesteValidadeCnpjVerdadeiro()
        {
            PessoaJuridica pessoaJuridica = new PessoaJuridica();

            pessoaJuridica.cnpj = "33564543000190";
            Assert.Equal(true, pessoaJuridica.CnpjValido());

            pessoaJuridica.cnpj = "57356558000121";
            Assert.Equal(true, pessoaJuridica.CnpjValido());

            pessoaJuridica.cnpj = "65863116000108";
            Assert.Equal(true, pessoaJuridica.CnpjValido());
        }
    }
}