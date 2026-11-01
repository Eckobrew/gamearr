using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NzbDrone.Core.Games;
using Gamearr.Http.REST;

namespace Gamearr.Api.V3.Games
{
    [ApiController]
    [Route("api/v3/game")]
    public class GameController : RestController<GameResource>
    {
        public GameController()
        {
        }

        [HttpGet]
        public ActionResult<List<GameResource>> GetAllGames()
        {
            // Returns the games in the library
            return Ok(new List<GameResource>());
        }

        [HttpGet("{id:int}")]
        public ActionResult<GameResource> GetGameById(int id)
        {
            return NotFound();
        }

        [HttpPost]
        public ActionResult<GameResource> AddGame([FromBody] GameResource resource)
        {
            if (resource == null)
            {
                return BadRequest("Game resource cannot be null");
            }

            return Created($"/api/v3/game/{resource.Id}", resource);
        }

        [HttpPut("{id:int}")]
        public ActionResult<GameResource> UpdateGame(int id, [FromBody] GameResource resource)
        {
            if (resource == null)
            {
                return BadRequest();
            }

            return Ok(resource);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteGame(int id, [FromQuery] bool deleteFiles = false)
        {
            return NoContent();
        }
    }
}
