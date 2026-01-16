
# 🎮 FIAP Cloud Games – Fase 1
### 📘 Plataforma de Cadastro de Usuários e Biblioteca de Jogos
**API REST em .NET 8 • Monolito • JWT • DDD • EF Core • Testes**

## 📌 Sobre o Projeto
Este repositório contém a implementação da Fase 1 do Tech Challenge — FIAP Cloud Games (FCG).  
A FIAP Cloud Games (FCG) será uma plataforma de venda de jogos
digitais e gestão de servidores para partidas online.
Nesta etapa, desenvolvemos um serviço de cadastro e autenticação de usuários e uma biblioteca de jogos adquiridos.
Event Storming: https://miro.com/welcomeonboard/K2dtdEFXQmZjUmFXRTFoMmJpMnhlbVBjQ0svcHdWT2lUbW41YURuUEFEU2VwbmdSK1BxZVA4MkdZV2NzNEg3MHdVM00xb0lXcWNtS1hlOER0RnczMjlLTDgzS2thK2FIQnBJQkRleitOSGNpUncyYXlTSGJCaVhWYm9WanBKblVyVmtkMG5hNDA3dVlncnBvRVB2ZXBnPT0hdjE=?share_link_id=230301566427
## 🧠 Objetivos da Fase 1
- Criar uma API REST em .NET 8.
- Garantir persistência de dados, segurança e qualidade de software.
- Implementar boas práticas como DDD, TDD/BDD e documentação.

## 🚀 Funcionalidades
### Cadastro de Usuários
- Nome, e-mail e senha.
- Validação de e-mail e senha forte.

### Autenticação e Autorização
- JWT.
- Perfis: Usuário e Administrador.

### Biblioteca de Jogos
- Listar jogos adquiridos.
- Administração via perfil Admin.

## 🏛 Arquitetura
- Monolito (MVP).
- DDD.
- Documentação via Event Storming.

## 🗄 Persistência
- Entity Framework Core.
- Migrations.
- (Opcional) MongoDB / Dapper. (precisa ser discutido)

## 🛠 API
- .NET 8.
- Minimal API ou Controllers.
- Middlewares.
- Swagger.

## 🧪 Testes
- Testes unitários.
- TDD ou BDD em ao menos um módulo. (precisa ser discutido)

## ▶️ Executar o Projeto

```bash
dotnet restore
dotnet ef database update
dotnet run --project src/.../FCG.WebApi
```

Swagger disponível em:
```
http://localhost:5200/swagger
```

## 📦 Entregáveis
- API completa.
- Testes.
- Documentação DDD.
- Vídeo de demonstração.
- Relatório de entrega.  
