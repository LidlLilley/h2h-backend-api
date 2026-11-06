using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace H2HBackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class MatchupController : ControllerBase
    {
        [HttpGet("teams")]
        public IActionResult GetTeams()
        {
            var teams = new[]
            {
                new { id = "ARS", name = "Arsenal", logo = "https://resources.premierleague.com/premierleague/badges/70/t3.png" },
                new { id = "AVL", name = "Aston Villa", logo = "https://resources.premierleague.com/premierleague/badges/70/t7.png" },
                new { id = "BOU", name = "Bournemouth", logo = "https://resources.premierleague.com/premierleague/badges/70/t91.png" },
                new { id = "BRE", name = "Brentford", logo = "https://resources.premierleague.com/premierleague/badges/70/t94.png" },
                new { id = "BHA", name = "Brighton & Hove Albion", logo = "https://resources.premierleague.com/premierleague/badges/70/t36.png" },
                new { id = "CHE", name = "Chelsea", logo = "https://resources.premierleague.com/premierleague/badges/70/t8.png" },
                new { id = "CRY", name = "Crystal Palace", logo = "https://resources.premierleague.com/premierleague/badges/70/t92.png" },
                new { id = "EVE", name = "Everton", logo = "https://resources.premierleague.com/premierleague/badges/70/t11.png" },
                new { id = "FUL", name = "Fulham", logo = "https://resources.premierleague.com/premierleague/badges/70/t54.png" },
                new { id = "IPS", name = "Ipswich Town", logo = "https://resources.premierleague.com/premierleague/badges/70/t40.png" },
                new { id = "LEI", name = "Leicester City", logo = "https://resources.premierleague.com/premierleague/badges/70/t13.png" },
                new { id = "LIV", name = "Liverpool", logo = "https://resources.premierleague.com/premierleague/badges/70/t14.png" },
                new { id = "MCI", name = "Manchester City", logo = "https://resources.premierleague.com/premierleague/badges/70/t43.png" },
                new { id = "MUN", name = "Manchester United", logo = "https://resources.premierleague.com/premierleague/badges/70/t1.png" },
                new { id = "NEW", name = "Newcastle United", logo = "https://resources.premierleague.com/premierleague/badges/70/t4.png" },
                new { id = "NFO", name = "Nottingham Forest", logo = "https://resources.premierleague.com/premierleague/badges/70/t17.png" },
                new { id = "SOU", name = "Southampton", logo = "https://resources.premierleague.com/premierleague/badges/70/t20.png" },
                new { id = "TOT", name = "Tottenham Hotspur", logo = "https://h2h-angular-demo.vercel.app/assets/spurs-white.png" },
                new { id = "WHU", name = "West Ham United", logo = "https://resources.premierleague.com/premierleague/badges/70/t21.png" },
                new { id = "WOL", name = "Wolverhampton Wanderers", logo = "https://resources.premierleague.com/premierleague/badges/70/t39.png" }
            };

            return Ok(teams);
        }
    }
}