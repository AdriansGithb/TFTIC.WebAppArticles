using ArticleDAL.Entities;
using System.Collections.Generic;

namespace ArticleDAL.Repositories
{
    public interface ICategorieRepository
    {
        bool Create(Categorie c);
        bool Delete(int id);
        IEnumerable<Categorie> GetAll();
        Categorie GetById(int Id);
        Categorie GetByLib(string Libelle);
        bool Update(Categorie c);
    }
}