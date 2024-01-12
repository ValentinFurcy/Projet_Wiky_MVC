using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Auteur obligatoire")]
        [StringLength(30, ErrorMessage = "Longueur Max=30")]
        public string Auteur { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModified { get; set; }
        [Required(ErrorMessage = "Contenu obligatoire")]
        [StringLength(100, ErrorMessage = "Longueur Max=100")]
        public string Contenu { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}
