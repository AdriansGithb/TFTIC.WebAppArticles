CREATE TABLE [dbo].[Article]
(
	IdArticle INT NOT NULL PRIMARY KEY IDENTITY,
	A_Nom VARCHAR(100) NOT NULL,
	A_Prix DECIMAL(10,2) NOT NULL,
	A_EANCode VARCHAR(13) NOT NULL,
	A_Description VARCHAR(500), 
	C_Id INT NOT NULL,
    CONSTRAINT [FK_Article_Categorie] FOREIGN KEY (C_Id) REFERENCES Categorie
)
