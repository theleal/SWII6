using Newtonsoft.Json;
using SW_TP01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_TP01.Repository
{
    public class BookRepositoryCsv
    {
        private const string CsvFileName = "books.csv";
        private List<Book> _bookCollection;

        public BookRepositoryCsv()
        {
            this.LoadFromCsv();
        }

        public ICollection<Book> getAll()
        {
            return _bookCollection;
        }
        public void add(Book book)
        {
            using (var file = File.AppendText(CsvFileName))
            {
                var authorsJson = JsonConvert.SerializeObject(book.getAuthors());
                file.WriteLine($"{book.getName()};{authorsJson};{book.getPrice()};{book.getQty()}");
            }
        }

        private void LoadFromCsv()
        {
            _bookCollection = new List<Book>();

            if (!File.Exists(CsvFileName))
            {
                File.CreateText(CsvFileName).Dispose();
            }

            using (var file = File.OpenText(CsvFileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    var bookInfo = line.Split(';');

                    var authors = DeserializeAuthors(bookInfo[1]);

                    var book = new Book(
                        bookInfo[0],
                        authors,
                        Convert.ToDouble(bookInfo[2]),
                        Convert.ToInt32(bookInfo[3])
                    );

                    _bookCollection.Add(book);
                }
            }
        }

        private Author[] DeserializeAuthors(string authorsJson)
        {
            return JsonConvert.DeserializeObject<Author[]>(authorsJson);
        }
    }
}
