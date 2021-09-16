use SENAI_HROADS_TARDE;
go

select * from Personagem;
go

select * from Classe;
go

select * from Habilidade;
go

select * from TipoHabilidade;
go

SELECT * FROM ConClasseHab
INNER JOIN Habilidade
ON ConClasseHab.IdHabilidade = Habilidade.IdHabilidade
INNER JOIN Classe
ON ConClasseHab.IdClasse = Classe.IdClasse;
GO

SELECT * FROM Usuario;
GO

SELECT * FROM TipoUsuario;
GO