using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Pedidos.Entidades
{
    class Pedido
    {
        public DateTime Data { get; private set; }
        public PedidoStatus Status { get; private set; }       

        public List<Item> Items { get; private set; } = new List<Item>();

        public Cliente Cliente { get; private set; }

        public Pedido() { }

        public Pedido(PedidoStatus status, Cliente cliente)
        {
            Data = DateTime.Now;
            Status = status;
            Cliente = cliente;
        }

        public void AdicionarItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoverItem(Item item)
        {
            Items.Remove(item);
        }

       public double Total()
        {
            double valorTotal = 0;

            foreach (Item item in Items)
            {
                valorTotal += item.Preco;
            }
            return valorTotal;
        }

        public string DescricaoItems()
        {
            string relatorioDeItems = "Descrição dos itens: \n";
            foreach (Item item in Items)
            {
                relatorioDeItems += item;
            }
            return relatorioDeItems;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Descrição do pedido: ");
            sb.Append("Data do pedido: ");
            sb.AppendLine(Data.ToString());
            sb.Append("Status do pedido: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Cliente: ");
            sb.Append(Cliente.Nome);
            sb.Append(" (");
            sb.Append(Cliente.DataNascimento.Day);
            sb.Append("/");
            sb.Append(Cliente.DataNascimento.Month);
            sb.Append("/");
            sb.Append(Cliente.DataNascimento.Year);
            sb.Append(")- ");
            sb.AppendLine(Cliente.Email);            
            sb.AppendLine(DescricaoItems());
            sb.Append("Valor total: ");
            sb.Append(Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }


    }
}
