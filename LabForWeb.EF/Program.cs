using AdventureWorks;
using LabForWeb.DAL;
using LabForWeb.DAL.Migrations;
using LabForWeb.DAL.Models;

namespace LabForWeb.EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dc = new BlogContext();

            //var r = dc.Articoli.Where(a => a.Commenti != null).OrderBy(o => o.Commenti!.Count());
            //Console.WriteLine(r.Count());
            DBFiller.Fill(dc);

            var mario = dc.Utenti.Single(u=>u.Id==1);
            var anna = dc.Utenti.Single(u => u.Id==2);
            var sport = dc.Categorie.Single(x => x.Id == 1);
            var attualita = dc.Categorie.Single(x => x.Id == 4);
            var tag_tendenza = dc.Tags.Single(x => x.Id=="TENEDENZA");
            var tag_nuovo = dc.Tags.Single(x => x.Id=="NUOVO");

            //var b = new Articolo
            //{
            //    Titolo = "I dazzi di Trump",
            //    Testo = "Una seccatura.",
            //    Autore = mario
            //};

            //dc.Articoli.Add(b);

            //var a = new Articolo
            //{
            //    Titolo = "Roland Garros",
            //    Testo = "Vince Alcaraz",
            //    Autore = mario,
            //    Categorie = [sport, attualita], // Questa è una Collection
            //    Commenti = new List<Commento> { 
            //        new Commento { Testo= "Che peccato", Autore = anna },
            //        new Commento { Testo= "Già", Autore = mario },
            //        },
            //    Tags = [tag_tendenza],
            //    ArticoloTags = [
            //        new ArticoloTag {
            //            Tag = tag_nuovo,
            //            DataAssociazione = new DateTime(2025, 1, 1)
            //        }
            //        ]
            //}; 

            //dc.Articoli.Add(a);

            //var c = dc.Articoli.Single(x => x.Id == 1);
            //c.Categorie = [attualita];

            foreach (var articoli in attualita.Articoli)
            {
                Console.WriteLine(articoli.Titolo);
            }

            foreach (var articoli in sport.Articoli)
            {
                Console.WriteLine(articoli.Titolo);
            }

            foreach (var articolo in attualita.Articoli)
            {
                Console.WriteLine($"Titolo: {articolo.Titolo}");
                Console.WriteLine("Commenti:");

                if(articolo.Commenti.Count() > 0)
                { 
                    foreach (var commento in articolo.Commenti)
                    {
                        Console.WriteLine($"{commento.Testo} di {commento.Autore.Nome}");
                    }
                } else {
                    Console.WriteLine("Nessun Commento");
                }

                Console.WriteLine("\n");
            }



            try
            {
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
