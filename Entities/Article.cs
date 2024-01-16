using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Entities
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [Remote("CheckUniqueTheme", "Article", ErrorMessage = "Ce theme éxiste déjà")]
        public string Theme { get; set; }
        [Required(ErrorMessage = "Auteur obligatoire")]
        [StringLength(30, ErrorMessage = "Longueur Max=30")]
        public string Auteur { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModified { get; set; }
        [Required(ErrorMessage = "Contenu obligatoire")]
        public string Contenu { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
