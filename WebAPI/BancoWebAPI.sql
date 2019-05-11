-------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- AUTOR: DIEGO RUGUE
-- DATA DE CRIACAO: 10/05/2019
-------------------------------------------------------------------------------------------------------------------------------------------------------------------
USE master;
GO
CREATE DATABASE WebAPIDiego;
GO
USE WebAPIDiego;
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- CRIACAO DAS TABELAS
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

CREATE TABLE Profissao
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(30) NOT NULL,
	DataCadastro DATETIME NOT NULL,
	DataAlteracao VARCHAR(30) NULL
);

GO

CREATE TABLE Empresa
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	RazaoSocial VARCHAR(50) NOT NULL,
	DataCadastro DATETIME NOT NULL,
	DataAlteracao VARCHAR(20) NULL,
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
	IdProfissao INT FOREIGN KEY REFERENCES Profissao(Id),
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
-- INSERCAO DE DADOS DEFAULT
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
INSERT INTO Parentesco (Nome) VALUES ('Mae');
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
	SELECT * FROM EstadoCivil WHERE Id = @Id;
END

GO

CREATE PROCEDURE GetEstadosCivis
AS
BEGIN
	SELECT * FROM EstadoCivil;
END

GO

CREATE PROCEDURE PostEstadoCivil
	@Nome VARCHAR(20)
AS
BEGIN
	INSERT INTO EstadoCivil(Nome) VALUES (@Nome);
END

GO

CREATE PROCEDURE PutEstadoCivil
	@Id INT,
	@Nome VARCHAR(20)
AS
BEGIN
	UPDATE EstadoCivil
		SET Nome = @Nome
		WHERE Id = @Id
END

GO

CREATE PROCEDURE DeleteEstadoCivil
	@Id INT
AS
BEGIN
	DELETE FROM EstadoCivil
	WHERE Id = @Id
END

GO

CREATE PROCEDURE GetParentesco
	@Id INT
AS
BEGIN
	SELECT * FROM Parentesco WHERE Id = @Id;
END

GO

CREATE PROCEDURE GetParentescos
AS
BEGIN
	SELECT * FROM Parentesco;
END

GO

CREATE PROCEDURE PostParentesco
	@Nome VARCHAR(20)
AS
BEGIN
	INSERT INTO Parentesco(Nome) VALUES (@Nome);
END

GO

CREATE PROCEDURE PutParentesco
	@Id INT,
	@Nome VARCHAR(20)
AS
BEGIN
	UPDATE Parentesco
		SET Nome = @Nome
		WHERE Id = @Id
END

GO

CREATE PROCEDURE DeleteParentesco
	@Id INT
AS
BEGIN
	DELETE FROM Parentesco
	WHERE Id = @Id
END

GO

CREATE PROCEDURE GetProfissao
	@Id INT
AS
BEGIN
	SELECT * FROM Profissao WHERE Id = @Id
END

GO

CREATE PROCEDURE GetProfissoes
AS
BEGIN
	SELECT * FROM Profissao
END

GO

CREATE PROCEDURE PostProfissao
	@Nome VARCHAR(30),
	@DataCadastro DATETIME,
	@DataAlteracao VARCHAR(30)
AS
BEGIN
	INSERT INTO Profissao(Nome, DataCadastro, DataAlteracao) 
				VALUES(@Nome, @DataCadastro, @DataAlteracao)
END

GO

CREATE PROCEDURE PutProfissao
	@Id INT,
	@Nome VARCHAR(30),
	@DataAlteracao DATETIME
AS
BEGIN
	UPDATE Profissao
		SET Nome = @Nome,
			DataAlteracao = @DataAlteracao
		WHERE Id = @Id
END

GO

CREATE PROCEDURE DeleteProfissao
	@Id INT
AS
BEGIN
	DELETE FROM Profissao
	WHERE Id = @Id
END

GO

CREATE PROCEDURE GetEmpresa
	@Id INT
AS
BEGIN
	SELECT * FROM Empresa WHERE Id = @Id
END

GO

CREATE PROCEDURE GetEmpresas
AS
BEGIN
	SELECT * FROM Empresa
END

GO

CREATE PROCEDURE PostEmpresa
	@RazaoSocial VARCHAR(50),
	@DataCadastro DATETIME,
	@DataAlteracao VARCHAR(20),
	@CNPJ VARCHAR(20)
AS
BEGIN
	INSERT INTO Empresa(RazaoSocial, DataCadastro, DataAlteracao, CNPJ)
				VALUES (@RazaoSocial, @DataCadastro, @DataAlteracao, @CNPJ)
END

GO 

CREATE PROCEDURE PutEmpresa
	@Id INT,
	@RazaoSocial VARCHAR(50),
	@DataAlteracao VARCHAR(20),
	@CNPJ VARCHAR(20)
AS
BEGIN
	UPDATE Empresa
		SET 
			RazaoSocial = @RazaoSocial,
			DataAlteracao = @DataAlteracao,
			CNPJ = @CNPJ
		WHERE Id = @Id
END

GO

CREATE PROCEDURE DeleteEmpresa
	@Id INT
AS
BEGIN
	DELETE FROM Empresa
	WHERE Id = @Id
END



