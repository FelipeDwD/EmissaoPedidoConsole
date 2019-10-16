using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Pedidos.Entidades
{
    class Item
    {
        private double _preco;
        public int Quantidade { get; private set; }
       

        public Produto Produto { get; set; }

        public Item() { }

        public Item(int quantidade, Produto produto)
        {
            Quantidade = quantidade;
            Produto = produto;
            Preco = SubTotal();
        }

        public double Preco
        {
            get { return _preco;  }
            private set
            {
                _preco = value;
            }
        }

        public double SubTotal()
        {
            return Produto.Preco * Quantidade;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            
            sb.Append(Produto.Nome);
            sb.Append(", ");
            sb.Append(Produto.Preco.ToString("F2", CultureInfo.InvariantCulture));
            sb.Append(", ");
            sb.Append("Quantidade: ");
            sb.Append(Quantidade);
            sb.Append(", ");
            sb.Append("Subtotal: R$");
            sb.AppendLine(SubTotal().ToString("F2", CultureInfo.InvariantCulture));            
            return sb.ToString();
        }
    }
}
