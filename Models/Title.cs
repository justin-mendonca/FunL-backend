using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FunL_backend.Models
{
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

        public Dictionary<string, string> BackdropURLs { get; set; } = default!;

        [JsonIgnore]
        public string CastSerialized
        {
            get => JsonSerializer.Serialize(Cast);
            set => Cast = JsonSerializer.Deserialize<string[]>(value);
        }

        [NotMapped]
        public string[] Cast { get; set; } = default!;

        [JsonIgnore]
        public string CountriesSerialized
        {
            get => JsonSerializer.Serialize(Countries);
            set => Countries = JsonSerializer.Deserialize<string[]>(value);
        }

        [NotMapped]
        public string[] Countries { get; set; } = default!;

        [JsonIgnore]
        public string DirectorsSerialized
        {
            get => JsonSerializer.Serialize(Directors);
            set => Directors = JsonSerializer.Deserialize<string[]>(value);
        }

        [NotMapped]
        public string[] Directors { get; set; } = default!;

        public Genre[] Genres { get; set; } = default!;

        public string ImdbId { get; set; } = default!;

        public decimal ImdbRating { get; set; } = default!;

        public int ImdbVoteCount { get; set; } = default!;

        public string OriginalLanguage { get; set; } = default!;

        public string OriginalTitle { get; set; } = default!;

        public string Overview { get; set; } = default!;

        public string PosterPath { get; set; } = default!;

        public Dictionary<string, string> PosterURLs { get; set; } = default!;

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