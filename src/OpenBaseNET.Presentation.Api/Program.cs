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
app.UseAuthorization();
app.MapControllers();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseMiddleware<ControllerMiddleware>();


await app.RunAsync();