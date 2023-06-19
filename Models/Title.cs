using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Models
{
    public class PosterURLs : Dictionary<string, string>
    {
    }

    public class BackdropURLs : Dictionary<string, string>
    {
    }

    public class StreamingInfo : Dictionary<string, AvailableServices>
    {
    }

    public class ServiceInfo
    {
        public string AddOn { get; set; }
        public object Audios { get; set; }
        public int AvailableSince { get; set; }
        public int Leaving { get; set; }
        public string Link { get; set; }
        public object Price { get; set; }
        public string Quality { get; set; }
        public object Subtitles { get; set; }
        public string Type { get; set; }
        public string WatchLink { get; set; }
    }

    public class AvailableServices : Dictionary<string, ServiceInfo>
    {
    }

    public class Genre
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
    }

    public class Title
    {
        public int Id { get; set; } = default!;
        public string AdvisedMinimumAudienceAge { get; set; } = default!;
        public string BackdropPath { get; set; } = default!;
        public BackdropURLs BackdropURLs { get; set; } = default!;
        public string[] Cast { get; set; } = default!;
        public string[] Countries { get; set; } = default!;
        public string[] Directors { get; set; } = default!;
        public Genre[] Genres { get; set; } = default!;
        public string ImdbId { get; set; } = default!;
        public decimal ImdbRating { get; set; } = default!;
        public int ImdbVoteCount { get; set; } = default!;
        public string OriginalLanguage { get; set; } = default!;
        public string OriginalTitle { get; set; } = default!;
        public string Overview { get; set; } = default!;
        public string PosterPath { get; set; } = default!;
        public PosterURLs PosterURLs { get; set; } = default!;
        public int Runtime { get; set; } = default!;
        public StreamingInfo StreamingInfo = default!;
        public string Tagline { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int TmdbId { get; set; } = default!;
        public decimal TmdbRating { get; set; } = default!;
        public string Type { get; set; } = default!;
        public int Year { get; set; } = default!;
        public string YoutubeTrailerVideoId { get; set; } = default!;
        public string YoutubeTrailerVideoLink { get; set; } = default!;
    }
}