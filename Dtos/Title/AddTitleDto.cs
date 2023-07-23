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
        public List<AddGenreDto>? Genres { get; set; }
        public string? ImdbId { get; set; }
        public double? ImdbRating { get; set; }
        public int? ImdbVoteCount { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public string? PosterPath { get; set; }
        public Dictionary<string, string>? PosterURLs { get; set; }
        public int? Runtime { get; set; }
        public List<AddStreamingServiceInfoDto>? StreamingInfo { get; set; }
        public string? Tagline { get; set; }
        public string? Title { get; set; }
        public int? TmdbId { get; set; }
        public double? TmdbRating { get; set; }
        public string? Type { get; set; }
        public int? Year { get; set; }
        public string? YoutubeTrailerVideoId { get; set; }
        public string? YoutubeTrailerVideoLink { get; set; }
    }

    public class AddStreamingServiceInfoDto
    {
        public string? Country { get; set; }
        public string? Platform { get; set; }
        public string? AddOn { get; set; }
        public List<AddAudioDto>? Audios { get; set; }
        public int? AvailableSince { get; set; }
        public long? Leaving { get; set; }
        public string? Link { get; set; }
        public object? Price { get; set; }
        public string? Quality { get; set; }
        public List<AddSubtitleDto>? Subtitles { get; set; }
        public string? Type { get; set; }
        public string? WatchLink { get; set; }
    }

    public class AddGenreDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }

    public class AddAudioDto
    {
        public string Language { get; set; }
        public string Region { get; set; }
    }

    public class AddSubtitleDto
    {
        public bool ClosedCaptions { get; set; }
        public AddLocaleDto Locale { get; set; }
    }

    public class AddLocaleDto
    {
        public string Language { get; set; }
        public string Region { get; set; }
    }
}