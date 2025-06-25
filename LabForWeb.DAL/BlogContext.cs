using Microsoft.EntityFrameworkCore;
using LabForWeb.DAL.Models;
using Microsoft.IdentityModel.Abstractions;

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
    public DbSet<Tag> Tags => Set<Tag>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=Blog");
        }
    }
    // Approccio Fluent (method chaining)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articolo>()
            .HasMany(a => a.Tags)
            .WithMany(t => t.Articoli)
            .UsingEntity<ArticoloTag>(
                j => j
                    .HasOne(t => t.Tag)
                    .WithMany(t => t.ArticoloTags)
                    .HasForeignKey(f => f.TagId),
                j => j
                    .HasOne(a => a.Articolo)
                    .WithMany(a => a.ArticoloTags)
                    .HasForeignKey(f => f.ArticoloId),
                j =>
                {
                    // j.Property(p => p.DataAssociazione).HasDefaultValue(DateTime.Now); // Per specificare valori di default in C#
                    j.Property(p => p.DataAssociazione).HasDefaultValueSql("getdate()"); // Per specificare valori di default in SQL
                    j.HasKey(k => new {k.TagId, k.ArticoloId}); // Superchiave
                });
    }
}
