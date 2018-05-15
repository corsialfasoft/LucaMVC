create database Ristorante;
use Ristorante;

create table Primo(
	id int identity (1,1) not null primary key,
	nome nvarchar (20) not null,
	descrizione nvarchar (200)
);

create table Secondo(
	id int identity (1,1) not null primary key,
	nome nvarchar (20) not null,
	descrizione nvarchar (200)
);

create table Contorno(
	id int identity (1,1) not null primary key,
	nome nvarchar (20) not null,
	descrizione nvarchar (200)
);

create table Dolce(
	id int identity (1,1) not null primary key,
	nome nvarchar (20) not null,
	descrizione nvarchar (200)
);

create table Menu(
	id int identity (1,1) not null primary key,
	dataMenu date not null,
	tipoMenu nvarchar (6) not null,	-- pranzo / cena
	primo int foreign key references Primo,
	secondo int foreign key references Secondo,
	contorno int foreign key references Contorno,
	dolce int foreign key references Dolce
);