namespace MatchFinderApi.Models
{
    public class MatchResponse
    {
        public string Text { get; set; }
        public string Subtext { get; set; }
        public int[] Matches { get; set; }
    }
}
