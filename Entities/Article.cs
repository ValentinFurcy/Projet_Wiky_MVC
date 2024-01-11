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
        public string Theme { get; set; }
        [StringLength(30)]
        public string Auteur { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModified { get; set; }
        public string Contenu { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
