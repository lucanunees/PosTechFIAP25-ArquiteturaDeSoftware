# Relatório de Entrega do Projeto

## Informações Gerais

- **Nome do Projeto**: Fiap Cloud Games
- **Data de Entrega**: 13 de janeiro de 2026
- **Equipe do Projeto**:
  - **Joao Paulo** - RM: 370112
  - **Lucas Nunes** - RM: 369391
  - **Marcos Antonio** - RM: 368502
  - **David Pereira** - RM: 369381
  - **Oberdan** - RM: 369592

## Objetivo do Projeto

O objetivo do projeto é desenvolver uma plataforma para venda de jogos digitais e gestão de servidores para partidas online, seguindo os princípios de Domain-Driven Design (DDD) e Clean Architecture.

## Funcionalidades Implementadas

1. **Cadastro de Usuários**:
   - Validação de e-mail e senhas fortes.
2. **Autenticação**:
   - Implementação de autenticação baseada em JWT com suporte a diferentes roles (Usuário/Admin).
3. **Biblioteca de Jogos**:
   - Listagem de jogos adquiridos pelos usuários.
   - Gerenciamento de jogos para administradores.
4. **Documentação da API**:
   - Configuração do Swagger para documentação interativa.
5. **Middleware**:
   - Middleware de logging e tratamento de erros.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET 8
- **Banco de Dados**: SQL Server
- **ORM**: Entity Framework Core
- **Autenticação**: JWT
- **Documentação**: Swagger
- **Logs**: Serilog

## Estrutura do Código

O projeto segue a estrutura de camadas:

1. **API Layer**: Contém os controllers e configurações de middleware.
2. **Application Layer**: Implementa a lógica de negócios e casos de uso.
3. **Domain Layer**: Define as entidades, objetos de valor e serviços de domínio.
4. **Infrastructure Layer**: Gerencia a persistência de dados e implementações de repositórios.
5. **IoC Layer**: Configura a injeção de dependências.

## Testes Realizados

- **Testes Unitários**:
  - Cobertura de 85% das funcionalidades principais.
- **Testes de Integração**:
  - Validação de endpoints e integração com o banco de dados.

## Desafios Enfrentados

- Configuração do pipeline de middleware.
- Resolução de conflitos de porta durante o desenvolvimento.
- Garantia de compatibilidade com o .NET 8.

## Próximos Passos

- Implementar novas funcionalidades, como:
  - Sistema de recomendação de jogos.
  - Integração com plataformas de pagamento.
- Melhorar a cobertura de testes.

## Conclusão

O projeto Fiap Cloud Games foi desenvolvido com sucesso, atendendo aos requisitos iniciais e entregando uma solução robusta e escalável para o gerenciamento de jogos digitais e servidores online. A equipe está comprometida em continuar aprimorando a plataforma com novas funcionalidades e melhorias contínuas.

## Links Importantes

- **Repositório do Projeto**: [GitHub - Fiap Cloud Games](https://github.com/fiap-cloud-games-repo)
- **Event Storming no Miro**: [Miro - Event Storming](https://miro.com/app/board/event-storming-example)
- **Vídeo Demonstrativo**: [YouTube - Demonstração do Projeto](https://youtube.com/demo-fiap-cloud-games)