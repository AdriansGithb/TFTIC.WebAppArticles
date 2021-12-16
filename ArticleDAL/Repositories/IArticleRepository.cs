using ArticleDAL.Entities;
using System.Collections.Generic;

namespace ArticleDAL.Repositories
{
    public interface IArticleRepository
    {
        bool Create(Article a);
        bool Delete(int id);
        IEnumerable<Article> GetAll();
        IEnumerable<Article> GetAllByCategorieId(int catId);
        Article GetById(int Id);
        bool Update(Article a);
    }
}