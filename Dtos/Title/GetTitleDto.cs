using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Dtos.Title
{
    public class GetTitleDto
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

        public StreamingInfo StreamingInfo { get; set; } = default!;

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