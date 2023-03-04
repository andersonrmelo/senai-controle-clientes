namespace ControleClientes
{
    class PessoaFisica : Cliente
    {
        public string cpf {get; set;}
        public string rg {get; set;}

        public bool CpfValido()
        {
            if (this.cpf.Length < 11 || this.cpf.Length > 11)
            {
                return false;
            }

            for (int i = 0; i <= 9; i++)
            {
                string numeroInvalido = $"{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}";
                if (this.cpf.Equals(numeroInvalido))
                {
                    return false;
                }
            }

            ulong numeroCpf = ulong.Parse(this.cpf);
            ulong numeroCpfTemp = numeroCpf;
            
            ulong[] digitosVerificadores = new ulong[2];
            for (int i = 0; i < 2; i++)
            {
                digitosVerificadores[i] = numeroCpfTemp % 10;
                numeroCpfTemp = numeroCpfTemp / 10;
            }

            ulong modifier = 2;
            ulong[] digitosChecksum1 = new ulong[9];
            for (int i = 0; i < 9; i++)
            {
                digitosChecksum1[i] = numeroCpfTemp % 10;
                numeroCpfTemp = numeroCpfTemp / 10;
                digitosChecksum1[i] = digitosChecksum1[i] * modifier;
                modifier = modifier + 1;
            }

            ulong checksum = 0;
            for (int i = 0; i < 9; i++)
            {
                checksum = checksum + digitosChecksum1[i];
            }

            ulong digitoVerificador = 0;
            ulong moduloChecksum = checksum % 11;

            if (moduloChecksum < 2)
            {
                digitoVerificador = 0;
            }

            if (moduloChecksum >= 2)
            {
                digitoVerificador = 11 - moduloChecksum;
            }

            if (digitoVerificador != digitosVerificadores[1])
            {
                return false;
            }

            ulong[] digitosChecksum2 = new ulong[10];
            
            numeroCpfTemp = ulong.Parse(this.cpf.Remove(10));
            modifier = 2;
            for (int i = 0; i < 10; i++)
            {
                digitosChecksum2[i] = numeroCpfTemp % 10;
                numeroCpfTemp = numeroCpfTemp / 10;
                digitosChecksum2[i] = digitosChecksum2[i] * modifier;
                modifier = modifier + 1;
            }
            
            checksum = 0;
            for (int i = 0; i < 10; i++)
            {
                checksum = checksum + digitosChecksum2[i];
            }

            digitoVerificador = 0;
            moduloChecksum = checksum % 11;

            if (moduloChecksum < 2)
            {
                digitoVerificador = 0;
            }

            if (moduloChecksum >= 2)
            {
                digitoVerificador = 11 - moduloChecksum;
            }

            if (digitoVerificador != digitosVerificadores[0])
            {
                return false;
            }
            
            return true;
        }
    }
}
