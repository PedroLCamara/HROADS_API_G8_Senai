CREATE DATABASE SENAI_HROADS_TARDE;
GO

USE SENAI_HROADS_TARDE;
GO



create table Classe (
IdClasse tinyint primary key identity(1,1),
NomeClasse VARCHAR(30) not null,
);
GO

create table Personagem (
IdPersonagem tinyint primary key identity(1,1),
IdClasse tinyint foreign key references Classe(IdClasse),
NomePersonagem VARCHAR(20) NOT NULL UNIQUE,
Vida tinyint NOT NULL,
Mana tinyint NOT NULL,
DataCriacao date NOT NULL,
DataUpdate date NOT NULL,
);
GO

create table TipoHabilidade (
IdTipoHab tinyint primary key identity(1,1),
NomeTipoHab VARCHAR (30) NOT NULL,
);
GO

create table Habilidade (
IdHabilidade tinyint primary key identity(1,1),
IdTipoHabilidade tinyint foreign key references TipoHabilidade(IdTipoHab),
NomeHabilidade varchar (30) NOT NULL
);
GO

create table ConClasseHab (
IdConClasseHab smallint primary key identity(1,1),
IdClasse tinyint foreign key references Classe(IdClasse),
IdHabilidade tinyint foreign key references Habilidade(IdHabilidade)
);
GO

CREATE TABLE TipoUsuario(
	IdTipoUsuario TINYINT PRIMARY KEY IDENTITY(1,1),
	TituloTipoUsuario VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY(1,1),
	IdTipoUsuario TINYINT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
	Email VARCHAR(256) NOT NULL UNIQUE,
	Senha VARCHAR(16) CHECK(LEN(Senha) >= 5)
);
GO


--Alteracoes

ALTER TABLE Personagem 
ADD IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario);
GO