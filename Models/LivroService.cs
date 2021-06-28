using System.Linq;

using System.Collections.Generic;


namespace Biblioteca.Models
{
  public class LivroService
  {
    public void Inserir(Livro l)
    {
      using (BibliotecaContext bc = new BibliotecaContext())
      {
        bc.livros.Add(l);
        bc.SaveChanges();
      }
    }

    public void Atualizar(Livro l)
    {
      using (BibliotecaContext bc = new BibliotecaContext())
      {
        Livro livro = bc.livros.Find(l.Id);
        livro.Autor = l.Autor;
        livro.Titulo = l.Titulo;

        bc.SaveChanges();
      }
    }

    public ICollection<Livro> ListarTodos(FiltrosLivros filtro = null)
    {
      using (BibliotecaContext bc = new BibliotecaContext())
      {
        IQueryable<Livro> query;

        if (filtro != null)
        {
          //definindo dinamicamente a filtragem
          switch (filtro.TipoFiltro)
          {
            case "Autor":
              query = bc.livros.Where(l => l.Autor.Contains(filtro.Filtro));
              break;

            case "Titulo":
              query = bc.livros.Where(l => l.Titulo.Contains(filtro.Filtro));
              break;

            default:
              query = bc.livros;
              break;
          }
        }
        else
        {
          // caso filtro não tenha sido informado
          query = bc.livros;
        }

        //ordenação padrão
        return query.OrderBy(l => l.Titulo).ToList();
      }
    }

    public ICollection<Livro> ListarDisponiveis()
    {
      using (BibliotecaContext bc = new BibliotecaContext())
      {
        //busca os livros onde o id não está entre os ids de livro em empréstimo
        // utiliza uma subconsulta
        return
            bc.livros
            .Where(l => !(bc.emprestimo.Where(e => e.Devolvido == false).Select(e => e.LivroId).Contains(l.Id)))
            .ToList();
      }
    }

    public Livro ObterPorId(int id)
    {
      using (BibliotecaContext bc = new BibliotecaContext())
      {
        return bc.livros.Find(id);
      }
    }
  }
}