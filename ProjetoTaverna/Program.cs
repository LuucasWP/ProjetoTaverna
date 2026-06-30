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
                                break;
                            case 2:
                                break;
                            
                        }
                        
        } while (menu !=0);

    }
}