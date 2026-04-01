

public class ArmaMagica : ItemMagico
{
    private int dano;
    private string tipo;

    public ArmaMagica(string nome, double preco, int quantidade, Raridade raridade, int dano, string tipo)
        : base(nome, preco, quantidade, raridade)
    {
        setDano(dano);
        setTipo(tipo);
    }

    public int getDano() { return dano; }
    public string getTipo() { return tipo; }

    public void setDano(int dano)
    {
        if (dano < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro: Dano não pode ser negativo! Definindo como 0.");
            Console.ResetColor();
            this.dano = 0;
        }
        else
        {
            this.dano = dano;
        }
    }

    public void setTipo(string tipo)
    {
        this.tipo = tipo;
    }

    public override double CalcularPrecoFinal()
    {

        return getPreco() * 1.05;
    }

    public override string ToString()
    {

        ;
        string texto = $" ARMA ID:{getId()} | {getNome()} | Tipo: {tipo} | Dano: {dano} | " +
                      $"Preço: {getPreco():C2} | Preço Final: {CalcularPrecoFinal():C2} | " +
                      $"Qtd: {getQuantidade()} | {getRaridade()}";

        ConsoleColor corOriginal = Console.ForegroundColor;

        if (getRaridade() == Raridade.Epico)
            Console.ForegroundColor = ConsoleColor.Magenta;

        else if (getRaridade() == Raridade.Raro)
            Console.ForegroundColor = ConsoleColor.Green;

        else if (getRaridade() == Raridade.Comum)
            Console.ForegroundColor = ConsoleColor.Blue;




        Console.ForegroundColor = corOriginal;
        return texto;

    }
}