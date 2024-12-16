using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using AuthenticationAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext para usar PostgreSQL a partir do appsettings.json
builder.Services.AddDbContext<AuthDatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AuthDatabaseContext>();

    try
    {
        if (context.Database.CanConnect())
        {
            Console.WriteLine("Conexão com o banco de dados foi bem-sucedida.");
            context.Database.Migrate();  // Aplica migrações pendentes
        }
        else
        {
            Console.WriteLine("Não foi possível conectar ao banco de dados.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
