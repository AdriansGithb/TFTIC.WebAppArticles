using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class ArticleFormModel
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public decimal Prix { get; set; }
        [Required]
        [MinLength(13)]
        [MaxLength(13)]
        public string CodeEAN13 { get; set; }
        public string Description { get; set; }
        public int IdCategorie { get; set; }
        public IEnumerable<CategorieModel> CategorieList { get; set; }

    }
}
