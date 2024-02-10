using System.Reflection;
using Microsoft.OpenApi.Models;
using SortedExam;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient("RainfallApi", client => client.BaseAddress = new Uri("http://environment.data.gov.uk/flood-monitoring/"));
builder.Services.AddSwaggerService();
builder.Services.AddRainfallService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
