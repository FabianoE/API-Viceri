DECLARE @Id int

SELECT 
	id, 
	nome, 
	email, 
	cpf, 
	senha, 
	datanasc 
FROM dbo.Usuarios WHERE id = @Id