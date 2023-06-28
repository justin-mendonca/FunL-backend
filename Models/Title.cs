using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace FunL_backend.Models
{
    public class StreamingServiceInfo
    {
        public string? AddOn { get; set; }
        public object? Audios { get; set; }
        public int? AvailableSince { get; set; }
        public long? Leaving { get; set; }
        public string? Link { get; set; }
        public object? Price { get; set; }
        public string? Quality { get; set; }
        public object? Subtitles { get; set; }
        public string? Type { get; set; }
        public string? WatchLink { get; set; }
    }

    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } 
        public List<TitleGenre>? TitleGenres { get; set; }
    }

    public class TitleGenre
    {
        public int? TitleId { get; set; }
        public Title? Title { get; set; }
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
    }

    public class Title
    {
        [Key]
        public int Id { get; set; }

        public int? AdvisedMinimumAudienceAge { get; set; }
        public string? BackdropPath { get; set; }
        public string? BackdropURLsJson
        {
            get => BackdropURLs != null ? JsonSerializer.Serialize(BackdropURLs) : null;
            set => BackdropURLs = !string.IsNullOrEmpty(value) ? JsonSerializer.Deserialize<Dictionary<string, string>>(value) : null;
        }
        [NotMapped]
        public Dictionary<string, string>? BackdropURLs { get; set; }
        public string? CastJson
        {
            get => Cast != null ? JsonSerializer.Serialize(Cast) : null;
            set => Cast = !string.IsNullOrEmpty(value) ? JsonSerializer.Deserialize<List<string>>(value) : null;
        }
        [NotMapped]
        public List<string>? Cast { get; set; }
        public string? CountriesJson
        {
            get => Countries != null ? JsonSerializer.Serialize(Countries) : null;
            set => Countries = !string.IsNullOrEmpty(value) ? JsonSerializer.Deserialize<List<string>>(value) : null;
        }
        [NotMapped]
        public List<string>? Countries { get; set; }
        public string? DirectorsJson
        {
            get => Directors != null ? JsonSerializer.Serialize(Directors) : null;
            set => Directors = !string.IsNullOrEmpty(value) ? JsonSerializer.Deserialize<List<string>>(value) : null;
        }
        [NotMapped]
        public List<string>? Directors { get; set; }
        public List<TitleGenre>? TitleGenres { get; set; }
        public string? ImdbId { get; set; }
        public double? ImdbRating { get; set; }
        public int? ImdbVoteCount { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public string? PosterPath { get; set; }
        public string? PosterURLsJson
        {
            get => PosterURLs != null ? JsonSerializer.Serialize(PosterURLs) : null;
            set => PosterURLs = !string.IsNullOrEmpty(value) ? JsonSerializer.Deserialize<Dictionary<string, string>>(value) : null;
        }
        [NotMapped]
        public Dictionary<string, string>? PosterURLs { get; set; }
        public int? Runtime { get; set; }
        [Column("StreamingInfo")]
        public string? StreamingInfoJson
        {
            get => StreamingInfo != null ? JsonSerializer.Serialize(StreamingInfo) : null;
            set => StreamingInfo = !string.IsNullOrEmpty(value) ? JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<StreamingServiceInfo>>>>(value) : null;
        }
        [NotMapped]
        public Dictionary<string, Dictionary<string, List<StreamingServiceInfo>>>? StreamingInfo { get; set; }
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