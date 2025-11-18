OdontoBox API: Sistema de Gerenciamento de Estoque Odontológico
A OdontoBox API é a solução de backend desenvolvida em C# .NET 9 (ou a versão que você está usando) para o gerenciamento eficiente de materiais e insumos em clínicas odontológicas.
O sistema implementa um conjunto de serviços CRUD (Create, Read, Update, Delete) focados na movimentação de estoque, garantindo a rastreabilidade e o controle de recursos críticos.
Funcionalidades Principais
Catálogo de Produtos: Gerenciamento completo dos itens de estoque (materiais, insumos, etc.).
Controle de Movimentação: Registro detalhado de Entradas (recebimento de lotes) e Saídas (consumo em atendimentos ou descarte).
Atualização Automática de Estoque: O sistema garante que o estoque seja atualizado em tempo real a cada movimentação de entrada ou saída.
Regras de Negócio: Aplicação de regras críticas, como a verificação de estoque mínimo e o bloqueio de saídas quando o material é insuficiente.
Base de Fornecedores: Cadastro e gerenciamento dos parceiros comerciais para rastreabilidade de compras.
A arquitetura é modular, permitindo que cada componente (Produto, Entrada, Saída, Fornecedor) seja desenvolvido e mantido de forma independente, mas totalmente integrado para fornecer uma visão precisa e funcional do inventário da clínica.








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
