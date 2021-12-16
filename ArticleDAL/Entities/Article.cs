using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleDAL.Entities
{
    public class Article
    {
        public int IdArticle { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public string CodeEAN13 { get; set; }
        public string Description { get; set; }
        public int IdCategorie { get; set; }
    }
}
