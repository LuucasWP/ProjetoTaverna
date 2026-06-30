namespace ProjetoTaverna;

class Program
{
    static void Main(string[] args)
    {
        List<int> codigos = new List<int> { 1, 2, 3, 4, 5 };
        List<string> nomes = new List<string>
        {
            "Hidromel de Asgard (Caneca)",
            "Hambúrguer de Javali Flamejante",
            "Poção de Cura (Suco de Morango)",
            "Porção de Batatas Rústicas do Condado",
            "Manjar dos Deuses (Sobremesa)"
        };

        List<double> precos = new List<double> { 15.00, 32.50, 20.00, 18.00, 12.50 };
        List<int> estoque = new List<int> { 40, 15, 10, 25, 8 };

        int menu = 0;
        do
        {
            Console.WriteLine("Selecione a operação desejada:");
            Console.WriteLine("1) - Listar itens do cardapio");
            Console.WriteLine("2) - Consultar item por codigo");
            Console.WriteLine("3) - Reposição de Estoque");
            Console.WriteLine("4) - Iniciar novo pedido");
            Console.WriteLine("5) - Fechar Conta e Pagamento");
            Console.WriteLine("6) - Emissão de Recibo");
            Console.WriteLine("7) - Relatório de Caixa Geral");
            Console.WriteLine("0) - Sair");
            menu = int.TryParse(Console.ReadLine(), out int opcao) ? opcao : 0;
            switch (menu)
            {
                case 1:
                    ListarItensCardapio(codigos, nomes, precos, estoque);
                    Console.Clear();
                    break;
                case 2:
                    ConsultarItemPorCodigo(codigos, nomes, precos, estoque);
                    Console.Clear();
                    break;
                case 3:
                    ReporEstoque(codigos, estoque);
                    Console.Clear();
                    break;
            }
        } while (menu != 0);
    }

    static void ListarItensCardapio(List<int> codigos, List<string> nomes, List<double> precos, List<int> estoque)
    {
        Console.Clear();
        Console.WriteLine("###Listagem do cardapio###");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Item {codigos[i]} -  {nomes[i]} -  {precos[i]} PO - qtd em estoque: {estoque[i]} ");
        }

        Console.ReadKey();
    }

    static void ConsultarItemPorCodigo(List<int> codigos, List<string> nomes, List<double> precos, List<int> estoque)
    {
        Console.Clear();
        Console.WriteLine("Informe o codigo do item a ser consultado: ");
        int codigoInformado = int.TryParse(Console.ReadLine(), out int opcao) ? opcao : 0;
        while (codigoInformado <= 0 || codigoInformado > 5)
        {
            Console.WriteLine("Código invalido");
            Console.Write("Informe o código novamente: ");
            codigoInformado = int.TryParse(Console.ReadLine(), out int opcao1) ? opcao1 : 0;
        }

        int idItem = codigos.FindIndex(x => x == codigoInformado);
        Console.WriteLine(
            $"Item {codigos[idItem]} -  {nomes[idItem]} -  {precos[idItem]} PO - qtd em estoque: {estoque[idItem]}");
        if (estoque[idItem] <= 0) Console.WriteLine("Produto esgotado!");
        Console.ReadKey();
    }

    static void ReporEstoque(List<int> codigos, List<int> estoque)
    {
        Console.Clear();
        Console.WriteLine("Informe o codigo do item a ser adicionado estoque: ");
        int codigoInformado = int.TryParse(Console.ReadLine(), out int opcao) ? opcao : 0;
        while (codigoInformado <= 0 || codigoInformado > 5)
        {
            Console.WriteLine("Código invalido");
            Console.Write("Informe o código novamente: ");
            codigoInformado = int.TryParse(Console.ReadLine(), out int opcao1) ? opcao1 : 0;
        }

        int idItem = codigos.FindIndex(x => x == codigoInformado);
        Console.WriteLine("Informe a quantidade a ser adicionada ao estoque");
        int qtdAdicionada = int.TryParse(Console.ReadLine(), out int opcao2) ? opcao2 : 0;
        if (qtdAdicionada < 0)
        {
            Console.WriteLine("Não é possivel ter estoque negativo");
            Console.Write("Informe o quantidade novamente: ");
            qtdAdicionada = int.TryParse(Console.ReadLine(), out int opcao1) ? opcao1 : 0;
        }

        estoque[idItem] += qtdAdicionada;
        Console.WriteLine(estoque[idItem]);
    }
}