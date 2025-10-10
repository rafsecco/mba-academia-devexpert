# Academia DevExpert - Plataforma de Educação Online

## 1. Apresentação

Bem-vindo ao repositório do projeto **Academia DevExpert**. Este projeto é uma entrega do [MBA DevXpert Full Stack .NET](https://desenvolvedor.io/mba) referente ao **módulo 03**.
O objetivo principal desenvolver um sistema de educação online com controle de acesso e aplicação dos seguintes `bounded context`:
  - Gestão de Conteúdo
  - Gestão de Alunos
  - Pagamento e Faturamento

### **Autor(es)**
- Rafael Secco

## 2. Proposta do Projeto

O projeto consiste em:
- **API RESTful:** Exposição dos recursos da plataforma de educação para integração com outras aplicações ou desenvolvimento de front-ends alternativos.
- **Autenticação e Autorização:** Implementação de controle de acesso, diferenciando administradores e usuários comuns.
- **Acesso a Dados:** Implementação de acesso ao banco de dados através de ORM.

## 3. Tecnologias Utilizadas

- **Linguagem de Programação:** C#
- **Frameworks:**
  - ASP.NET Core Web API
  - Entity Framework Core
- **Banco de Dados:** SQL Server (Prod) e SQLite (Dev)
- **Autenticação e Autorização:**
  - ASP.NET Core Identity
  - JWT (JSON Web Token) para autenticação na API
- **Documentação da API:** Swagger

## 4. Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

```text
mba-modulo-03-academia-devexpert/
├─ src/
│  └─BackEnd
│     ├─ academia-devexpert.API/ - API RESTful
│     ├─ academia-devexpert.Business/ - Modelos, interfaces, regras de negócios
|     └─ academia-devexpert.Data/ - Modelos de Dados e Configuração do EF Core
├─ .editorconfig - Arquivo para padronizar formatação dos arquivos
├─ .gitignore - Arquivo de Ignoração do Git
├─ FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
├─ README.md - Arquivo de Documentação do Projeto
└─ mba-modulo-03-academia-devexpert.sln - Arquivo da Solução do Projeto
```

## 5. Funcionalidades Implementadas

- **Autenticação e Autorização:** Todos os usuários são considerados vendedores.
- **API RESTful:** Exposição de endpoints para operações via API.
- **Documentação da API:** Documentação automática dos endpoints da API utilizando Swagger.

## 6. Como Executar o Projeto

### Pré-requisitos

- .NET SDK 9.0 ou superior
- SQL Server
- Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)
- Git

### Passos para Execução

1. **Clone o Repositório:**
  `git clone https://github.com/rafsecco/mba-modulo-03-academia-devexpert.git`

2. **Configurações:**
  - No arquivo `appsettings.json`, configure a string de conexão do SQL Server e chaves do JWT.
  - Rode o projeto para que a configuração do Seed crie o banco e popule com os dados básicos

3. **Executar a API:**
  - Entre na pasta do projeto da API:
    ```bash
    cd mba-modulo-03-academia-devexpert/src/BackEnd/academia-devexpert.API/
    ```
  - Execute o projeto:
    - Ambiente de desenvolviento:
      ```bash
      dotnet run
      ```
    - Ambiente de produção:
      ```bash
      dotnet run -e ASPNETCORE_ENVIRONMENT="Production"
      ```
  - Acesse a API em:
    https://localhost:7167/

## 7. Documentação da API

A documentação da API está disponível através do Swagger.
Após iniciar a API, acesse a documentação em:

http://localhost:5077/swagger
https://localhost:7167/swagger


## 8. Avaliação

- Este projeto é parte de um curso acadêmico e não aceita contribuições externas.
- Para feedbacks ou dúvidas utilize o recurso de Issues
- O arquivo `FEEDBACK.md` é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.
