using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Gamearr.Http.REST;

namespace Gamearr.Api.V3.Games
{
    [ApiController]
    [Route("api/v3/game/lookup")]
    public class GameLookupController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<GameResource>> Search([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Ok(new List<GameResource>());
            }

            // Results from IGDB / Steam metadata providers
            var results = new List<GameResource>();
            return Ok(results);
        }

        [HttpGet("igdb/{igdbId:int}")]
        public ActionResult<GameResource> GetByIgdb(int igdbId)
        {
            return NotFound();
        }

        [HttpGet("steam/{steamAppId:int}")]
        public ActionResult<GameResource> GetBySteam(int steamAppId)
        {
            return NotFound();
        }
    }
}
