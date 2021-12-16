using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB = WebApp1.Models;
using DAL = ArticleDAL.Entities;

namespace WebApp1.Tools
{
    public static class Mappers
    {
        public static WEB.ArticleModel toWeb(this DAL.Article a)
        {
            return new WEB.ArticleModel
            {
                IdArticle = a.IdArticle,
                Nom = a.Nom,
                CodeEAN13 = a.CodeEAN13,
                Prix = a.Prix,
                Description = a.Description,
                IdCategorie = a.IdCategorie
            };
        }
        public static DAL.Article toDal(this WEB.ArticleModel a)
        {
            return new DAL.Article
            {
                IdArticle = a.IdArticle,
                Nom = a.Nom,
                CodeEAN13 = a.CodeEAN13,
                Prix = a.Prix,
                Description = a.Description,
                IdCategorie = a.IdCategorie
            };
        }
        public static WEB.CategorieModel toWeb(this DAL.Categorie c)
        {
            return new WEB.CategorieModel
            {
                IdCategorie = c.IdCategorie,
                Libelle = c.Libelle
            };
        }
        public static DAL.Categorie toDal(this WEB.CategorieModel c)
        {
            return new DAL.Categorie
            {
                IdCategorie = c.IdCategorie,
                Libelle = c.Libelle
            };
        }


    }
}
