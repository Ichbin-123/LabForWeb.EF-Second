using Microsoft.EntityFrameworkCore;
using LabForWeb.DAL.Models;

namespace LabForWeb.DAL;

public class BlogContext: DbContext
{

    public BlogContext()
    {

    }

    public BlogContext(DbContextOptions<BlogContext> options)
        :base(options)
    {
       
    }

    public DbSet<Utente> Utenti
    {
        get { return base.Set<Utente>();}
    }

    public DbSet<Categoria> Categorie => Set<Categoria>();

    public DbSet<Articolo> Articoli => Set<Articolo>();

    public DbSet<Commento> Commenti => Set<Commento>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Blog");
        }
    }
}
