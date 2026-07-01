namespace ProjetoTaverna;

class Program
{
    public static int QtdPedidos;
    public static double FaturamentoTotal;

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

        int menu = -1;
        IDictionary<int, int> itensPedidos = new Dictionary<int, int>();
        do
        {
            Console.WriteLine("Selecione a operação desejada:");
            Console.WriteLine("1) - Listar itens do cardapio");
            Console.WriteLine("2) - Consultar item por codigo");
            Console.WriteLine("3) - Reposição de Estoque");
            Console.WriteLine("4) - Iniciar novo pedido");
            Console.WriteLine("5) - Fechar Conta e Pagamento");
            Console.WriteLine("6) - Relatório de Caixa Geral");
            Console.WriteLine("0) - Sair");
            bool flag = int.TryParse(Console.ReadLine(), out menu);
            if (!flag)
            {
                Console.WriteLine("Operação invalida");
                menu = -1;
                Console.ReadKey();
                Console.Clear();
            }

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
                case 4:
                    itensPedidos = IniciarPedido(codigos, estoque);
                    break;
                case 5:
                    FecharConta(codigos, nomes, precos, itensPedidos);
                    break;
                case 6:
                    ExibirRelatorioCaixa();
                    break;
            }
        } while (menu != 0);
    }

    static void ListarItensCardapio(List<int> codigos, List<string> nomes, List<double> precos, List<int> estoque)
    {
        Console.Clear();
        Console.WriteLine("### Listagem do cardapio ###");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Item {codigos[i]} -  {nomes[i]} - PO {precos[i]:N2} - qtd em estoque: {estoque[i]} ");
        }

        Console.ReadKey();
    }

    static void ConsultarItemPorCodigo(List<int> codigos, List<string> nomes, List<double> precos, List<int> estoque)
    {
        Console.Clear();
        Console.WriteLine("Informe o codigo do item a ser consultado: ");
        int.TryParse(Console.ReadLine(), out int codigoInformado);
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
        int.TryParse(Console.ReadLine(), out int codigoInformado);
        while (codigoInformado <= 0 || codigoInformado > 5)
        {
            Console.WriteLine("Código invalido");
            Console.Write("Informe o código novamente: ");
            int.TryParse(Console.ReadLine(), out codigoInformado);
        }

        int idItem = codigos.FindIndex(x => x == codigoInformado);
        Console.WriteLine("Informe a quantidade a ser adicionada ao estoque");
        bool flag = int.TryParse(Console.ReadLine(), out int qtdAdicionada);
        while (!flag)
        {
            Console.WriteLine("Informe um valor valido");
            flag = int.TryParse(Console.ReadLine(), out qtdAdicionada);
        }

        if (qtdAdicionada < 0)
        {
            Console.WriteLine("Não é possivel ter estoque negativo");
            Console.Write("Informe o quantidade novamente: ");
            int.TryParse(Console.ReadLine(), out qtdAdicionada);
        }

        estoque[idItem] += qtdAdicionada;
        Console.WriteLine($"Adicionado com sucesso {qtdAdicionada} itens ao estoque.");
        Console.WriteLine($"O estoque agora possui {estoque[idItem]} itens");
        Console.ReadKey();
    }

    static IDictionary<int, int> IniciarPedido(List<int> listaCodigos, List<int> listaEstoque)
    {
        IDictionary<int, int> qtdPedido = new Dictionary<int, int>();
        int codigo;
        do
        {
            codigo = -1;
            Console.Clear();
            Console.WriteLine("\n**********INICIANDO PEDIDO***********");
            Console.WriteLine("Digite o código do produto");
            bool flag = int.TryParse(Console.ReadLine(), out codigo);
            while (!flag)
            {
                Console.Clear();
                codigo = -1;
                Console.WriteLine("Entrada invalida");
                Console.WriteLine("Digite o código do produto");
                flag = int.TryParse(Console.ReadLine(), out codigo);
            }

            while (!listaCodigos.Contains(codigo) && codigo != 0)
            {
                Console.WriteLine("Digite um código válido.");
                int.TryParse(Console.ReadLine(), out codigo);
            }

            int indexEncontrado = listaCodigos.FindIndex(x => x == codigo);

            if (listaCodigos.Contains(codigo))
            {
                Console.WriteLine("Digite a quantidade do produto: ");
                int.TryParse(Console.ReadLine(), out int qtdProduto);
                while (qtdProduto < 0 || qtdProduto > listaEstoque[indexEncontrado])
                {
                    Console.WriteLine("Digite uma quantidade válida.");
                    int.TryParse(Console.ReadLine(), out qtdProduto);
                }

                if (qtdPedido.Count > 0 && qtdPedido.ContainsKey(indexEncontrado))
                {
                    qtdPedido[indexEncontrado] += qtdProduto;
                }

                listaEstoque[indexEncontrado] -= qtdProduto;
                if (!qtdPedido.ContainsKey(indexEncontrado)) qtdPedido.Add(indexEncontrado, qtdProduto);
            }
        } while (codigo != 0);

        Console.WriteLine("Pedido realizado com sucesso!");
        Console.WriteLine("Itens do pedido:");
        foreach (var pedido in qtdPedido)
        {
            Console.WriteLine($"Codigo do produto: {pedido.Key + 1} | qtd do Pedido: {pedido.Value} ");
        }

        Console.ReadKey();
        Console.Clear();

        return qtdPedido;
    }


    static void FecharConta(List<int> codigos, List<string> nomes, List<double> precos,
        IDictionary<int, int> itensPedido)
    {
        if (itensPedido.Count == 0)
        {
            Console.WriteLine("O carrinho está vazio! Nenhum pedido para fechar.");
            return;
        }

        double valorTotal = CalcularValorTotal(precos, itensPedido);
        double valorFinalPago = 0;

        Console.WriteLine($"\n--- FECHAMENTO DE CONTA ---");
        EmitirRecibo(nomes, precos, itensPedido, valorTotal, valorFinalPago);

        int opcao;
        while (true)
        {
            Console.WriteLine($"Valor dos itens: PO {valorTotal:N2}");
            Console.WriteLine("Escolha a forma de pagamento:");
            Console.WriteLine("1 - À Vista (Moedas de Ouro - 10% de Desconto)");
            Console.WriteLine("2 - Crédito (Pergaminho de Débito - Valor Integral)");
            Console.Write("Sua escolha: ");
            if (int.TryParse(Console.ReadLine(), out opcao) && (opcao == 1 || opcao == 2))
            {
                break;
            }

            Console.WriteLine("Opção inválida! Escolha 1 ou 2.");
            Console.ReadKey();
            Console.Clear();
        }

        if (opcao == 1)
        {
            valorFinalPago = PagarVista(valorTotal);
        }
        else
        {
            PagarCredito(valorTotal);
            valorFinalPago = valorTotal;
        }

        EmitirRecibo(nomes, precos, itensPedido, valorTotal, valorFinalPago);
    }

    static double CalcularValorTotal(List<double> precos, IDictionary<int, int> itensPedido)
    {
        double valorTotal = 0;
        foreach (var keyValuePair in itensPedido)
        {
            int codigoItem = keyValuePair.Key;
            int qtdItem = keyValuePair.Value;
            valorTotal += qtdItem * precos[codigoItem];
        }

        return valorTotal;
    }

    static double PagarVista(double valorTotal)
    {
        double desconto = 0.10;
        double valorComDesconto = valorTotal - (valorTotal * desconto);

        while (true)
        {
            Console.WriteLine($"O valor da compra com desconto é: PO {valorComDesconto:N2}");
            Console.Write("Informe o valor pago pelo cliente (PO): ");
            double valorPago;
            if (double.TryParse(Console.ReadLine(), out valorPago) && valorPago >= valorComDesconto)
            {
                Console.WriteLine(valorComDesconto < valorPago
                    ? $"O troco é: PO {(valorPago - valorComDesconto):N2}"
                    : "Não há troco.");
                Console.ReadKey();
                QtdPedidos++;
                FaturamentoTotal += valorComDesconto;
                return valorComDesconto;
            }

            Console.WriteLine("Valor inválido ou insuficiente!");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void PagarCredito(double valorTotal)
    {
        QtdPedidos++;
        FaturamentoTotal += valorTotal;
        Console.WriteLine("Compra inserida com sucesso no Pergaminho de Débito.");
        Console.ReadKey();
    }

    static void EmitirRecibo(List<string> nomes, List<double> precos, IDictionary<int, int> itensPedido,
        double valorTotal, double valorFinalPago)
    {
        int indice = 1;
        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"|{"***** RECIBO DA TAVERNA *****",-58}|");
        Console.WriteLine(new string('-', 60));

        foreach (var keyValuePair in itensPedido)
        {
            int codigoItem = keyValuePair.Key;
            int qtdPedido = keyValuePair.Value;
            string nomeItem = nomes[codigoItem];
            double precoUnitario = precos[codigoItem];

            Console.WriteLine($"| {indice++,-3} {nomeItem,-35} PO {precoUnitario,7:N2} | x{qtdPedido,-2} |");
        }

        double descontoCalculado = valorTotal - valorFinalPago == valorTotal ? 0 : valorTotal - valorFinalPago;

        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"| {"Subtotal:",-44} PO {valorTotal,8:N2} |");
        Console.WriteLine($"| {"Desconto:",-44} PO {descontoCalculado,8:N2} |");
        Console.WriteLine($"| {"Total Pago:",-44} PO {valorFinalPago,8:N2} |");
        Console.WriteLine(new string('-', 60));
        Console.ReadKey();
    }

    static void ExibirRelatorioCaixa()
    {
        Console.Clear();
        Console.WriteLine("\n========================================");
        Console.WriteLine("     RELATÓRIO DE CAIXA DO DIA");
        Console.WriteLine("========================================");
        Console.WriteLine($"Quantidade de Pedidos Concluídos: {QtdPedidos}");
        Console.WriteLine($"Faturamento Total do Dia: PO {FaturamentoTotal:N2}");
        Console.WriteLine("========================================\n");
        Console.ReadKey();
    }
}