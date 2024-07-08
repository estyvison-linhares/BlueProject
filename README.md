# BlueProject

BlueProject é uma aplicação para gerenciamento de contatos desenvolvida como projeto de processo de seleção na Blue Technology. Este repositório contém o backend desenvolvido com .NET Core e o frontend desenvolvido com Vue.js usando PrimeVue.

## Tecnologias Usadas

### Backend
- .NET Core
- Entity Framework Core
- MediatR
- AutoMapper
- Swagger

### Frontend
- Vue.js
- PrimeVue
- Axios

## Configuração do Backend

### Requisitos
- .NET SDK 6.0 ou superior
- SQL Server

### Passos para Configuração

1. **Clone o Repositório:**

   ```bash
   git clone https://github.com/estyvison-linhares/BlueProject.git
   cd blueproject
  
2. **Configurar a String de Conexão do Banco de Dados:**
  No arquivo appsettings.json, configure a string de conexão para seu servidor SQL Server.

    ```bash
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=BlueProjectDB;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
    }
3. **Aplicar as Migrações e Atualizar o Banco de Dados:**
   Selecione a opção tools no visual studio -> Nuget Package Manager -> Package Manager Console. Após abrir o terminal selecione o projeto de BlueProject.Infra na lista de project default. Após isso digite os seguintes comandos:
    ```bash
    Add-Migration {nome-da-migration}
    Update-Database
4. **Executar o projeto backend:**
   Clique no botão de executar do visual studio usando o https.
   O Swagger estará disponível em https://localhost:7016/swagger.

## Configuração do Frontend

### Requisitos
- Node.js 
- npm ou yarn

### Passos para Configuração

1. **Instalar Vue CLI:**
  Se você ainda não tiver o Vue CLI instalado, instale-o globalmente:

   ```bash
    npm install -g @vue/cli

2. **Navegar até o Diretório do Frontend e Instalar Dependências:**

   ```bash
   cd frontend
   npm install
   npm install primevue@3.7.1 primeicons@4.1.0

3. **Inicie o servidor de desenvolvimento:**

   ```bash
   npm run serve
  O frontend estará disponível em http://localhost:8080.

## Estrutura do projeto

### Backend
- `BlueProject.API`: Contém a API e a configuração do projeto.
- `BlueProject.Business`: Contém a lógica de negócios, comandos, manipuladores e perfis de mapeamento.
- `BlueProject.Business.Tests`: Contém os testes de unidade dos projeto.
- `BlueProject.Infra`: Contém a camada de acesso a dados, repositórios e o DbContext.
- `BlueProject.Doman`: Contém as entidades e classe de Exceções.

 ### Frontend
 - Biblioteca primevue e os seguintes componentes:
    - Button
    - Column
    - DataTable
    - Dialog
    - InputText
    - Toast
    - ToastService
  - Biblioteca axios para acessar as rotas do backend
  - ContactForm componente de contatos

## Endpoints da API
- GET /api/Contacts: Retorna todos os contatos
- GET /api/Contacts/{id}: Retorna um contato por ID.
- POST /api/Contacts: Cria um novo contato
- PUT /api/Contacts/{id}: Atualiza um contato existente.
- DELETE /api/Contacts/{id}: Exlui um contato.

## Desafios enfrentados na construção desse projeto:
- Implementação do padrão CQRS
- Implementação de práticas do DDD
- Aprendizado do Front com vue.js

## Contato
Para mais informações, entre em contato com [titoalbuquerque34@gmail.com].


   
