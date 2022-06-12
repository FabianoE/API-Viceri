CREATE TABLE [dbo].[Usuarios] (
    [id]       INT IDENTITY (1, 1) NOT NULL,
    [nome]     VARCHAR (30) NOT NULL,
    [email]    VARCHAR (30) NOT NULL,
    [cpf]      VARCHAR (11) NOT NULL,
    [senha]    VARCHAR (30) NOT NULL,
    [datanasc] DATE         NOT NULL,
);