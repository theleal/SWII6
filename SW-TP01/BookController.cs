using Microsoft.AspNetCore.Http;
using SW_TP01.Models;
using SW_TP01.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_TP01.Controller
{

    // Rodrigo Rebelo da Costa - CB3016871
    // Luiz Gustavo - CB3015386


    public class BookController
    {
        private readonly BookRepositoryCsv _repositoryCSV;

        public BookController()
        {
            this._repositoryCSV = new BookRepositoryCsv();
            this.Initialize();
        }

        private void Initialize()
        {
            var bookList = this._repositoryCSV.getAll();
            if (bookList.Count <= 0)
            {
                var initialAuthors = new Author[]
                {
                    new Author("Rousseau", "rousseau@gmail.com", 'm'),
                    new Author("Thomas Hobbes", "hobbinho@gmail.com", 'f')
                };

                var initialBook = new Book("Pacto Social", initialAuthors, 19.99, 250);

                this._repositoryCSV.add(initialBook);
            }
        }

        public void MostrarMetodos()
        {
            var authors = new Author[]
            {
                new Author("Karl Marx", "marx@gmail.com", 'M'),
                new Author("Friedrich Engles", "anjinho@gmail.com", 'M')
            };

            var exampleBook = new Book("O Manifesto do Partido comunista", authors, 45.99, 3499);

            Console.WriteLine($"Titulo Livro: \n{exampleBook.getName()}\n");
            Console.WriteLine($"Autores: \n{exampleBook.getAuthorNames()}\n");
            Console.WriteLine($"Preço do livro: \n{exampleBook.getPrice()}\n");
            Console.WriteLine($"Quantidade disponível: \n{exampleBook.getQty()}\n");

            exampleBook.setPrice(60.35);
            exampleBook.setQty(92);

            Console.WriteLine($"Preço atualizado do livro: \n{exampleBook.getPrice()}\n");
            Console.WriteLine($"Quantidade disponível atualizada: \n{exampleBook.getQty()}\n");

            Console.WriteLine(exampleBook.ToString());
        }

        public Task GetNameBook(HttpContext context)
        {
            var singleBook = _repositoryCSV.getAll().FirstOrDefault();
            return context.Response.WriteAsync(singleBook.getName());
        }
        public Task GetBook(HttpContext context)
        {
            var singleBook = _repositoryCSV.getAll().FirstOrDefault();
            return context.Response.WriteAsync(singleBook.ToString());
        }
        public Task GetAuthorsBook(HttpContext context)
        {
            var singleBook = _repositoryCSV.getAll().FirstOrDefault();
            return context.Response.WriteAsync(singleBook.getAuthorNames());
        }
        public Task GetHtmlBook(HttpContext context)
        {
            var singleBook = _repositoryCSV.getAll().FirstOrDefault();
            var authorElements = singleBook.getAuthors().Select(author => $"<li>{author.Name}</li>");
            return context.Response.WriteAsync($@"
                <h1>{singleBook.getName()}</h1>    
                <strong>Autores:</strong>
                <ol>
                    {string.Join("", authorElements)}
                </ol>
            ");
        }
    }
}
