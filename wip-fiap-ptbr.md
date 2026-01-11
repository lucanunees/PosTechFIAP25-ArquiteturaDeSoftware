# Trabalho em Progresso - FIAP Cloud Games

## Lista de Verificação dos Requisitos

### 1. Cadastro de Usuários
- [x] **Identificação do Usuário**: Campos de nome, e-mail e senha estão implementados.
- [x] **Validação de E-mail**: Validação do formato de e-mail está implementada.
- [ ] **Validação de Senha Forte**: Validação de senha com no mínimo 8 caracteres, letras, números e caracteres especiais está pendente.

### 2. Autenticação e Autorização
- [x] **Autenticação JWT**: Implementada.
- [x] **Papéis de Usuário**: Papéis de Usuário e Administrador estão definidos.
- [ ] **Funcionalidades de Administrador**: Funcionalidades de administrador, como criação de promoções, não estão implementadas.

### 3. Biblioteca de Jogos
- [x] **Listar Jogos Adquiridos**: Usuários podem listar seus jogos adquiridos.
- [ ] **Gerenciamento de Jogos pelo Administrador**: Gerenciamento de jogos pelo administrador não está totalmente implementado.

### 4. Arquitetura
- [x] **Arquitetura Monolítica**: O projeto segue uma estrutura monolítica.
- [x] **Entity Framework Core**: Utilizado para persistência de dados.
- [ ] **MongoDB/Dapper Opcionais**: Não implementados.

### 5. Desenvolvimento da API
- [x] **Controllers**: Controllers estão implementados.
- [x] **Middleware**: Middleware para logging está implementado.
- [x] **Documentação Swagger**: Swagger está configurado.
- [ ] **Middleware de Tratamento de Erros**: Middleware global de tratamento de erros não está implementado.
- [ ] **GraphQL Opcional**: Não implementado.

### 6. Garantia de Qualidade
- [ ] **Testes Unitários**: Testes unitários para regras de negócio principais estão ausentes.
- [ ] **TDD/BDD**: Não aplicado a nenhum módulo ainda.

### 7. Princípios de DDD
- [x] **Modelagem de Domínio**: Entidades e repositórios estão estruturados seguindo os princípios de DDD.
- [ ] **Event Storming**: Documentação para Event Storming está ausente.

### 8. Entregáveis
- [ ] **Vídeo Demonstrativo**: Não enviado.
- [ ] **Documentação DDD**: Não enviada.
- [ ] **README Completo**: README está parcialmente completo.
- [ ] **Relatório de Entrega**: Não enviado.

## Erros Detectados

### 1. `ApplicationDbContext` em `FiapCloudGames.Infrastructure`
- **Linha 24**: Possível atribuição de referência nula para `_connectionString`.
- **Linha 15**: Campo não anulável `_connectionString` deve conter um valor não nulo ao sair do construtor.

### 2. `Program.cs` em `FiapCloudGames.API`
- **Linha 81**: Possível argumento de referência nula para `Jwt:Key` em `builder.Configuration`.

---

### Próximos Passos
1. Implementar validação de senha forte.
2. Adicionar funcionalidades de administrador para gerenciamento de jogos e promoções.
3. Desenvolver testes unitários e aplicar TDD/BDD em pelo menos um módulo.
4. Resolver problemas de referência nula em `ApplicationDbContext` e `Program.cs`.
5. Completar funcionalidades opcionais como MongoDB/Dapper e GraphQL.
6. Preparar entregáveis: vídeo, documentação e relatório.