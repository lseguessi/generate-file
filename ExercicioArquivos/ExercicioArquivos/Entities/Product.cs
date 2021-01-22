using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioArquivos.Entities
{
    class Product
    {
        public string description{ get; set; }
        public double value { get; set; }
        public int quantity { get; set; }

        public Product() { }

        public Product(string description, double value, int quantity)
        {
            this.description = description;
            this.value = value;
            this.quantity = quantity;
        }

        public double sum(double price, int qtde)
        {
            return price * qtde;
        }
    }
}
