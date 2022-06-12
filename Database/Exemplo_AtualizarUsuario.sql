DECLARE @Id int, @Nome varchar(30), @Email varchar(30), @Cpf varchar(11), @DataNasc Date

SET @Id = 2
SET @DataNasc = '22/03/2001'

IF EXISTS (SELECT 1 FROM dbo.Usuarios WHERE id = @Id)
BEGIN
	UPDATE dbo.Usuarios 
		SET 
		nome = IsNull(@Nome, nome),
		email = IsNull(@Email, email),
		cpf = IsNull(@Cpf, cpf),
		datanasc = IsNull(@DataNasc, datanasc)
	WHERE id = @id
	PRINT 'Usuario ID Editado'
END