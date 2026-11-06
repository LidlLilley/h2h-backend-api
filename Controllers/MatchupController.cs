using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace H2HBackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class MatchupController : ControllerBase
    {
        // Existing controller code...
    }
}