using Microsoft.EntityFrameworkCore;
using TeamsAPI.DAL;
using TeamsAPI.Repositories;
using TeamsAPI.Repositories.Interfaces;
using TeamsAPI.Services.Interfaces;
using TeamsAPI.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;
// Add services
builder.Services.AddControllers();
//Configure scoped services
builder.Services.AddScoped<ITeamsRepo, TeamsRepo>();
builder.Services.AddScoped<ITeamsService, TeamsService>();
builder.Services.AddScoped<IPlayersRepo, PlayersRepo>();
builder.Services.AddScoped<IPlayersService, PlayersService>();

//SQL Server Express. I like to debug with this.
builder.Services.AddDbContext<Context>(option => option.UseSqlServer(config.GetConnectionString("Database")));

//In Memory
//builder.Services.AddDbContext<Context>(option => option.UseInMemoryDatabase("TeamsDB"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
