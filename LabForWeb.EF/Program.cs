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

            dc.Articoli.Where(a=>a.Commenti != null).OrderBy(o => o.Commenti!.Count());            

        }
    }
}
