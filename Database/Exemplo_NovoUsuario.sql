Declare @Nome varchar(30), @Email varchar(30), @Senha varchar(30), @DataNasc Date, @Cpf varchar(11);

Set @Nome = 'Fabiano'
Set @Email = 'email@gmail.com'
Set @Senha = '12345'
Set @DataNasc = '21/03/2010'
Set @Cpf = '12345678945'


IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE email = @Email and cpf = @Cpf)
BEGIN
	INSERT INTO dbo.Usuarios (nome, cpf, datanasc, email, senha) VALUES (@Nome, @Cpf, @DataNasc, @Email, @Senha)
END
ELSE
BEGIN
	PRINT 'Email ou CPF em uso'
END