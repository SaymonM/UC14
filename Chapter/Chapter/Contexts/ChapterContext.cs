using Chapter.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions <ChapterContext> options) : base(options)
        {
        }
        // vamos utilizar esse método para configurar o banco de dados
        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe paraespecificação

                optionsBuilder.UseSqlServer("Data Source = DESKTOP-I2Q4UFF\\FILEDIRECTOR; initial catalog = Chapter; User Id = sa; Password = 1");
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção

        public DbSet<Livro> Livros { get; set; }
    }
}

