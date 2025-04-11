using Sinqia.CalculadoraSQIA.Application.Extensions;
using Sinqia.CalculadoraSQIA.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Contexto;
using Sinqia.CalculadoraSQIA.Infrastructure.Persistencia.Seed;

var builder = WebApplication.CreateBuilder(args);
var dbConnectionString = builder.Configuration.GetConnectionString("DBConnection");

builder.Services.AddDbContext<CalculadoraDbContext>(options =>
{
    options.UseSqlServer(dbConnectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureRepositories();
builder.Services.AddApplicationServices();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CalculadoraDbContext>();
    context.Database.Migrate();
    DbInitializer.Seed(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
