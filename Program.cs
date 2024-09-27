using Microsoft.EntityFrameworkCore;
using MinimalApi.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DbContexto>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Mama minha piroca mole e pequena");


app.MapPost("/login", (MinimalApi.DTOs.LoginDTO loginDTO) => {
    if (loginDTO.Email== "adm@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login com sucesso");
    else 
        return Results.Unauthorized();
});

app.Run();

