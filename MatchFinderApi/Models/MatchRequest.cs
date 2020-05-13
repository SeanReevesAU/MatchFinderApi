using System.ComponentModel.DataAnnotations;

namespace MatchFinderApi.Models
{
    public class MatchRequest
    {
        /// <summary> The text to search (haystack) </summary>
        [Required]
        public string Text { get; set; }

        /// <summary> The search term (needle) </summary>
        [Required]
        public string Subtext { get; set; }
    }
}
