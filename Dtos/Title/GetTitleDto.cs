using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Dtos.Title
{
    public class GetTitleDto
    {
        public int? AdvisedMinimumAudienceAge { get; set; }
        public string BackdropPath { get; set; }
        public Dictionary<string, string> BackdropURLs { get; set; }
        public List<string> Cast { get; set; }
        public List<string> Countries { get; set; }
        public List<string> Directors { get; set; }
        public List<string> Genres { get; set; }
        public string ImdbId { get; set; }
        public double? ImdbRating { get; set; }
        public int? ImdbVoteCount { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public Dictionary<string, string> PosterURLs { get; set; }
        public int? Runtime { get; set; }
        public List<GetStreamingServiceInfoDto> StreamingServices { get; set; }
        public string Tagline { get; set; }
        public string Name { get; set; }
        public int? TmdbId { get; set; }
        public double? TmdbRating { get; set; }
        public string Type { get; set; }
        public int? Year { get; set; }
        public string YoutubeTrailerVideoId { get; set; }
        public string YoutubeTrailerVideoLink { get; set; }
    }

    public class GetStreamingServiceInfoDto
    {
        public string Platform { get; set; }
        public string AddOn { get; set; }
        public object Audios { get; set; }
        public int? AvailableSince { get; set; }
        public long? Leaving { get; set; }
        public string Link { get; set; }
        public object Price { get; set; }
        public string Quality { get; set; }
        public object Subtitles { get; set; }
        public string Type { get; set; }
        public string WatchLink { get; set; }
        public string Country { get; set; }
    }
}