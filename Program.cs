var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var apiKey = builder.Configuration["FootballData:ApiKey"]
             ?? builder.Configuration["FOOTBALL_DATA_API_KEY"]
             ?? "b309935cf77441819c724f47f6d8343e";

builder.Services.AddHttpClient("FootballData", client =>
{
    client.BaseAddress = new Uri("https://api.football-data.org/v4/");
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");
app.MapControllers();

app.Run();