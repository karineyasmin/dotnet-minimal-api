# Catálogo API

Este projeto é uma **Minimal API** desenvolvida em .NET 9 para gerenciar um catálogo de produtos e categorias. O objetivo é explorar os conceitos de Minimal APIs e criar uma aplicação simples e eficiente para fins de aprendizado e desenvolvimento.

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
- .NET 9
- Entity Framework Core
- PostgreSQL
- Docker (para o banco de dados)

## Status do Projeto

🚧 **Este projeto está em desenvolvimento.** Algumas funcionalidades podem estar incompletas ou sujeitas a alterações.

## Como executar o projeto

1. Certifique-se de ter o .NET 9 SDK instalado.
2. Configure a string de conexão no arquivo `appsettings.json`. Exemplo:
   ```json
   {
       "ConnectionStrings": {
           "DefaultConnection": "Host=localhost;Port=5432;Database=CatalogoDatabase;Username=postgres;Password=postgres;"
       }
   }
   ```
3. Suba o banco de dados PostgreSQL usando o Docker Compose:
   ```bash
   docker-compose up -d
   ```
   Isso criará um container com o PostgreSQL configurado para o projeto.

4. Execute as migrações do banco de dados:
   ```bash
   dotnet ef database update
   ```

5. Inicie a aplicação:
   ```bash
   dotnet run
   ```

---
**Nota:** Este projeto é apenas para fins educacionais e de aprendizado.