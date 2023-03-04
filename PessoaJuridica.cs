namespace ControleClientes
{
    class PessoaJuridica : Cliente
    {
        public string cnpj {get; set;}
        public string inscricaoEstadual {get; set;}

        public override void PagarImposto(float valor)
        {
            this.valor = valor;
            this.valorImposto = this.valor * 20 / 100;
            this.valorTotal = this.valor + this.valorImposto;
        }

        public bool CnpjValido()
        {
            if (this.cnpj.Length < 14 || this.cnpj.Length > 14)
            {
                return false;
            }

            for (int i = 0; i <= 9; i++)
            {
                string numeroInvalido = $"{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}";
                if (this.cnpj.Equals(numeroInvalido))
                {
                    return false;
                }
            }

            ulong numerpCnpj = ulong.Parse(this.cnpj);
            ulong numeroCnpjTemp = numerpCnpj;

            ulong[] digitosVerificadores = new ulong[2];
            for (int i = 0; i < 2; i++)
            {
                digitosVerificadores[i] = numeroCnpjTemp % 10;
                numeroCnpjTemp = numeroCnpjTemp / 10;
            }

            ulong modifier = 2;
            ulong[] digitosChecksum1 = new ulong[12];
            for (int i = 0; i < 12; i++)
            {
                if (modifier > 9)
                {
                    modifier = 2;
                }
                digitosChecksum1[i] = numeroCnpjTemp % 10;
                numeroCnpjTemp = numeroCnpjTemp / 10;
                digitosChecksum1[i] = digitosChecksum1[i] * modifier;
                modifier = modifier + 1;
            }

            ulong checksum = 0;
            for (int i = 0; i < 12; i++)
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

            ulong[] digitosChecksum2 = new ulong[13];

            numeroCnpjTemp = ulong.Parse(this.cnpj.Remove(13));
            modifier = 2;
            for (int i = 0; i < 13; i++)
            {
                if (modifier > 9)
                {
                    modifier = 2;
                }
                digitosChecksum2[i] = numeroCnpjTemp % 10;
                numeroCnpjTemp = numeroCnpjTemp / 10;
                digitosChecksum2[i] = digitosChecksum2[i] * modifier;
                modifier = modifier + 1;
            }

            checksum = 0;
            for (int i = 0; i < 13; i++)
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