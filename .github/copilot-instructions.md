# GitHub Copilot Instructions for Fiap Cloud Games

## Project Overview
Fiap Cloud Games is a monolithic application built using .NET 8, following Domain-Driven Design (DDD) principles. The project includes an API for user registration, authentication, and managing a library of purchased games. Key features include:

- **User Registration**: Validates email and strong passwords.
- **Authentication**: Implements JWT-based authentication with user roles (User/Admin).
- **Game Library**: Allows users to list purchased games and provides admin-level management.

## Codebase Structure
The project is organized into the following layers:

1. **API Layer** (`src/FiapCloudGames.API`):
   - Contains controllers for handling HTTP requests.
   - Includes middleware for logging and other cross-cutting concerns.

2. **Application Layer** (`src/FiapCloudGames.Application`):
   - Implements business logic and use cases.

3. **Domain Layer** (`src/FiapCloudGames.Domain`):
   - Defines core entities, value objects, and domain services.
   - Includes interfaces for repositories.

4. **Infrastructure Layer** (`src/FiapCloudGames.Infrastructure`):
   - Handles data persistence using Entity Framework Core.
   - Contains migrations and repository implementations.

5. **IoC Layer** (`src/FiapCloudGames.IoC`):
   - Configures dependency injection.

## Development Guidelines

### General Conventions
- Follow Clean Architecture principles.
- Use DDD concepts for structuring code.
- Write unit tests for all new features.
- Document code with XML comments where applicable.

### Workflow
1. **Branching**: Create feature branches for new functionality.
2. **Commits**: Write clear and concise commit messages.
3. **Pull Requests**: Ensure all PRs are reviewed and approved before merging.

### Running the Project
1. Restore dependencies:
   ```bash
   dotnet restore
   ```
2. Apply migrations:
   ```bash
   dotnet ef database update
   ```
3. Run the API:
   ```bash
   dotnet run --project src/FiapCloudGames.API
   ```
4. Access Swagger at:
   ```
   http://localhost:5200/swagger
   ```

## AI Agent Instructions

### Purpose
This file provides guidance for AI agents to:
- Navigate the codebase effectively.
- Assist with development tasks.
- Follow project conventions.

### Key Files
- **Controllers**: Located in `src/FiapCloudGames.API/Controllers`.
- **Entities**: Defined in `src/FiapCloudGames.Domain/Entity`.
- **Repositories**: Interfaces in `src/FiapCloudGames.Domain/Repository` and implementations in `src/FiapCloudGames.Infrastructure/Repository`.
- **Migrations**: Found in `src/FiapCloudGames.Infrastructure/Migrations`.

### Tasks for AI Agents
- **Code Generation**: Follow the layer structure and adhere to DDD principles.
- **Bug Fixes**: Analyze and resolve issues while maintaining architectural integrity.
- **Documentation**: Update XML comments and markdown files as needed.
- **Testing**: Write unit tests in alignment with TDD/BDD practices.

### Limitations
- Avoid modifying files in the `obj/` or `bin/` directories.
- Do not make changes to migration files unless explicitly instructed.

## Additional Resources
- [DDD Reference](https://domainlanguage.com/ddd/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/)
- [Swagger Documentation](https://swagger.io/docs/)

---

For further assistance, refer to the `README.md` or contact the project maintainers.