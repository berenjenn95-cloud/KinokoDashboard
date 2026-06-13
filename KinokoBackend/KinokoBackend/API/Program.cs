using KinokoBackend.Application.Repository;
using Microsoft.EntityFrameworkCore;
using KinokoBackend.Infrastucture.DBContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// 🔥 ESTO TE FALTA
app.UseCors("AllowReact");

app.MapControllers();

app.Run();