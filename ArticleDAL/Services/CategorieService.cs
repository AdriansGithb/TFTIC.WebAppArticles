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
    public class CategorieService : ICategorieRepository
    {
        private readonly string _connectionString;

        public CategorieService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        internal Categorie Converter(IDataRecord reader)
        {
            return new Categorie
            {
                IdCategorie = (int)reader["IdCategorie"],
                Libelle = (string)reader["C_Libelle"]
            };
        }

        public IEnumerable<Categorie> GetAll()
        {
            Connection connection = new Connection(_connectionString);
            string sql = "SELECT * FROM Categorie";
            Command cmd = new Command(sql, false);

            return connection.ExecuteReader(cmd, Converter);
        }

        public Categorie GetById(int Id)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "SELECT * FROM Categorie WHERE IdCategorie=@id";
            Command cmd = new Command(sql, false);

            cmd.AddParameter("id", Id);

            return connection.ExecuteReader(cmd, Converter).FirstOrDefault();
        }
        public Categorie GetByLib(string Libelle)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "SELECT * FROM Categorie WHERE Libelle like @lib";
            Command cmd = new Command(sql, false);

            cmd.AddParameter("lib", Libelle);

            return connection.ExecuteReader(cmd, Converter).FirstOrDefault();
        }

        public bool Create(Categorie c)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "INSERT INTO Categorie (C_Libelle) VALUES (@lib)";
            Command cmd = new Command(sql, false);

            cmd.AddParameter("lib", c.Libelle);

            return connection.ExecuteNonQuery(cmd) == 1;
        }
        public bool Update(Categorie c)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "UPDATE Categorie SET C_Libelle = @lib WHERE IdCategorie = @id";
            Command cmd = new Command(sql, false);

            cmd.AddParameter("lib", c.Libelle);
            cmd.AddParameter("id", c.IdCategorie);

            return connection.ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int id)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "DELETE FROM Categorie WHERE IdCategorie = @id";
            Command cmd = new Command(sql, false);

            cmd.AddParameter("id", id);

            return connection.ExecuteNonQuery(cmd) == 1;
        }

    }
}
