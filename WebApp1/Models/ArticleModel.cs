using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class ArticleModel
    {
        public int IdArticle { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public string CodeEAN13 { get; set; }
        public string Description { get; set; }
        public int IdCategorie { get; set; }
        public string LibCategorie { get; set; }

    }
}
