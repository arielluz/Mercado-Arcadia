using System;

public class ItemMagico
{
    private static int contadorID = 0;
    private int id;
    private string nome;
    private double preco;
    private int quantidade;
    private Raridade raridade;

    public ItemMagico()
    {
        contadorID++;
        id = contadorID;
    }

    public ItemMagico(string nome, double preco, int quantidade, Raridade raridade)
    {
        contadorID++;
        id = contadorID;
        setNome(nome);
        setPreco(preco);
        setQuantidade(quantidade);
        setRaridade(raridade);
    }

    public int getId() { return id; }
    public string getNome() { return nome; }
    public double getPreco() { return preco; }
    public int getQuantidade() { return quantidade; }
    public Raridade getRaridade() { return raridade; }

    public void setNome(string nome)
    {
        this.nome = nome;
    }

    public void setPreco(double preco)
    {
        if (preco <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro: Preço deve ser maior que zero! Definindo como 10.");
            Console.ResetColor();
            this.preco = 10;
        }
        else
        {
            this.preco = preco;
        }
    }

    public void setQuantidade(int quantidade)
    {
        if (quantidade < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro: Quantidade não pode ser negativa! Definindo como 0.");
            Console.ResetColor();
            this.quantidade = 0;
        }
        else
        {
            this.quantidade = quantidade;
        }
    }

    public void setRaridade(Raridade raridade)
    {
        this.raridade = raridade;
    }

    public virtual double CalcularPrecoFinal()
    {
        return preco;
    }

    public override string ToString()
    {
        ConsoleColor corOriginal = Console.ForegroundColor;

        if (raridade == Raridade.Epico)
            Console.ForegroundColor = ConsoleColor.Magenta;

        else if (getRaridade() == Raridade.Raro)
            Console.ForegroundColor = ConsoleColor.Green;

        else if (getRaridade() == Raridade.Comum)
            Console.ForegroundColor = ConsoleColor.Green;

        string texto = $"ID: {id} | {nome} | Preço: {preco:C2} | Qtd: {quantidade} | Raridade: {raridade}";


        Console.ForegroundColor = corOriginal;
        return texto;
    }

    public void ExibirStatus()
    {
        Console.WriteLine(ToString());
    }
}