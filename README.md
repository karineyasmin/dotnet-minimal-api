# Catálogo API

Este projeto é uma **Minimal API** desenvolvida em .NET 6 para gerenciar um catálogo de produtos e categorias. O objetivo é explorar os conceitos de Minimal APIs e criar uma aplicação simples e eficiente para fins de aprendizado e desenvolvimento.

---

## O que é uma Minimal API?

Uma **Minimal API** é uma abordagem simplificada para criar APIs no .NET, introduzida a partir do .NET 6. Ela permite criar endpoints de forma direta e minimalista, sem a necessidade de configurar controladores ou usar a estrutura completa do ASP.NET Core MVC.

### Quando usar Minimal APIs?

Minimal APIs são ideais para:
- Aplicações pequenas ou microserviços.
- Prototipagem rápida de APIs.
- Projetos onde a simplicidade e a performance são prioridades.

No entanto, para aplicações maiores ou mais complexas, pode ser mais adequado usar a abordagem tradicional com controladores e MVC.

---

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

---

## Estrutura do Projeto

### Dockerfile

O `Dockerfile` é responsável por configurar o ambiente da aplicação. Ele realiza as seguintes etapas:
1. Usa a imagem base do .NET SDK 6.0.
2. Define o diretório de trabalho como `/app`.
3. Instala a ferramenta `dotnet-ef` para gerenciar migrações do banco de dados.
4. Copia os arquivos do projeto para o container.
5. Restaura as dependências e compila o projeto.
6. Define o comando para:
   - Aplicar as migrações do banco de dados (`dotnet ef database update`).
   - Iniciar a aplicação (`dotnet run --urls http://0.0.0.0:5000`).

### docker-compose.yml

O `docker-compose.yml` orquestra os serviços necessários para a aplicação:
- **PostgreSQL**:
  - Banco de dados usado pela aplicação.
  - Configurado com usuário, senha e nome do banco de dados.
  - Expõe a porta `5432`.
  - Armazena os dados em um volume persistente (`postgres_data`).
- **dotnet-app**:
  - Serviço da aplicação .NET.
  - Depende do serviço PostgreSQL.
  - Configurado com variáveis de ambiente para conexão com o banco e JWT.
  - Expõe a porta `5000`.
  - Executa os comandos para aplicar migrações e iniciar a aplicação.

---

## Como executar o projeto

### Subir os containers

1. Certifique-se de ter o Docker e o Docker Compose instalados em sua máquina.
2. Configure o arquivo `docker-compose.yml` conforme necessário.
3. Execute o comando para subir os containers:
   ```bash
   docker-compose up -d
   ```
   Isso criará e iniciará os containers do PostgreSQL e da aplicação.

4. A aplicação estará disponível em `http://localhost:5000`. Acesse a documentação Swagger em `http://localhost:5000/swagger`.

### Credenciais para autenticação JWT

A aplicação utiliza autenticação baseada em JWT. Para testar os endpoints protegidos, use as seguintes credenciais para gerar o token JWT:
- **Usuário:** `admin`
- **Senha:** `admin123`

Após obter o token JWT, insira-o no Swagger para autenticação:
1. Clique no botão **Authorize** no Swagger.
2. Insira o token no formato `Bearer <seu_token>` (substitua `<seu_token>` pelo token gerado).
3. Clique em **Authorize** para autenticar e testar os endpoints protegidos.

### Excluir os containers

Para parar e remover os containers, execute:
```bash
docker-compose down
```

Isso encerrará os serviços e removerá os containers criados.

---

## Endpoints da API

Abaixo estão os endpoints disponíveis na API, suas funcionalidades e exemplos de uso.

### **Autenticação**

#### POST `/login`
- **Descrição:** Gera um token JWT para autenticação.
- **Requer Autenticação:** Não.
- **Exemplo de Requisição:**
  ```json
  {
    "userName": "admin",
    "password": "admin123"
  }
  ```
- **Exemplo de Resposta:**
  ```json
  {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
  }
  ```

---

### **Categorias**

#### POST `/categorias`
- **Descrição:** Cria uma nova categoria.
- **Requer Autenticação:** Sim.
- **Exemplo de Requisição:**
  ```json
  {
    "nome": "Eletrônicos",
    "descricao": "Produtos eletrônicos em geral"
  }
  ```
- **Exemplo de Resposta:**
  ```json
  {
    "categoriaId": 1,
    "nome": "Eletrônicos",
    "descricao": "Produtos eletrônicos em geral"
  }
  ```

#### GET `/categorias`
- **Descrição:** Retorna todas as categorias.
- **Requer Autenticação:** Sim.
- **Exemplo de Resposta:**
  ```json
  [
    {
      "categoriaId": 1,
      "nome": "Eletrônicos",
      "descricao": "Produtos eletrônicos em geral"
    }
  ]
  ```

#### GET `/categorias/{id}`
- **Descrição:** Retorna uma categoria específica pelo ID.
- **Requer Autenticação:** Sim.
- **Exemplo de Resposta:**
  ```json
  {
    "categoriaId": 1,
    "nome": "Eletrônicos",
    "descricao": "Produtos eletrônicos em geral"
  }
  ```

#### PUT `/categorias/{id}`
- **Descrição:** Atualiza uma categoria existente.
- **Requer Autenticação:** Sim.
- **Exemplo de Requisição:**
  ```json
  {
    "nome": "Eletrônicos Atualizados",
    "descricao": "Descrição atualizada"
  }
  ```

#### DELETE `/categorias/{id}`
- **Descrição:** Remove uma categoria pelo ID.
- **Requer Autenticação:** Sim.

---

### **Produtos**

#### POST `/produtos`
- **Descrição:** Cria um novo produto.
- **Requer Autenticação:** Sim.
- **Exemplo de Requisição:**
  ```json
  {
    "nome": "Smartphone",
    "descricao": "Um smartphone moderno",
    "preco": 1999.99,
    "estoque": 50,
    "categoriaId": 1
  }
  ```

#### GET `/produtos`
- **Descrição:** Retorna todos os produtos.
- **Requer Autenticação:** Sim.

#### GET `/produtos/{id}`
- **Descrição:** Retorna um produto específico pelo ID.
- **Requer Autenticação:** Sim.

#### PUT `/produtos/{id}`
- **Descrição:** Atualiza um produto existente.
- **Requer Autenticação:** Sim.

#### DELETE `/produtos/{id}`
- **Descrição:** Remove um produto pelo ID.
- **Requer Autenticação:** Sim.

#### GET `/produtos/nome/{criterio}`
- **Descrição:** Retorna produtos cujo nome contém o critério especificado.
- **Requer Autenticação:** Sim.

#### GET `/produtosporpagina`
- **Descrição:** Retorna produtos paginados.
- **Requer Autenticação:** Sim.
- **Parâmetros:**
  - `numeroPagina`: Número da página.
  - `tamanhoPagina`: Quantidade de itens por página.

---

## Notas Importantes

- Todas as configurações sensíveis, como a string de conexão com o banco de dados e as informações do JWT, são gerenciadas diretamente no `docker-compose.yml`. Não é necessário alterar o arquivo `appsettings.json`, pois as variáveis de ambiente definidas no `docker-compose.yml` sobrescrevem as configurações padrão.
- Este projeto é apenas para fins educacionais e de aprendizado.