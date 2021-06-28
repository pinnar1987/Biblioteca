
using Microsoft.EntityFrameworkCore;
namespace Biblioteca.Models
{
  public class BibliotecaContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySql("Server=localhost;DataBase=Biblioteca;Uid=root;");
    }

    public DbSet<Livro> livros { get; set; }
    public DbSet<Emprestimo> emprestimo { get; set; }
    public DbSet<Usuario> usuarios { get; set; }
  }
}
