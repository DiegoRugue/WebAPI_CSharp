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
	Nome VARCHAR(30) UNIQUE NOT NULL,
	DataCadastro VARCHAR(20) NOT NULL,
	DataAlteracao VARCHAR(20) NULL
);

GO

CREATE TABLE Empresa
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	RazaoSocial VARCHAR(50) NOT NULL,
	DataCadastro VARCHAR(20) NOT NULL,
	DataAlteracao VARCHAR(20) NULL,
	CNPJ VARCHAR(20) UNIQUE NOT NULL
);

GO

CREATE TABLE Funcionario
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(50) NOT NULL,
	CPF VARCHAR(15) UNIQUE NOT NULL,
	DataNascimento VARCHAR(20) NOT NULL,
	Telefone VARCHAR(20) NOT NULL,
	DataCadastro VARCHAR(20) NOT NULL,
	DataAlteracao VARCHAR(20) NULL,
	EnderecoRua VARCHAR(50) NOT NULL,
	EnderecoNumero INT NOT NULL,
	EnderecoBairro VARCHAR(50) NOT NULL,
	EnderecoCidade VARCHAR(30) NOT NULL,
	EnderecoEstado VARCHAR(30) NOT NULL,
	EnderecoCep VARCHAR(20) NOT NULL,
	EnderecoComplemento VARCHAR(100) NOT NULL,
	IdProfissao INT FOREIGN KEY REFERENCES Profissao(Id) NOT NULL,
	IdEmpresa INT FOREIGN KEY REFERENCES Empresa(Id) NOT NULL,
	IdEstadoCivil INT FOREIGN KEY REFERENCES EstadoCivil(Id) NOT NULL
);

GO

CREATE TABLE Dependente
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(50) NOT NULL,
	CPF VARCHAR(15) UNIQUE NOT NULL,
	DataNascimento VARCHAR(20) NOT NULL,
	DataCadastro VARCHAR(20) NOT NULL,
	DataAlteracao VARCHAR(20) NULL,
	IdFuncionario INT FOREIGN KEY REFERENCES Funcionario(Id) UNIQUE,
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
	@DataCadastro VARCHAR(20),
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
	@DataAlteracao VARCHAR(20)
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
	@DataCadastro VARCHAR(20),
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

GO

CREATE PROCEDURE GetFuncionario
	@Id INT
AS
BEGIN
	SELECT * FROM Funcionario WHERE Id = @Id
END

GO

CREATE PROCEDURE GetFuncionarios
AS
BEGIN
	SELECT * FROM Funcionario
END

GO

CREATE PROCEDURE PostFuncionario
	@Nome VARCHAR(50),
	@CPF VARCHAR(15),
	@DataNascimento VARCHAR(20),
	@Telefone VARCHAR(20),
	@DataCadastro VARCHAR(20),
	@DataAlteracao VARCHAR(20),
	@EnderecoRua VARCHAR(50),
	@EnderecoNumero INT,
	@EnderecoBairro VARCHAR(50),
	@EnderecoCidade VARCHAR(30),
	@EnderecoEstado VARCHAR(30),
	@EnderecoCep VARCHAR(20),
	@EnderecoComplemento VARCHAR(100),
	@IdProfissao INT,
	@IdEmpresa INT,
	@IdEstadoCivil INT
AS
BEGIN
	INSERT INTO Funcionario
	(
		Nome, CPF, DataNascimento, Telefone, DataCadastro, 
		DataAlteracao, EnderecoRua, EnderecoNumero, EnderecoBairro, EnderecoCidade, 
		EnderecoEstado, EnderecoCep, EnderecoComplemento, IdProfissao, IdEmpresa, IdEstadoCivil
	)

	VALUES
	(
		@Nome, @CPF, @DataNascimento, @Telefone, @DataCadastro, 
		@DataAlteracao, @EnderecoRua, @EnderecoNumero, @EnderecoBairro, @EnderecoCidade, 
		@EnderecoEstado, @EnderecoCep, @EnderecoComplemento, @IdProfissao, @IdEmpresa, @IdEstadoCivil
	)
END

GO

CREATE PROCEDURE PutFuncionario
	@Id INT,
	@Nome VARCHAR(50),
	@CPF VARCHAR(15),
	@DataNascimento VARCHAR(20),
	@Telefone VARCHAR(20),
	@DataAlteracao VARCHAR(20),
	@EnderecoRua VARCHAR(50),
	@EnderecoNumero INT,
	@EnderecoBairro VARCHAR(50),
	@EnderecoCidade VARCHAR(30),
	@EnderecoEstado VARCHAR(30),
	@EnderecoCep VARCHAR(20),
	@EnderecoComplemento VARCHAR(100),
	@IdProfissao INT,
	@IdEmpresa INT,
	@IdEstadoCivil INT
AS
BEGIN
	UPDATE Funcionario
		SET 
			Nome = @Nome,
			CPF = @CPF,
			DataNascimento = @DataNascimento,
			Telefone = @Telefone,
			DataAlteracao = @DataAlteracao,
			EnderecoRua = @EnderecoRua,
			EnderecoNumero = @EnderecoNumero,
			EnderecoBairro = @EnderecoBairro,
			EnderecoCidade = @EnderecoCidade,
			EnderecoEstado = @EnderecoEstado,
			EnderecoCep = @EnderecoCep,
			EnderecoComplemento = @EnderecoComplemento,
			IdProfissao = @IdProfissao,
			IdEmpresa = @IdEmpresa,
			IdEstadoCivil = @IdEstadoCivil

	WHERE Id = @Id

END

GO

CREATE PROCEDURE DeleteFuncionario
	@Id INT
AS
BEGIN
	DELETE FROM Funcionario
	WHERE Id = @Id
END

GO

CREATE PROCEDURE GetDependente
	@Id INT
AS
BEGIN
	SELECT * FROM Dependente WHERE Id = @Id
END

GO

CREATE PROCEDURE GetDependentes
AS
BEGIN
	SELECT * FROM Dependente
END

GO

CREATE PROCEDURE PostDependente
	@Nome VARCHAR(50),
	@CPF VARCHAR(15),
	@DataNascimento VARCHAR(20),
	@DataCadastro VARCHAR(20),
	@DataAlteracao VARCHAR(20),
	@IdFuncionario INT,
	@IdParentesco INT
AS
BEGIN
	INSERT INTO Dependente
	(
		Nome,
		CPF,
		DataNascimento,
		DataCadastro,
		DataAlteracao,
		IdFuncionario,
		IdParentesco
	)
	VALUES
	(
		@Nome,
		@CPF,
		@DataNascimento,
		@DataCadastro,
		@DataAlteracao,
		@IdFuncionario,
		@IdParentesco
	)

END

GO

CREATE PROCEDURE PutDependente
	@Id INT,
	@Nome VARCHAR(50),
	@CPF VARCHAR(15),
	@DataNascimento VARCHAR(20),
	@DataCadastro VARCHAR(20),
	@DataAlteracao VARCHAR(20),
	@IdFuncionario INT,
	@IdParentesco INT
AS
BEGIN
	UPDATE Dependente
		SET
			Nome = @Nome,
			CPF = @CPF,
			DataNascimento = @DataNascimento,
			DataCadastro = @DataCadastro,
			DataAlteracao = @DataAlteracao,
			IdFuncionario = @IdFuncionario,
			IdParentesco = @IdParentesco
		WHERE Id = @Id

END

GO

CREATE PROCEDURE DeleteDependente
	@Id INT
AS
BEGIN
	DELETE FROM Dependente WHERE Id = @Id
END