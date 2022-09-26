create database ONGAdocao;
use ONGAdocao;

create table Endereco (
	CEP varchar(9),
	Bairro varchar (30),
	Rua varchar(50),
	Numero int,
	constraint PK_Endereco PRIMARY KEY (CEP)
);

create table Pessoa (
	Nome varchar(50) NOT NULL,
	CPF varchar(11) NOT NULL,
	Sexo char(1),
	DataNascimento date NOT NULL,
	Endereco varchar(9) NOT NULL,
	Telefone varchar(50),
	CONSTRAINT PK_Pessoa PRIMARY KEY (CPF),
	CONSTRAINT FK_Endereco FOREIGN KEY (Endereco) references Endereco(CEP)
);

create table Animal (
	Chip int identity,
	Familia varchar(20) not null,
	Raca varchar(30) not null,
	Sexo char(1) not null,
	Nome varchar(20),
	Situacao char(1) not null,
	constraint PK_Animal PRIMARY KEY(Chip)
);

create table Adocoes (
	ID int identity,
	CPF varchar(11) NOT NULL,
	Chip int NOT NULL,
	DataAdocao date,
	constraint FK_Animal FOREIGN KEY(Chip) references Animal(Chip),
	constraint FK_Pessoa FOREIGN KEY(CPF) references Pessoa(CPF)
);