using System.ComponentModel.DataAnnotations;


namespace LabForWeb.DAL.Models
{
    public class Articolo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Titolo { get; set; }

        [Required]
        public string? Testo { get; set; }

        [Required]
        public virtual Utente? Autore { get; set; }

        public virtual ICollection<Commento>? Commenti { get; set; }

        public virtual ICollection<Categoria>? Categorie {  get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }
        public virtual ICollection<ArticoloTag>? ArticoloTags { get; set; }
    }
}
