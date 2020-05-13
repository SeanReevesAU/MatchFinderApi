using MatchFinderApi.Services;
using System.Linq;
using Xunit;

namespace MatchFinderApi.Tests.Services
{
    public class MatchServiceTests
    {
        private readonly MatchService _sut;
        public MatchServiceTests()
        {
            _sut = new MatchService();
        }

        [Theory]
        [InlineData("test", "test", 0, 1)]
        [InlineData("TeST", "tEst", 0, 1)]
        [InlineData("TeST test  TEST", "tEst", 0, 3)]
        [InlineData("The Quick Brown Fox Jumped Over the LazY DoG", "lazy Dog", 36, 1)]
        [InlineData("aaaaaaaaaa", "a", 0, 10)]
        [InlineData("abcdefgg", "g", 6, 2)]
        [InlineData("abc123", "c1", 2, 1)]
        [InlineData("xxxx", "xx", 0, 3)]
        public async void ShouldReturnCorrectMatchDetails_OnSuccessfulMatch(string text, string subtext, int first, int numMatches)
        {
            var matches = await _sut.FindMatchesAsync(text, subtext);
            Assert.NotEmpty(matches);
            Assert.Equal(first, matches.First());
            Assert.Equal(numMatches, matches.Count());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("t", "test")]
        [InlineData(null, "test")]
        [InlineData("test", null)]
        [InlineData("test", "apple123")]
        [InlineData("The Quick Brown Fox Jumped Over the LazY DoG", "Cat")]
        public async void ShouldReturnEmptyArray_OnUnsuccessfulMatch(string text, string subtext)
        {
            var matches = await _sut.FindMatchesAsync(text, subtext);
            Assert.Empty(matches);
        }
    }
}
