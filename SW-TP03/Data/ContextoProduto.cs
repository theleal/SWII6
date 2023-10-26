using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TP03SW.Models;

namespace TP03SW.Data
{
    public class ContextoProduto : DbContext
    {
        public ContextoProduto(DbContextOptions<ContextoProduto> options) : base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }
    }
}
