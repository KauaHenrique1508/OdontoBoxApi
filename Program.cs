using OdontoBoxApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar Controllers (obrigatório)
builder.Services.AddControllers();

// Registrar EF Core + MySQL
builder.Services.AddDbContext<OdontoBoxContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

var app = builder.Build();

// HTTPS
app.UseHttpsRedirection();

// Mapeia os Controllers
app.MapControllers();

app.Run();
