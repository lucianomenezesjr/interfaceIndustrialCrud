
using Microsoft.EntityFrameworkCore;
using interfaceIndustrialApi.Data;
using interfaceIndustrialApi.Repositories;
using interfaceIndustrialApi.Repositories.Interfaces;
using interfaceIndustrialApi.Services;
using interfaceIndustrialApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Configurar CORS para liberar o frontend Next.js
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
    );
});


// Configurar DbContext para PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection") ??
        "Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=postgres"
    ));

// Registrar repositórios e serviços
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// Device / Sensor / Actuator / SensorData registrations
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<IActuatorRepository, ActuatorRepository>();
builder.Services.AddScoped<ISensorDataRepository, SensorDataRepository>();

builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<ISensorService, SensorService>();
builder.Services.AddScoped<IActuatorService, ActuatorService>();
builder.Services.AddScoped<ISensorDataService, SensorDataService>();

// Adicionar controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"] ?? "super_secret_key_123!";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "interfaceIndustrialApi";
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});
builder.Services.AddAuthorization();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar CORS antes de autenticação
app.UseCors("AllowFrontend");


app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
