using LabForWeb.DAL;
using LabForWeb.DAL.Models;

namespace LabForWeb.EF;

public static class DBFiller
{
    public static void Fill(BlogContext dc)
    {
            if(dc.Categorie.Any() ||
                dc.Utenti.Any() ||
                dc.Articoli.Any() ||
                dc.Commenti.Any() ||
                dc.Tags.Any())
        {
            return;
        }

        // Aggiorna dati di partenza
        dc.Categorie.Add(new Categoria { Nome = "Sport" });
        dc.Categorie.Add(new Categoria { Nome = "Economia" });
        dc.Categorie.Add(new Categoria { Nome = "Cronaca" });
        dc.Categorie.Add(new Categoria { Nome = "Attualità" });

        dc.Utenti.Add(new Utente { Nome= "Mario Rossi" });
        dc.Utenti.Add(new Utente { Nome= "Anna Bianchi" });

        dc.Tags.Add(new Tag { Id="NUOVO" });
        dc.Tags.Add(new Tag { Id="TENEDENZA" });

        dc.SaveChanges();
    }

}

