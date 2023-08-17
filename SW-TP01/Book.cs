using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_TP01.Models
{

    // Rodrigo Rebelo da Costa - CB3016871
    // Luiz Gustavo - CB3015386

    public class Book
    {
        private string name { get; set; }
        private Author[] authors { get; set; }
        private double price { get; set; }
        private int qty { get; set; }

        public Book(string name, Author[] authors, double price) : this(name, authors, price, 0) { }

        public Book(string name, Author[] authors, double price, int qty)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = qty;
        }

        public string getName() => name;
        public Author[] getAuthors() => authors;
        public double getPrice() => price;
        public int getQty() => qty;

        public void setPrice(double price) => this.price = price;
        public void setQty(int qty) => this.qty = qty;

        public string getAuthorNames() => string.Join(", ", authors.Select(a => a.Name));

        public override string ToString()
        {
            var authorList = string.Join(", ", authors.Select(a => a.ToString()));
            return $"\nLivro\n[Nome={name} \nAutores=\n{{{authorList}}} \nPreço={price} \nQuantidade={qty}]";
        }
    }
}
