# API de Gestão de Alunos e Cursos

Este projeto consiste em uma API desenvolvida em C# utilizando ASP.NET Core, que permite o gerenciamento de alunos, cursos e matrículas. A aplicação utiliza o Entity Framework Core para interagir com um banco de dados SQLite e o AutoMapper para mapeamento entre entidades e DTOs.


## Funcionalidades

- **Gerenciamento de Alunos**
  - Listar todos os alunos
  - Buscar aluno por ID
  - Cadastrar novo aluno
  - Atualizar informações do aluno
  - Deletar aluno

- **Gerenciamento de Cursos**
  - Listar todos os cursos
  - Buscar curso por ID
  - Cadastrar novo curso
  - Atualizar informações do curso
  - Deletar curso

- **Gerenciamento de Matrículas**
  - Listar todas as matrículas
  - Buscar matrículas por aluno
  - Buscar matrículas por curso
  - Buscar matrícula por aluno e curso
  - Cadastrar nova matrícula
  - Deletar matrícula

## Tecnologias Utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- AutoMapper
- SQLite
- Swagger para documentação da API

## Estrutura do Projeto

O projeto está organizado em várias pastas principais:

- **Controllers**: Contém as classes que implementam os endpoints da API para gerenciar alunos, cursos e matrículas.
- **Domain**: Contém os modelos de domínio e os DTOs (Data Transfer Objects) utilizados para comunicação entre as camadas.
- **Context**: Contém a classe `CursosDbContext` que gerencia a conexão com o banco de dados.
- **Infra**: Contém as implementações dos repositórios para acesso a dados.
- **Profiles**: Contém as configurações do AutoMapper para o mapeamento entre entidades e DTOs.





