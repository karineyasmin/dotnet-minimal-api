# Catálogo API

Este projeto é uma **Minimal API** desenvolvida em .NET 6 para gerenciar um catálogo de produtos e categorias. O objetivo é explorar os conceitos de Minimal APIs e criar uma aplicação simples e eficiente para fins de aprendizado e desenvolvimento.

## O que é uma Minimal API?

Uma **Minimal API** é uma abordagem simplificada para criar APIs no .NET, introduzida a partir do .NET 6. Ela permite criar endpoints de forma direta e minimalista, sem a necessidade de configurar controladores ou usar a estrutura completa do ASP.NET Core MVC.

### Quando usar Minimal APIs?

Minimal APIs são ideais para:
- Aplicações pequenas ou microserviços.
- Prototipagem rápida de APIs.
- Projetos onde a simplicidade e a performance são prioridades.

No entanto, para aplicações maiores ou mais complexas, pode ser mais adequado usar a abordagem tradicional com controladores e MVC.

## Sobre o Projeto

O **Catálogo API** é uma aplicação que permite gerenciar produtos e categorias. Ele utiliza o Entity Framework Core para persistência de dados e PostgreSQL como banco de dados.

### Funcionalidades:
- Gerenciamento de produtos (CRUD).
- Gerenciamento de categorias (CRUD).
- Relacionamento entre produtos e categorias.

### Tecnologias utilizadas:
- .NET 6
- Entity Framework Core
- PostgreSQL
- Docker

## Status do Projeto

🚧 **Este projeto está em desenvolvimento.** Algumas funcionalidades podem estar incompletas ou sujeitas a alterações.

## Como executar o projeto

1. Certifique-se de ter o Docker e o Docker Compose instalados em sua máquina.

2. Configure o arquivo `docker-compose.yml` com os dados do banco de dados e as configurações do JWT. Por padrão, ele já está configurado com as seguintes credenciais e informações:
   ```yml
   environment:
     POSTGRES_USER: postgres
     POSTGRES_PASSWORD: postgres
     POSTGRES_DB: CatalogoDatabase
     ASPNETCORE_ENVIRONMENT: Development
     ConnectionStrings__DefaultConnection: "Host=postgres;Database=CatalogoDatabase;Username=postgres;Password=postgres"
     Jwt__Key: "SUA_CHAVE_SECRETA_AQUI"
     Jwt__Issuer: "CatalogoApi"
     Jwt__Audience: "CatalogoApi"
   ```
   Caso necessário, altere essas informações no arquivo `docker-compose.yml` para atender às suas necessidades.

3. Suba os containers do projeto (banco de dados e aplicação) usando o Docker Compose:
   ```bash
   docker-compose up -d
   ```
   Isso criará um container com o PostgreSQL e outro com a aplicação rodando no .NET 6.

4. A aplicação estará disponível em `http://localhost:5000`. Você pode acessar a documentação Swagger em `http://localhost:5000/swagger`.

---

**Nota:** Todas as configurações sensíveis, como a string de conexão com o banco de dados e as informações do JWT, são gerenciadas diretamente no `docker-compose.yml`. Não é necessário alterar o arquivo `appsettings.json`, pois as variáveis de ambiente definidas no `docker-compose.yml` sobrescrevem as configurações padrão.
---
**Nota:** Este projeto é apenas para fins educacionais e de aprendizado.