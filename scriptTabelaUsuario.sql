Create table Usuarios
(
	UsuarioId	int identity,
	Login		varchar(200),
	Nome		varchar(200),
	Senha		varchar(200),
	Email		varchar(200),
	Funcao		varchar(200)
)

ALTER TABLE Usuarios
ADD CONSTRAINT PK_Usuarios PRIMARY KEY (UsuarioId)

insert into Usuarios values ('akikuchi','Aline Yumi Kikuchi', '123', 'akikuchi@hotmail.com', 'Gerente')
insert into Usuarios values ('mariaj', 'Maria Joaquina dos Santos', '1234', 'teste@hotmail.com', 'Funcionario')
insert into Usuarios values ('joseSilva','José da Silva', '12345', 'teste2@hotmail.com', 'Funcionario')
insert into Usuarios values ('alyssa','Alissa Yukari', '12345', 'alissa@hotmail.com', 'Funcionario')
insert into Usuarios values ('pedro','Pedro Gonçalves', '12345', 'pg@hotmail.com', 'Gerente')