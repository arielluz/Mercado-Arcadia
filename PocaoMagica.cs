using System;

public class PocaoMagica : ItemMagico
{
    private string efeito;
    private int duracao;

    public PocaoMagica(string nome, double preco, int quantidade, Raridade raridade, string efeito, int duracao)
        : base(nome, preco, quantidade, raridade)
    {
        setEfeito(efeito);
        setDuracao(duracao);
    }

    public string getEfeito() { return efeito; }
    public int getDuracao() { return duracao; }

    public void setEfeito(string efeito)
    {
        this.efeito = efeito;
    }

    public void setDuracao(int duracao)
    {
        if (duracao < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro: Duração não pode ser negativa! Definindo como 0.");
            Console.ResetColor();
            this.duracao = 0;
        }
        else
        {
            this.duracao = duracao;
        }
    }

    public override double CalcularPrecoFinal()
    {

        return getPreco() * 0.9;
    }

    public override string ToString()
    {
        ConsoleColor corOriginal = Console.ForegroundColor;

        if (getRaridade() == Raridade.Epico)
            Console.ForegroundColor = ConsoleColor.Magenta;

        else if (getRaridade() == Raridade.Raro)
            Console.ForegroundColor = ConsoleColor.Green;

        else if (getRaridade() == Raridade.Comum)
            Console.ForegroundColor = ConsoleColor.Blue;


        string texto = $" POÇÃO ID:{getId()} | {getNome()} | Efeito: {efeito} | Duração: {duracao}s | " +
                      $"Preço: {getPreco():C2} | Preço Final: {CalcularPrecoFinal():C2} | " +
                      $"Qtd: {getQuantidade()} | {getRaridade()}";


        Console.ForegroundColor = corOriginal;
        return texto;


    }



    public void Usar()
    {
        if (getQuantidade() > 0)
        {
            setQuantidade(getQuantidade() - 1);
            Console.WriteLine($" Você usou {getNome()}! Efeito: {efeito} por {duracao} segundos.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Não há {getNome()} em estoque!");
            Console.ResetColor();
        }
    }
}