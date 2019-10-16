using System;
using Pedidos.Entidades;
using System.Globalization;

namespace Pedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite os dados do cliente: ");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Digite a data de nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Entre com os dados do pedido: ");
            Console.Write("Status: ");
            PedidoStatus pedidoStatus = Enum.Parse<PedidoStatus>(Console.ReadLine());
            Console.Write("Quantos items tem no pedido: ");
            int quantidadeItem = int.Parse(Console.ReadLine());
            Cliente cliente = new Cliente(nome, email, dataNascimento);
            Pedido pedido = new Pedido(pedidoStatus, cliente);

            for (int i = 0; i < quantidadeItem; i++)
            {
                Console.WriteLine($"Digite os dados do {(i+1)}º item: ");
                Console.Write("Nome do produto: ");
                string nomeProduto = Console.ReadLine();
                Console.Write("Preço do produto: ");
                double precoProduto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantidade: ");
                int quantidadeProduto = int.Parse(Console.ReadLine());

                Produto produto = new Produto(nomeProduto, precoProduto);
                Item item = new Item(quantidadeProduto, produto);
                pedido.AdicionarItem(item);
            }
            Console.WriteLine();

            Console.WriteLine(pedido);

            
        }
    }
}
