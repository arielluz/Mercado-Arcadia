using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║           O MERCADOR DE ARCÁDIA        ║");
        Console.WriteLine("║     Sistema Mágico de Gerenciamento    ║");
        Console.WriteLine("╚════════════════════════════════════════╝\n");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Loja loja = new Loja("Arcádia Mística");


        Console.WriteLine("Carregando itens iniciais...\n");

        loja.AdicionarItem(new ArmaMagica("Espada Flamejante", 150, 5, Raridade.Raro, 25, "Corte"));
        loja.AdicionarItem(new ArmaMagica("Machado Glacial", 200, 3, Raridade.Epico, 35, "Impacto"));
        loja.AdicionarItem(new PocaoMagica("Poção de Vida", 50, 20, Raridade.Comum, "Recupera 50 de vida", 10));
        loja.AdicionarItem(new PocaoMagica("Poção de Mana", 70, 15, Raridade.Raro, "Recupera 100 de mana", 15));
        loja.AdicionarItem(new PergaminhoMagico("Pergaminho de Fogo", 120, 4, Raridade.Raro, "Bola de Fogo", 3));
        loja.AdicionarItem(new PergaminhoMagico("Pergaminho de Cura", 90, 8, Raridade.Comum, "Cura em Área", 2));

        bool continuar = true;

        while (continuar)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n════════════════════════════════════════");
            Console.WriteLine("              MENU PRINCIPAL            ");
            Console.WriteLine("════════════════════════════════════════");
            Console.WriteLine("1.   Listar Nome e Raridade (Exercício)");
            Console.WriteLine("2.   Ver detalhes completos");
            Console.WriteLine("3.   Listar apenas Armas");
            Console.WriteLine("4.   Listar apenas Poções");
            Console.WriteLine("5.   Listar apenas Pergaminhos");
            Console.WriteLine("6.   Cadastrar novo item");
            Console.WriteLine("7.   Vender item");
            Console.WriteLine("8.   Remover item por ID");
            Console.WriteLine("9.   Ver caixa da loja");
            Console.WriteLine("0.   Sair");
            Console.WriteLine("═══════════════════════════════════════");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":

                    loja.ListarNomeERaridade();
                    break;

                case "2":
                    loja.ListarTodosDetalhes();
                    break;

                case "3":
                    loja.ListarApenasArmas();
                    break;

                case "4":
                    loja.ListarApenasPocoes();
                    break;

                case "5":
                    loja.ListarApenasPergaminhos();
                    break;

                case "6":
                    CadastrarItem(loja);
                    break;

                case "7":
                    VenderItem(loja);
                    break;

                case "8":
                    RemoverItemPorId(loja);
                    break;

                case "9":
                    Console.WriteLine($"\n Caixa da loja: {loja.getCaixa():C2}");
                    Console.WriteLine($" Valor total em estoque: {loja.CalcularValorTotalInventario():C2}");
                    break;

                case "0":
                    Console.WriteLine("\nSaindo do sistema... Obrigado por usar o Mercador de Arcádia!");
                    continuar = false;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void CadastrarItem(Loja loja)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n════════════════════════════════════════");
        Console.WriteLine("         CADASTRAR NOVO ITEM            ");
        Console.WriteLine("════════════════════════════════════════");
        Console.WriteLine("Tipo de item:");
        Console.WriteLine("1. Arma Mágica");
        Console.WriteLine("2. Poção Mágica");
        Console.WriteLine("3. Pergaminho Mágico");
        Console.Write("Escolha: ");

        string tipo = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("Nome do item: ");
        string nome = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("Preço: ");
        if (!double.TryParse(Console.ReadLine(), out double preco))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Preço inválido! Operação cancelada.");
            Console.ResetColor();
            return;
        }
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("Quantidade: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Quantidade inválida! Operação cancelada.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Raridade:");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("1. Comum");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("2. Raro");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("3. Épico");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("Escolha: ");
        string raridadeOpcao = Console.ReadLine();

        Raridade raridade = Raridade.Comum;
        switch (raridadeOpcao)
        {
            case "2": raridade = Raridade.Raro; break;
            case "3": raridade = Raridade.Epico; break;
        }

        switch (tipo)
        {
            case "1":
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Dano da arma: ");
                if (!int.TryParse(Console.ReadLine(), out int dano))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dano inválido! Operação cancelada.");

                    Console.ResetColor();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Tipo da arma (Corte/Impacto/Perfuração): ");
                string tipoArma = Console.ReadLine();

                ArmaMagica arma = new ArmaMagica(nome, preco, quantidade, raridade, dano, tipoArma);
                loja.AdicionarItem(arma);
                break;

            case "2":
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Efeito da poção: ");
                string efeito = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Duração do efeito (segundos): ");
                if (!int.TryParse(Console.ReadLine(), out int duracao))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Duração inválida! Operação cancelada.");
                    Console.ResetColor();
                    return;
                }

                PocaoMagica pocao = new PocaoMagica(nome, preco, quantidade, raridade, efeito, duracao);
                loja.AdicionarItem(pocao);
                break;

            case "3":
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Tipo de magia: ");
                string tipoMagia = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Nível da magia (1-5): ");
                if (!int.TryParse(Console.ReadLine(), out int nivel))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nível inválido! Operação cancelada.");
                    Console.ResetColor();
                    return;
                }

                PergaminhoMagico pergaminho = new PergaminhoMagico(nome, preco, quantidade, raridade, tipoMagia, nivel);
                loja.AdicionarItem(pergaminho);
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tipo de item inválido!");
                Console.ResetColor();
                break;
        }
    }

    static void VenderItem(Loja loja)
    {
        Console.WriteLine("\n════════════════════════════════════════");
        Console.WriteLine("              VENDER ITEM                ");
        Console.WriteLine("════════════════════════════════════════");

        loja.ListarNomeERaridade();

        Console.Write("\nNome do item para vender: ");
        string nomeItem = Console.ReadLine();

        Console.Write("Quantidade: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Quantidade inválida!");
            Console.ResetColor();
            return;
        }

        loja.VenderItem(nomeItem, quantidade);
    }

    static void RemoverItemPorId(Loja loja)
    {
        Console.WriteLine("\n════════════════════════════════════════");
        Console.WriteLine("           REMOVER ITEM POR ID           ");
        Console.WriteLine("════════════════════════════════════════");

        loja.ListarTodosDetalhes();

        Console.Write("\nDigite o ID do item a remover: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID inválido!");
            Console.ResetColor();
            return;
        }

        loja.RemoverItemPorId(id);
    }
}