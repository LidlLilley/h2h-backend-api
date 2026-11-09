using Microsoft.AspNetCore.Mvc;

namespace H2HBackendApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchupController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MatchupController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("teams")]
    public async Task<IActionResult> GetTeams()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("FootballData");
            
            // PL = Premier League (available on free Tier)
            var response = await client.GetAsync("competitions/PL/standings");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, new { error = "Failed to fetch data from Football-Data.org" });
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return Content(jsonString, "application/json");
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}