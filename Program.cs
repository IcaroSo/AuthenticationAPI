using Microsoft.EntityFrameworkCore;
using AuthenticationAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuthDatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
