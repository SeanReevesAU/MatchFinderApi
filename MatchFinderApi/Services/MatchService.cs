using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchFinderApi.Services
{
    public class MatchService : IMatchService
    {
        public async Task<IEnumerable<int>> FindMatchesAsync(string text, string subtext)
        {
            var matches = new List<int>();
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(subtext))
            {
                // return empty list
                return await Task.FromResult(matches);
            }

            
            
            var match = text.ToLower().IndexOf(subtext.ToLower());
            while (match != -1)
            {
                matches.Add(match);
                match = text.ToLower().IndexOf(subtext.ToLower(), (matches.Last() + 1));
            }

            return await Task.FromResult(matches);
        }
    }
}
