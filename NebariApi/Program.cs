using Microsoft.EntityFrameworkCore;
using NebariApi.Services;
using NebariApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tree.db"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ITreeService, TreeService>();

var app = builder.Build();

// app.UseHttpsRedirection();
app.MapControllers(); // ← Magic line: enables all controllers

app.Run();
    