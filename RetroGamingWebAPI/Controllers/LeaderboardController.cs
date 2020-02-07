using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;
using RetroGamingWebAPI.Infrastructure;
using RetroGamingWebAPI.Models;

namespace RetroGamingWebAPI.Controllers
{
    [OpenApiTag("Leaderboard", Description = "API to retrieve high score leaderboard")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        private readonly RetroGamingContext context;

        public LeaderboardController(RetroGamingContext context)
        {
            this.context = context;
        }

        // GET api/leaderboard
        /// <summary>
        /// Retrieve a list of leaderboard scores.
        /// </summary>
        /// <returns>List of high scores per game.</returns>
        /// <response code="200">The list was successfully retrieved.</response>
        [ProducesResponseType(typeof(IEnumerable<Highscore>), 200)]
        [Produces("application/json", "application/xml")] //specify allowed return data
        [HttpGet("{format?}")] //accepts a format to use
        [FormatFilter]
        public async Task<ActionResult<IEnumerable<Highscore>>> Get()
        {
            var scores = context.Scores
               .Select(score => new Highscore()
               {
                   Game = score.Game,
                   Points = score.Points,
                   Nickname = score.Gamer.Nickname
               });

            return Ok(await scores.ToListAsync().ConfigureAwait(false));
        }
    }
}