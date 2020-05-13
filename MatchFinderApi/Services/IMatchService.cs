using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchFinderApi.Services
{
    public interface IMatchService
    {
        Task<IEnumerable<int>> FindMatchesAsync(string text, string subtext);
    }
}
