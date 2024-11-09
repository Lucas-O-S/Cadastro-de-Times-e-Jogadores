Desenvolva um cadastro de times e jogadores
```Sql
create table TimeFutebol
(
    id int primary key identity (1,1)  not null,
    nome varchar(max) not null ,

    NomeDoEstadio varchar(max)   null,

    LogotipoTime image not null

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
````
Posições: Enumerador com (Goleiro, Atacante, Meia, Zagueiro, Lateral)

Validações : Todos os campos são obrigatórios com exceção do nome do estádio, que é opcional.

Fazer usando herança, utilizar caixa combo para as posições dos jogadores e para escolher o time no cadastro de jogador.

Colocar as opões no menu para acessar o cadastro de time e o cadastro de jogadores.

Exiba o logotipo do time na hora de cadastrar o jogador e também na listagem de times.

