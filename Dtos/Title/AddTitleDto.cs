using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Dtos.Title
{
    public class AddTitleDto
    {
        public int? AdvisedMinimumAudienceAge { get; set; }
        public string? BackdropPath { get; set; }
        public Dictionary<string, string>? BackdropURLs { get; set; }
        public List<string>? Cast { get; set; }
        public List<string>? Countries { get; set; }
        public List<string>? Directors { get; set; }
        public List<Genre>? Genres { get; set; }
        public string? ImdbId { get; set; }
        public double? ImdbRating { get; set; }
        public int? ImdbVoteCount { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public string? PosterPath { get; set; }
        public Dictionary<string, string>? PosterURLs { get; set; }
        public int? Runtime { get; set; }
        public StreamingInfo? StreamingInfo { get; set; }
        public string? Tagline { get; set; }
        public string? Name { get; set; }
        public int? TmdbId { get; set; }
        public double? TmdbRating { get; set; }
        public string? Type { get; set; }
        public int? Year { get; set; }
        public string? YoutubeTrailerVideoId { get; set; }
        public string? YoutubeTrailerVideoLink { get; set; }
    }
}