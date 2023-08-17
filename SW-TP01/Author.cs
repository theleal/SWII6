using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW_TP01.Models
{

    // Rodrigo Rebelo da Costa - CB3016871
    // Luiz Gustavo - CB3015386

    public class Author
    {
        public string Name { get; }
        public string Email { get; }
        public char Gender { get; }

        public Author(string name, string email, char gender)
        {
            Name = name;
            Email = email;
            Gender = gender;
        }

        public override string ToString() => $"\nAutor[\nnome={Name}\n Email={Email}\n Genero={Gender}\n]\n";
    }
}
