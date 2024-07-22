using Microsoft.EntityFrameworkCore;
using ZenXKanCore.Configurations;
using ZenXKanCore.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ZenXKanContext>(options =>
{
    var dbInitializer = new DatabaseInitializer();
    var dbPath = dbInitializer.InitializeDatabase();

    options.UseSqlite($"Data Source={dbPath}");
});


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();