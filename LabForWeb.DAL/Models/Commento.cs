using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabForWeb.DAL.Models;
    public class Commento
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Testo { get; set; }

        [Required]
        public virtual Utente? Autore { get; set; }

        //[Required]
        //public virtual Articolo? Articolo { get; set; }
    }
