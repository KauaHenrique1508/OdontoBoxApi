instalar os pacotes
### dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 9.0.0
### dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
### dotnet tool install --global dotnet-ef --version 9.0.0


Para gerar as migrations
### dotnet ef migrations add nomeDaMigration

Para rodar as migrations
### dotnet ef database update

Como rodar o projeto
### dotnet run
* ele vai rodar na porta http://localhost:5183