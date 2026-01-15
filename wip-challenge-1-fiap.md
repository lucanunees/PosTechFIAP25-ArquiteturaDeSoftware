# Trabalho em Progresso - FIAP Cloud Games

## ✅ Progresso Geral: 75% Concluído

## 📋 Lista de Verificação dos Requisitos (Atualizado)

### 1. Cadastro de Usuários ✅ **100% Completo**

- [x] **Identificação do Usuário**: Campos de nome, e-mail e senha estão implementados.
- [x] **Validação de E-mail**: Validação do formato de e-mail está implementada usando `[EmailAddress]`.
- [x] **Validação de Senha Forte**: Implementada com `RegularExpression` - mínimo 8 caracteres, letras, números e caracteres especiais (`@$!%*?&`).

### 2. Autenticação e Autorização ✅ **100% Completo**

- [x] **Autenticação JWT**: Implementada com geração de tokens e validação.
- [x] **Papéis de Usuário**: Papéis de Usuário e Administrador estão definidos (UserRoleEnum).
- [x] **Autorização por Perfil**: Políticas de autorização configuradas (ex: "Admin" policy).
- [x] **Login com Verificação de Senha**: Sistema de login com hash de senha implementado (PasswordHasher).
- [x] **Funcionalidades de Administrador**: Funcionalidades específicas de administrador, como criação de promoções, estão implementadas no `PromotionController`.

### 3. Biblioteca de Jogos ✅ **85% Completo**

- [x] **Listar Jogos**: Usuários podem listar jogos através da API.
- [x] **CRUD de Jogos**: Controllers implementados para Games e Categories.
- [x] **Buscar Jogo por ID**: Endpoint GetById implementado.
- [x] **Gerenciamento de Jogos pelo Administrador**: Funcionalidades avançadas de administração (ex: promoções, descontos) estão parcialmente implementadas.

### 4. Arquitetura ✅ **100% Completo**

- [x] **Arquitetura Monolítica**: O projeto segue uma estrutura monolítica bem organizada.
- [x] **Entity Framework Core**: Utilizado para persistência de dados com migrations.
- [x] **Migrations Aplicadas**: Migrations para criar as tabelas Customer, Games, Order, Category e AcessUser.
- [x] **Separação de Camadas**: API, Application, Domain, Infrastructure e IoC bem definidas.
- [ ] **MongoDB/Dapper Opcionais**: Não implementados (opcional).

### 5. Desenvolvimento da API ✅ **85% Completo**

- [x] **Controllers MVC**: Controllers implementados (AcessUser, Games, Category, Authenticate, Secure, Promotion).
- [x] **Middleware**: LogMiddleware implementado.
- [x] **Documentação Swagger**: Swagger configurado com informações detalhadas do projeto e equipe.
- [x] **ReDoc**: Documentação alternativa com ReDoc implementada.
- [x] **Validação de Input**: Data Annotations implementadas nos modelos de entrada.
- [ ] **Middleware de Tratamento de Erros Global**: Middleware usando `UseExceptionHandler` não está implementado.
- [ ] **GraphQL Opcional**: Não implementado (opcional).

### 6. Garantia de Qualidade ✅ **60% Completo**

- [x] **Testes Unitários**: Testes unitários para `AcessUserService` implementados usando xUnit, Moq e FluentAssertions.
- [x] **Cobertura de Cenários**: Testes para GetAllUsers, GetUserById, CreateAcessUser (sucesso e erro).
- [x] **Frameworks de Teste**: xUnit, Moq, FluentAssertions e Coverlet configurados.
- [ ] **TDD/BDD em Mais Módulos**: Necessário aplicar em outros módulos (Games, Categories, Orders).
- [ ] **Testes de Integração**: Não implementados ainda.

### 7. Princípios de DDD ✅ **100% Completo**

- [x] **Modelagem de Domínio**: Entidades (Customer, Games, Order, Category, AcessUser) e repositórios bem estruturados.
- [x] **Separação de Responsabilidades**: Domain separado de Infrastructure.
- [x] **Value Objects e Enums**: UserRoleEnum implementado.
- [x] **Event Storming**: Documentação completa disponível no Miro: [Event Storming no Miro](https://miro.com/app/board/uXjVGVQctho=/).

### 8. Entregáveis ⚠️ **90% Completo**

- [x] **Código-Fonte**: Repositório com código completo e estruturado. [GitHub - Fiap Cloud Games](https://github.com/fiap-cloud-games-repo).
- [x] **Documentação DDD**: Event Storming disponível no Miro: [Event Storming no Miro](https://miro.com/app/board/uXjVGVQctho=/).
- [x] **README Completo**: README atualizado com instruções detalhadas de execução.
- [ ] **Vídeo Demonstrativo**: Não enviado (máximo 15 minutos).
- [ ] **Relatório de Entrega**: 90% completo - falta adicionar o link do vídeo demonstrativo.

---

## 🎯 Próximos Passos Prioritários

### Alta Prioridade 🔴

1. **Completar README.md** com instruções detalhadas de instalação e execução.
2. **Gravar Vídeo Demonstrativo** (máximo 15 minutos) mostrando:
   - Cadastro de usuário com validação.
   - Login e geração de token JWT.
   - Listagem de jogos.
   - Swagger funcionando.
3. **Preparar Relatório de Entrega** (PDF/TXT) com:
   - Nome do grupo e RMs dos participantes.
   - Link do repositório.
   - Link do Event Storming no Miro.
   - Link do vídeo demonstrativo.

### Média Prioridade 🟡

4. **Resolver Warnings de Referência Nula** em ApplicationDbContext e Program.cs.
5. **Implementar Middleware de Tratamento de Erros Global** usando `UseExceptionHandler`.
6. **Expandir Testes Unitários** para outros módulos (Games, Categories).
7. **Adicionar Funcionalidades de Administrador** (promoções, descontos).

### Baixa Prioridade 🟢 (Opcionais)

8. Implementar MongoDB ou Dapper (opcional).
9. Implementar GraphQL (opcional).
10. Adicionar testes de integração.

---

**Última Atualização**: 15 de janeiro de 2026.