/*
 * Name: Program
 * Author: Rodrigo Brito <rodrigo@w3ti.com.br>
 * Type: Script
 * Create At:   10/25/2025
 * Last Update: 10/25/2025
 * Description:
 *      Execução do programa
 * Versions:
 * |--------------------------------------------------------------|
 * | Date           | Description                                 |
 * | 10/25/2025     | Criação do Programa                         |
 * |--------------------------------------------------------------|
 */


using OpenBaseNET.Infra.CrossCutting;
using System.Reflection;
using OpenBaseNet.Web.Components.Package.Middlewares;

Console.WriteLine("Starting Project...");
Console.WriteLine($"Version {Assembly.GetEntryAssembly()?.GetName().Version}");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseMiddleware<ControllerMiddleware>();


await app.RunAsync();