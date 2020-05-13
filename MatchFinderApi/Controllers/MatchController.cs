using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchFinderApi.Models;
using MatchFinderApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchFinderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        /// <summary>
        /// Finds occurrences of a search term within a provided text.
        /// </summary>
        /// <param name="request">Query to execute; consists of a main text and search term</param>
        /// <returns>Summary of any found matches</returns>
        [HttpPost]
        public async Task<ActionResult<MatchResponse>> FindMatches(MatchRequest request)
        {
            var matches = await _matchService.FindMatchesAsync(request.Text, request.Subtext);
            return new MatchResponse { Text = request.Text, Subtext = request.Subtext, Matches = matches.ToArray() };
        }
    }
}
