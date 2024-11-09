use AULADB
go
create table TimeFutebol
(
    id int primary key identity (1,1)  not null,
    nome varchar(max) not null ,

    NomeDoEstadio varchar(max)   null,

    LogotipoTime varbinary(max) not null

)


GO
create table Jogadores
(
id int primary key identity (1,1),
nome varchar(max) ,
Posicao int,
TimeId int,
)
GO

create or alter procedure sp_delete(
	@id int,
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'delete ' + @tabela + ' where id = ' + cast( @id as varchar(max))
	exec(@sql)
end
go

create or alter procedure sp_select(
	@id int,
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'select * from  ' + @tabela + ' where id = ' + cast( @id as varchar(max))
	exec(@sql)
end
go

create or alter procedure sp_list(
	@tabela varchar(max)
)
as
begin
	declare @sql varchar(max)
	set @sql = 'select * from  ' + @tabela
	exec(@sql)
end
go


create or alter procedure sp_insert_TimeFutebol(
	@nome varchar(max),
	@NomeDoEstadio varchar(max), 
	@LogotipoTime varbinary(max)
)
as
begin
	insert into TimeFutebol(nome,NomeDoEstadio,LogotipoTime) values(@nome,@NomeDoEstadio,@LogotipoTime)
end
go

create or alter procedure sp_Update_TimeFutebol(
		@id int,
	@nome varchar(max),
	@NomeDoEstadio varchar(max), 
	@LogotipoTime varbinary(max)
)
as
begin
	update TimeFutebol set nome = @nome, NomeDoEstadio = NomeDoEstadio, LogotipoTime = @LogotipoTime where id = @id
end
go

create or alter procedure sp_insert_Jogadores(
	@nome varchar(max),
	@posicao int, 
	@TimeId int
)
as
begin
	insert into Jogadores(nome,Posicao,TimeId) values(@nome,@posicao,@TimeId)
end
go

create or alter procedure sp_update_Jogadores(
	@id int,
	@nome varchar(max),
	@posicao int, 
	@TimeId int
)
as
begin
	update Jogadores set nome = @nome, Posicao = @Posicao, TimeId = @TimeId where id = @id
end
go