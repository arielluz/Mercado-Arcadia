

public class Loja
{
    public List<ItemMagico> inventario;
    private string nomeLoja;
    private double caixa;

    public Loja(string nome)
    {
        this.nomeLoja = nome;
        this.inventario = new List<ItemMagico>();
        this.caixa = 500;
    }

    public string getNomeLoja() { return nomeLoja; }
    public double getCaixa() { return caixa; }


    public void AdicionarItem(ItemMagico item)
    {
        inventario.Add(item);
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine($" {item.getNome()} adicionado à loja! (ID: {item.getId()})");
        Console.ResetColor();
    }


    public void ListarNomeERaridade()
    {
        Console.WriteLine($"\n {nomeLoja.ToUpper()} - INVENTÁRIO");
        Console.WriteLine("═══════════════════════════════════");
        Console.WriteLine($"{"NOME",-25} | {"RARIDADE",-10}");
        Console.WriteLine("───────────────────────────────────");

        foreach (ItemMagico item in inventario)
        {
            if (item.getRaridade() == Raridade.Epico)
                Console.ForegroundColor = ConsoleColor.Magenta;

            else if (item.getRaridade() == Raridade.Raro)
                Console.ForegroundColor = ConsoleColor.Green;

            else if (item.getRaridade() == Raridade.Comum)
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine($"{item.getNome(),-25} | {item.getRaridade(),-10}");

            Console.ResetColor();
        }

        Console.WriteLine("───────────────────────────────────");
        Console.WriteLine($"Total de itens: {inventario.Count} | Caixa: {caixa:C2}");

        foreach (ItemMagico item in inventario)
        {
            if (item.getRaridade() == Raridade.Epico)
                Console.ForegroundColor = ConsoleColor.Magenta;

            else if (item.getRaridade() == Raridade.Raro)
                Console.ForegroundColor = ConsoleColor.Green;

            else if (item.getRaridade() == Raridade.Comum)
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine($"{item.getNome(),-25} | {item.getRaridade(),-10}");

            Console.ResetColor();
        }
    }



    public void ListarTodosDetalhes()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"\n DETALHES COMPLETOS - {nomeLoja}");
        Console.WriteLine("═══════════════════════════════════════════════════════════");

        if (inventario.Count == 0)
        {
            Console.WriteLine("Nenhum item na loja!");
            return;
        }

        foreach (ItemMagico item in inventario)
        {
            Console.WriteLine(item.ToString());
        }
    }

    public void ListarApenasArmas()
    {
        Console.WriteLine("\n ARMAS DISPONÍVEIS:");
        bool encontrou = false;

        foreach (ItemMagico item in inventario)
        {
            if (item is ArmaMagica arma)
            {
                Console.WriteLine(arma.ToString());
                encontrou = true;
            }
        }

        if (!encontrou)
            Console.WriteLine("Nenhuma arma disponível.");
    }

    public void ListarApenasPocoes()
    {
        Console.WriteLine("\n POÇÕES DISPONÍVEIS:");
        bool encontrou = false;

        foreach (ItemMagico item in inventario)
        {
            if (item is PocaoMagica pocao)
            {
                Console.WriteLine(pocao.ToString());
                encontrou = true;
            }
        }

        if (!encontrou)
            Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Nenhuma poção disponível.");
    }

    public void ListarApenasPergaminhos()
    {
        Console.WriteLine("\n PERGAMINHOS DISPONÍVEIS:");
        bool encontrou = false;

        foreach (ItemMagico item in inventario)
        {
            if (item is PergaminhoMagico pergaminho)
            {
                Console.WriteLine(pergaminho.ToString());
                encontrou = true;
            }
        }

        if (!encontrou)
            Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Nenhum pergaminho disponível.");
    }


    public void VenderItem(string nomeItem, int quantidade)
    {
        foreach (ItemMagico item in inventario)
        {
            if (item.getNome().ToLower().Contains(nomeItem.ToLower()))
            {
                if (item.getQuantidade() >= quantidade)
                {
                    double valorVenda = item.CalcularPrecoFinal() * quantidade;
                    item.setQuantidade(item.getQuantidade() - quantidade);
                    caixa += valorVenda;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" Vendido {quantidade}x {item.getNome()} por {valorVenda:C2}!");
                    Console.ResetColor();

                    if (item.getQuantidade() == 0)
                    {
                        Console.WriteLine($"  {item.getNome()} esgotou! Removendo do inventário.");
                        inventario.Remove(item);
                    }
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Estoque insuficiente! Temos apenas {item.getQuantidade()}");
                    Console.ResetColor();
                    return;
                }
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" Item '{nomeItem}' não encontrado!");
        Console.ResetColor();
    }


    public bool RemoverItemPorId(int id)
    {
        foreach (ItemMagico item in inventario)
        {
            if (item.getId() == id)
            {
                inventario.Remove(item);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($" Item ID {id} removido do inventário!");
                Console.ResetColor();
                return true;
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" Item com ID {id} não encontrado!");
        Console.ResetColor();
        return false;
    }


    public ItemMagico BuscarItemPorId(int id)
    {
        foreach (ItemMagico item in inventario)
        {
            if (item.getId() == id)
                return item;
        }
        return null;
    }


    public double CalcularValorTotalInventario()
    {
        double total = 0;
        foreach (ItemMagico item in inventario)
        {
            total += item.CalcularPrecoFinal() * item.getQuantidade();
        }
        return total;
    }
}