# AuthenticationAPI

API REST simples para autenticação (registro & login) construída com ASP.NET Core (.NET 8).

Principais arquivos
- Projeto: [AuthenticationAPI.csproj](AuthenticationAPI.csproj)  
- Entrada da aplicação: [`AuthenticationAPI.Program`](Program.cs) — [Program.cs](Program.cs)  
- Controllers:
  - [`AuthenticationAPI.Controllers.RegisterController`](Controllers/RegisterController.cs) — [Controllers/RegisterController.cs](Controllers/RegisterController.cs)
  - [`AuthenticationAPI.Controllers.LoginController`](Controllers/LoginController.cs) — [Controllers/LoginController.cs](Controllers/LoginController.cs)
- Models / EF Core:
  - [`AuthenticationAPI.Models.AuthDatabaseContext`](Models/AuthDatabaseContext.cs) — [Models/AuthDatabaseContext.cs](Models/AuthDatabaseContext.cs)
  - [`AuthenticationAPI.Models.User`](Models/User.cs) — [Models/User.cs](Models/User.cs)
  - [`AuthenticationAPI.Models.LoginRequest`](Models/LoginRequest.cs) — [Models/LoginRequest.cs](Models/LoginRequest.cs)
- Migrations: [Migrations/20241217135628_updateUser.cs](Migrations/20241217135628_updateUser.cs), [Migrations/AuthDatabaseContextModelSnapshot.cs](Migrations/AuthDatabaseContextModelSnapshot.cs)
- Assets estáticos: [wwwroot/js/site.js](wwwroot/js/site.js), bibliotecas em [wwwroot/lib](wwwroot/lib)

Descrição
Esta API expõe endpoints para:
- Registrar novo usuário (hash de senha com BCrypt)
- Autenticar usuário (verificar credenciais)

Dependências principais (definidas em [AuthenticationAPI.csproj](AuthenticationAPI.csproj))
- BCrypt.Net-Next
- Microsoft.EntityFrameworkCore (EF Core)
- Npgsql.EntityFrameworkCore.PostgreSQL (Postgres provider)

Configuração
- Ajuste a string de conexão e outras configurações em [appsettings.json](appsettings.json) ou [appsettings.Development.json](appsettings.Development.json).

Como executar (local)
1. Restaurar e compilar:
   ```bash
   dotnet restore
   dotnet build
   ```
2. Aplicar migrations (requer dotnet-ef):
   ```bash
   dotnet tool install --global dotnet-ef # se necessário
   dotnet ef database update
   ```
3. Executar:
   ```bash
   dotnet run
   ```
A aplicação iniciará conforme configuração em [`AuthenticationAPI.Program`](Program.cs).

Endpoints (exemplos)
- POST /api/register — controller: [`AuthenticationAPI.Controllers.RegisterController`](Controllers/RegisterController.cs)
- POST /api/login — controller: [`AuthenticationAPI.Controllers.LoginController`](Controllers/LoginController.cs)

Contribuição
- Abra uma issue ou envie pull request.
- Mantenha o padrão de codificação do projeto e adicione testes quando possível.

Observações
- Verifique as migrations em [Migrations/](Migrations/) antes de aplicar em produção.
- Os arquivos de assets gerados ficam em `obj/` e `bin/` (não versionar).

