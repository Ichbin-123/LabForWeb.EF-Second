namespace LabForWeb.DAL.Models;

public class Tag
{
    public string? Id { get; set; }
    public virtual ICollection<Articolo>? Articoli { get; set; }
    public virtual ICollection<ArticoloTag>? ArticoloTags { get; set; }
}

public class ArticoloTag
{
    public int ArticoloId { get; set; }
    public string? TagId { get; set; }
    public virtual Tag? Tag { get; set; }
    public virtual Articolo? Articolo { get; set; }
    public DateTime DataAssociazione { get; set; }

}
