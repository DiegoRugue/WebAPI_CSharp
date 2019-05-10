-------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- AUTOR: DIEGO RUGUE
-- DATA DE CRIAÇÃO: 10/05/2019
-------------------------------------------------------------------------------------------------------------------------------------------------------------------
USE master;
GO
CREATE DATABASE WebAPIDiego;
GO
USE WebAPIDiego;
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- CRIAÇÃO DAS TABELAS
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE TABLE EstadoCivil
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(20) NOT NULL

);

GO

CREATE TABLE Parentesco
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(20) NOT NULL
);

GO

CREATE TABLE Profissoes
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(30) NOT NULL,
	DataCadastro DATETIME NOT NULL,
	DataAlteracao DATETIME NOT NULL
);

GO

CREATE TABLE Empresa
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	RazaoSocial VARCHAR(50) NOT NULL,
	DataCadastro DATETIME NOT NULL,
	DataAlteracao DATETIME NOT NULL,
	CNPJ VARCHAR(20) NOT NULL
);

GO

CREATE TABLE Funcionarios
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(50) NOT NULL,
	CPF VARCHAR(15) NOT NULL,
	DataNascimento DATETIME NOT NULL,
	Telefone VARCHAR(20) NOT NULL,
	DataCadastro DATETIME NOT NULL,
	DataAlteracao DATETIME NOT NULL,
	EnderecoRua VARCHAR(50) NOT NULL,
	EnderecoNumero INT NOT NULL,
	EnderecoBairro VARCHAR(50) NOT NULL,
	EnderecoCidade VARCHAR(30) NOT NULL,
	EnderecoEstado VARCHAR(30) NOT NULL,
	EnderecoCep VARCHAR(20) NOT NULL,
	EnderecoComplemento VARCHAR(100) NOT NULL,
	IdProfissoes INT FOREIGN KEY REFERENCES Profissoes(Id),
	IdEmpresa INT FOREIGN KEY REFERENCES Empresa(Id),
	IdEstadoCivil INT FOREIGN KEY REFERENCES EstadoCivil(Id)
);

GO

CREATE TABLE Dependentes
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(50) NOT NULL,
	CPF VARCHAR(15) NOT NULL,
	DataNascimento DATETIME NOT NULL,
	DataCadastro DATETIME NOT NULL,
	DataAlteracao DATETIME NOT NULL,
	IdFuncionario INT FOREIGN KEY REFERENCES Funcionarios(Id),
	IdParentesco INT FOREIGN KEY REFERENCES Parentesco(Id)
);

GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- INSERÇÃO DE DADOS DEFAULT
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

INSERT INTO EstadoCivil (Nome) VALUES ('Casado');
GO
INSERT INTO EstadoCivil (Nome) VALUES ('Solteiro');
GO
INSERT INTO EstadoCivil (Nome) VALUES ('Divorciado');
GO
INSERT INTO EstadoCivil (Nome) VALUES ('Viuvo');
GO

INSERT INTO Parentesco (Nome) VALUES ('Pai');
GO
INSERT INTO Parentesco (Nome) VALUES ('Mãe');
GO
INSERT INTO Parentesco (Nome) VALUES ('Filho');
GO
INSERT INTO Parentesco (Nome) VALUES ('Conjuge');

GO
-------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- PROCEDURES
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE GetEstadoCivil 
	@Id INT
AS
BEGIN
	SELECT * FROM EstadoCivil WHERE Id = @Id
END

GO