using Xunit;
namespace ControleClientes
{    
    public class PessoaFisicaTest
    {
        [Fact]
        public void TesteValidadeCpfFalso()
        {
            PessoaFisica pessoaFisica = new PessoaFisica();

            for (int i = 0; i <= 9; i++)
            {
                string numeroInvalido = $"{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}";
                pessoaFisica.cpf = numeroInvalido;
                Assert.Equal(false, pessoaFisica.CpfValido());
            }

            pessoaFisica.cpf = "1234567891";
            Assert.Equal(false, pessoaFisica.CpfValido());

            pessoaFisica.cpf = "1234567893231";
            Assert.Equal(false, pessoaFisica.CpfValido());

            pessoaFisica.cpf = "0";
            Assert.Equal(false, pessoaFisica.CpfValido());

            pessoaFisica.cpf = "-98408788086";
            Assert.Equal(false, pessoaFisica.CpfValido());
        }

        [Fact]
        public void TesteValidadeCpfVerdadeiro()
        {
            PessoaFisica pessoaFisica = new PessoaFisica();

            pessoaFisica.cpf = "98408788086";
            Assert.Equal(true, pessoaFisica.CpfValido());

            pessoaFisica.cpf = "65952669034";
            Assert.Equal(true, pessoaFisica.CpfValido());

            pessoaFisica.cpf = "94859461045";
            Assert.Equal(true, pessoaFisica.CpfValido());
        }

    }
}