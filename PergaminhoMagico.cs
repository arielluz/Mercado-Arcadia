using System;

public class PergaminhoMagico : ItemMagico
{
    private string tipoMagia;
    private int nivelMagia;

    public PergaminhoMagico(string nome, double preco, int quantidade, Raridade raridade, string tipoMagia, int nivelMagia)
        : base(nome, preco, quantidade, raridade)
    {
        setTipoMagia(tipoMagia);
        setNivelMagia(nivelMagia);
    }

    public string getTipoMagia() { return tipoMagia; }
    public int getNivelMagia() { return nivelMagia; }

    public void setTipoMagia(string tipoMagia)
    {
        this.tipoMagia = tipoMagia;
    }

    public void setNivelMagia(int nivelMagia)
    {
        if (nivelMagia < 1 || nivelMagia > 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro: Nível de magia deve ser entre 1 e 5! Definindo como 1.");
            Console.ResetColor();
            this.nivelMagia = 1;
        }
        else
        {
            this.nivelMagia = nivelMagia;
        }
    }

    public override double CalcularPrecoFinal()
    {

        double multiplicador = 1.0;
        switch (getRaridade())
        {
            case Raridade.Raro:
                multiplicador = 1.2;
                break;
            case Raridade.Epico:
                multiplicador = 1.5;
                break;
        }
        return getPreco() * multiplicador;
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


        string texto = $" PERGAMINHO ID:{getId()} | {getNome()} | Magia: {tipoMagia} | Nível: {nivelMagia} | " +
                      $"Preço: {getPreco():C2} | Preço Final: {CalcularPrecoFinal():C2} | " +
                      $"Qtd: {getQuantidade()} | {getRaridade()}";

        Console.ForegroundColor = corOriginal;
        return texto;

    }


    public void Ler()
    {
        Console.WriteLine($" Você leu o pergaminho {getNome()}!");
        Console.WriteLine($"   Magia: {tipoMagia} (Nível {nivelMagia})");
    }
}