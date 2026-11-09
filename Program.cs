var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Read API key safely from environment variables (Render uses double underscores)
var apiKey = builder.Configuration["FootballData:ApiKey"] ?? Environment.GetEnvironmentVariable("FootballData__ApiKey");

builder.Services.AddHttpClient("FootballData", client =>
{
    client.BaseAddress = new Uri("https://api.football-data.org/v4/");
    if (!string.IsNullOrEmpty(apiKey))
    {
        client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
    }
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins(
                            "http://localhost:4200",
                            "https://h2h-angular-demo.vercel.app"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowAngular");
app.MapControllers();

app.Run();