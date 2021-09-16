use SENAI_HROADS_TARDE;
go

insert into TipoHabilidade(NomeTipoHab)
values ('Ataque'), ('Defesa'), ('Magia'), ('Cura');
go

insert into Classe(NomeClasse)
values ('Bárbaro'), ('Cruzado'), ('Caçadora de Demônios'), ('Monge'), ('Necromante'), ('Feiticeiro'), ('Arcanista');
go

insert into Habilidade(IdTipoHabilidade, NomeHabilidade)
values (1, 'Lança Mortal'), (2, 'Escudo Supremo'), (4, 'Recuperar Vida');
go

insert into ConClasseHab(IdClasse, IdHabilidade)
values (1,	1), (1, 2), (2,	2), (3, 1), (4, 2), (4, 3), (6, 3);
go

INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES ('Administrador'), ('Jogador');
GO

INSERT INTO Usuario(IdTipoUsuario, Email, Senha)
VALUES (1, 'admin@admin.com', 'admin'), (2,'player@player.com', 'player');
GO

insert into Personagem(IdClasse, NomePersonagem, Mana, Vida, DataUpdate, DataCriacao, IdUsuario)
values (1, 'DeuBug', 80, 100, '10/08/2021', '19/01/2019', 2), (4, 'BitBug', 100, 70, '10/08/2021', '17/03/2016', 2), (7, 'Fer8', 60,	75,	'10/08/2021', '18/03/2018', 2);
go