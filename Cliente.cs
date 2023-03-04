namespace ControleClientes
{
    public abstract class Cliente
    {
        public string nome {get; set;}
        public string endereco {get; set;}
        public float valor {get; protected set;}
        public float valorImposto {get; protected set;}
        public float valorTotal {get; protected set;}

        public virtual void PagarImposto(float valor)
        {
            this.valor = valor;
            this.valorImposto = this.valor * 10 / 100;
            this.valorTotal = this.valor + this.valorImposto;
        }
        
    }
}