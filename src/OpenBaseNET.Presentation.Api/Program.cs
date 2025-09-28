using OpenBaseNET.Infra.CrossCutting;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OpenBaseNet.Web.Components.Package.Middlewares;
using Microsoft.OpenApi.Models; // << Adicionado para o Swagger/JWT

Console.WriteLine("Starting Project...");
Console.WriteLine($"Version {Assembly.GetEntryAssembly()?.GetName().Version}");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    // 1. Definição do Esquema de Segurança (JWT Bearer)
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT no formato: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer" // Padrão JWT
    });

    // 2. Requisito de Segurança
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});


builder.Services.AddApplicationServices(builder.Configuration);

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new NullReferenceException("A chave JWT (Jwt:Key) não pode ser nula."));

// Configuração de Autenticação JWT (MANTIDA)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true; 
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"]
    };
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // MANTIDA
app.UseAuthorization();  // MANTIDA
app.MapControllers();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>(); // MANTIDA
app.UseMiddleware<ControllerMiddleware>();             // MANTIDA


await app.RunAsync();