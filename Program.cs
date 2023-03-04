using System;
namespace ControleClientes
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool programaEncerrado = false;
            while (!programaEncerrado)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("CONTROLE DE CLIENTES | ClientLab");
                Console.WriteLine("--------------------------------");

                Console.WriteLine("Informar nome:");
                string varNome = Console.ReadLine();

                Console.WriteLine("Informar Endereço:");
                string varEndereco = Console.ReadLine();

                Console.WriteLine("Digite (F) para Pessoa Física ou (J) para Pessoa Jurídica:");
                string varTipo = Console.ReadLine().ToLower();

                while (varTipo != "f" && varTipo != "j")
                {
                    Console.WriteLine("ERRO: Escolha entre (F) p/ Pessoa Física ou (J) p/ Pessoa Jurídica:");
                    varTipo = Console.ReadLine();
                }

                if (varTipo.Equals("f"))
                {
                    PessoaFisica pessoaFisica = new PessoaFisica();
                    pessoaFisica.nome = varNome;
                    pessoaFisica.endereco = varEndereco;

                    Console.WriteLine("Informar CPF:");
                    pessoaFisica.cpf = Console.ReadLine();

                    while (!pessoaFisica.CpfValido())
                    {
                        Console.WriteLine("ERRO: CPF inválido, tente novamente:");
                        pessoaFisica.cpf = Console.ReadLine();
                    }
                    
                    Console.WriteLine("Informar RG:");
                    pessoaFisica.rg = Console.ReadLine();

                    Console.WriteLine("Informar Valor de Compra:");
                    float varPag = float.Parse(Console.ReadLine());

                    pessoaFisica.PagarImposto(varPag);

                    Console.WriteLine("-------- Pessoa Física ---------");
                    Console.WriteLine("Nome ..........: " + pessoaFisica.nome);
                    Console.WriteLine("Endereço ......: " + pessoaFisica.endereco);
                    Console.WriteLine("CPF ...........: " + pessoaFisica.cpf);
                    Console.WriteLine("RG ............: " + pessoaFisica.rg);
                    Console.WriteLine("Valor de Compra: " + pessoaFisica.valor.ToString("C"));
                    Console.WriteLine("Imposto .......: " + pessoaFisica.valorImposto.ToString("C"));
                    Console.WriteLine("Total a Pagar : " + pessoaFisica.valorTotal.ToString("C"));
                }

                if (varTipo.Equals("j"))
                {
                    PessoaJuridica pessoaJuridica = new PessoaJuridica();
                    pessoaJuridica.nome = varNome;
                    pessoaJuridica.endereco = varEndereco;

                    Console.WriteLine("Informar CNPJ:");
                    pessoaJuridica.cnpj = Console.ReadLine();

                    while (!pessoaJuridica.CnpjValido())
                    {
                        Console.WriteLine("ERRO: CNPJ inválido, tente novamente:");
                        pessoaJuridica.cnpj = Console.ReadLine();
                    }

                    Console.WriteLine("Informar IE:");
                    pessoaJuridica.inscricaoEstadual = Console.ReadLine();

                    Console.WriteLine("Informar Valor de Compra:");
                    float varPag = float.Parse(Console.ReadLine());

                    pessoaJuridica.PagarImposto(varPag);

                    Console.WriteLine("-------- Pessoa Jurídica ---------");
                    Console.WriteLine("Nome ..........: " + pessoaJuridica.nome);
                    Console.WriteLine("Endereço ......: " + pessoaJuridica.endereco);
                    Console.WriteLine("CNPJ ..........: " + pessoaJuridica.cnpj);
                    Console.WriteLine("IE ............: " + pessoaJuridica.inscricaoEstadual);
                    Console.WriteLine("Valor de Compra: " + pessoaJuridica.valor.ToString("C"));
                    Console.WriteLine("Imposto .......: " + pessoaJuridica.valorImposto.ToString("C"));
                    Console.WriteLine("Total a Pagar : " +  pessoaJuridica.valorTotal.ToString("C"));
                }
                
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Deseja continuar? S/N");
                string continuar = Console.ReadLine();
                
                if (continuar.ToLower().Equals("s"))
                {
                    programaEncerrado = false;
                } else {
                    programaEncerrado = true;
                }

                
            }
        }
    }
}
