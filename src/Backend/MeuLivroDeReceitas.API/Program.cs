using MeuLivroDeReceitas.API.Filtros;
using MeuLivroDeReceitas.Aplication;
using MeuLivroDeReceitas.Aplication.Servicos.Automapper;
using MeuLivroDeReceitas.Domain.Extension;
using MeuLivroDeReceitas.Infrastructure;
using MeuLivroDeReceitas.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRespositorio(builder.Configuration);
builder.Services.AddAplication(builder.Configuration);

builder.Services.AddMvc(options => options.Filters.Add(typeof(FiltroDasException)));
builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(config =>
{
    config.AddProfile(new AutoMapperConfiguration());
}).CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

AtualizarDataBase();

app.Run();

void AtualizarDataBase()
{
   var Conexao= builder.Configuration.GetConexa();

   var NomeDataBase=builder.Configuration.GetNomeDatabase();

    Database.CriarDatabase(Conexao, NomeDataBase);

    app.MigrateBancodeDados();
}
