var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddHttpClient("FootballData", client =>
{
    client.BaseAddress = new Uri("https://api.football-data.org/v4/");
    var apiKey = builder.Configuration["FootballData:ApiKey"];
    client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
});

// Configure CORS for Angular (localhost:4200)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowAngular");
app.MapControllers();

app.Run();