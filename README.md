# ASP.NET Services Architecture (Academic Project) / Arquitetura de Serviços em ASP.NET (Projeto Acadêmico)

## PT-BR — Visão geral
Projeto acadêmico de microsserviços em C#/.NET com APIs REST, organizado por serviços (Aluno/Professor/Secretaria) e banco PostgreSQL em Docker. O objetivo é praticar arquitetura em camadas, contratos de API e execução local.

> Projeto acadêmico (não produção). Credenciais/portas são de desenvolvimento local.

## EN — Overview
Academic microservices project in C#/.NET with REST APIs, split into services (Aluno/Professor/Secretaria) and a PostgreSQL database running on Docker. The goal is to practice layered architecture, API contracts, and local execution.

> Academic project (not production). Credentials/ports are for local development.

---

## Serviços e portas (Swagger) / Services and ports (Swagger)

### Aluno
- HTTP:  http://localhost:5127/swagger
- HTTPS: https://localhost:7109/swagger

### Professor
- HTTP:  http://localhost:5275/swagger
- HTTPS: https://localhost:7039/swagger

### Secretaria
- HTTP:  http://localhost:5032/swagger
- HTTPS: https://localhost:7064/swagger

> Dica: os serviços com `launchUrl: "swagger"` abrem direto no Swagger quando `launchBrowser: true`. (Microsoft docs)  

---

## Banco de dados (PostgreSQL via Docker) / Database (PostgreSQL via Docker)

### Build da imagem (opcional) / Build image (optional)
Dentro de `Docker-DB/`:

- docker build -t renatonhack/pb-db .

O Dockerfile usa:
- POSTGRES_USER=postgres
- POSTGRES_PASSWORD=123456
- POSTGRES_DB=projeto_bloco
e copia `projeto_bloco_db.sql` para inicialização automática.

### Rodando o container / Running the container
- docker run --name pb-db -e POSTGRES_PASSWORD=123456 -d -p 5432:5432 renatonhack/pb-db

### Verificando se subiu / Checking it is up
Dentro do container:
- docker exec -it pb-db psql -U postgres projeto_bloco

No host:
- psql -h localhost -p 5432 -U postgres projeto_bloco

### Limpando / Cleanup
- docker stop -t=0 pb-db
- docker rm pb-db

---

## Como rodar os serviços / Running the services

### Opção A: Visual Studio
Abra a solution/projeto dentro de cada pasta:
- Sistema.Aluno
- Sistema.Professor
- Sistema.Secretaria

Execute (F5) e abra o `/swagger` na porta correspondente.

### Opção B: CLI (dotnet)
Dentro da pasta do serviço (onde está o `.csproj`):
- dotnet restore
- dotnet build
- dotnet run

Se houver mais de um projeto na pasta:
- dotnet run --project ./CAMINHO/Projeto.csproj

---

## Configuração / Configuration
Se algum serviço não conectar no banco:
- confira `ConnectionStrings` no `appsettings.json`
- valide host/porta do Postgres (localhost:5432), usuário `postgres`, senha `123456`, db `projeto_bloco`

---

## Como confirmar Swagger / How to confirm Swagger
Rode o serviço e abra:
- `http://localhost:<porta>/swagger` (UI)  
- `http://localhost:<porta>/swagger/v1/swagger.json` (OpenAPI JSON)

(Microsoft docs)  
