DECLARE @Id int, @Nome varchar(30), @Email varchar(30), @Cpf varchar(11), @DataNasc Date

SET @Id = 3
SET @DataNasc = '22/03/2001'
SET @Cpf = '123456'
SET @Email = 'testa@gmail.com'

IF EXISTS (SELECT 1 FROM dbo.Usuarios WHERE id = @Id)
BEGIN
	IF(@Email is not null) AND EXISTS (SELECT 1 FROM dbo.Usuarios WHERE email = @Email)
	BEGIN
	PRINT 'EMAIL ' + @Email + ' EM USO'
	RETURN
	END

	IF(@Cpf is not null) AND EXISTS (SELECT 1 FROM dbo.Usuarios WHERE cpf = @Cpf)
	BEGIN
	PRINT 'CPF ' + @Cpf + ' EM USO'
	RETURN
	END

	UPDATE dbo.Usuarios 
		SET 
		nome = IsNull(@Nome, nome),
		datanasc = IsNull(@DataNasc, datanasc),
		cpf = IsNull(@Cpf, cpf),
		email = IsNull(@Email, email)
	WHERE id = @id

	PRINT 'Usuario ID Editado'
END