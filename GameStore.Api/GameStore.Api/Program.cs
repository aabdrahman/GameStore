using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using GameStore.Api.Controllers;
using GameStore.Api.Data;
using GameStore.Api.DataTransferObjects;
using GameStore.Api.Endpoints;



var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("localdb");


builder.Services.AddSqlServer<GameStoreContext>(connectionString);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameStore API v1");
    c.RoutePrefix = string.Empty; // Optional: Serve Swagger UI at the root
});



app.RunGameEndpoints();
app.RunGenreEndpoints();
await app.MigrateDataAsync();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
