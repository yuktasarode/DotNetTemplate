var builder = WebApplication.CreateBuilder(args);

// Add controller support
builder.Services.AddControllers();

// Allow frontend calls (CORS)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register your services
builder.Services.AddScoped<IPlayerService, PlayerService>();

var app = builder.Build();

// Middleware
app.UseCors("AllowFrontend");

app.UseAuthorization();

// Map controllers
app.MapControllers();

app.Run();