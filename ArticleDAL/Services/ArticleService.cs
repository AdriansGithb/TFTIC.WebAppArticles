using ArticleDAL.Entities;
using ArticleDAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace ArticleDAL.Services
{
    public class ArticleService : IArticleRepository
    {
        private readonly string _connectionString;

        public ArticleService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        internal Article Converter(IDataRecord reader)
        {
            return new Article
            {
                IdArticle = (int)reader["IdArticle"],
                Nom = (string)reader["A_Nom"],
                CodeEAN13 = (string)reader["A_EANCode"],
                Prix = (decimal)reader["A_Prix"],
                Description = (string)reader["A_Description"],
                IdCategorie = (int)reader["C_Id"]
            };
        }

        public IEnumerable<Article> GetAll()
        {
            Connection connection = new Connection(_connectionString);
            string sql = "SELECT * FROM Article";
            Command cmd = new Command(sql, false);

            return connection.ExecuteReader(cmd, Converter);
        }

        public IEnumerable<Article> GetAllByCategorieId(int catId)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "SELECT * FROM Article WHERE C_Id = @catId";
            Command cmd = new Command(sql, false);

            cmd.AddParameter("catId", catId);

            return connection.ExecuteReader(cmd, Converter);
        }

        public Article GetById(int Id)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "SELECT * FROM Article WHERE IdArticle=@id";
            Command cmd = new Command(sql, false);

            cmd.AddParameter("id", Id);

            return connection.ExecuteReader(cmd, Converter).FirstOrDefault();
        }

        public bool Create(Article a)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "INSERT INTO Article (A_Nom, A_Prix, A_EANCode, A_Description, C_Id) VALUES (@nom, @prix, @ean, @desc, @idCat)";
            Command cmd = new Command(sql, false);

            cmd.AddParameter("nom", a.Nom);
            cmd.AddParameter("prix", a.Prix);
            cmd.AddParameter("ean", a.CodeEAN13);
            cmd.AddParameter("desc", a.Description);
            cmd.AddParameter("idCat", a.IdCategorie);

            return connection.ExecuteNonQuery(cmd) == 1;
        }
        public bool Update(Article a)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "UPDATE Article SET A_Nom = @nom, A_Prix = @prix, A_EANCode = @ean, A_Description = @desc, C_Id = @idCat WHERE IdArticle = @id";
            Command cmd = new Command(sql, false);

            cmd.AddParameter("nom", a.Nom);
            cmd.AddParameter("prix", a.Prix);
            cmd.AddParameter("ean", a.CodeEAN13);
            cmd.AddParameter("desc", a.Description);
            cmd.AddParameter("idCat", a.IdCategorie);
            cmd.AddParameter("id", a.IdArticle);

            return connection.ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int id)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "DELETE FROM Article WHERE IdArticle = @id";
            Command cmd = new Command(sql, false);

            cmd.AddParameter("id", id);

            return connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
