using AlunosApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//acesso ao banco de dados
builder.Services.AddDbContext<Context>(options =>
   options.UseSqlite(builder.Configuration.GetConnectionString("conexaobancodados")));


var app = builder.Build();

 //Repository

   //builder.Services.AddSingleton<IRepository, Repository>(); // é ultilizado em todas as instacias assim tendo que compartilar a mesma memoria
//builder.Services.AddTransient<IRepository, Repository>(); // nunca vai ultilizar a mesma instancias para cada item

// builder.Services.AddScoped<IRepository, Repository>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
