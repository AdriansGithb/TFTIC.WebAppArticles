/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Categorie (C_Libelle) VALUES 
('Jeu de société'),
('Jeu video'),
('Jouet'),
('Puzzle'),
('Console'),
('Autre');

INSERT INTO Article (A_Nom, A_Prix, A_EANCode, A_Description, C_Id) VALUES
('Les aventuriers du rail : Europe', 20.0, '0824968202333', 'Les Aventuriers du Rail: Europe - 15ème Anniversaire', 1),
('Call Of Duty : Vanguard', 59.99, '5030917295300', 'Version PC', 2),
('Pat''Patrouille Transporter', 39.95, '0564895432125', 'Camion des pat patrouilles', 3),
('Puzzle Anim''o', 14.95, '5641380341259', 'Puzzle en forme d''animaux', 4),
('PlayStation 5', 399.0, '4571320159752', 'Console PlayStation 5', 5);
