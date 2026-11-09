using Microsoft.AspNetCore.Mvc;

namespace H2HBackendApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchupController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public MatchupController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    [HttpGet("teams")]
    public async Task<IActionResult> GetTeams()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("FootballData");
            var apiKey = _configuration["FootballData:ApiKey"] ?? Environment.GetEnvironmentVariable("FootballData__ApiKey");
            
            if (!string.IsNullOrEmpty(apiKey) && !client.DefaultRequestHeaders.Contains("X-Auth-Token"))
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
            }

            var response = await client.GetAsync("competitions/PL/standings");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, new { error = "Football-Data API error", details = content });
            }

            return Content(content, "application/json");
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}