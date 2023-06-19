using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Models
{
    public class Title
    {
        public int Id { get; set; }
        public string AdvisedMinimumAudienceAge { get; set; }
        public string BackdropPath { get; set; }
        public string BackdropURLs { get; set; }
        public string[] Cast { get; set; }
        public string[] Countries { get; set; }
        public string[] Directors { get; set; }
        public Genre[] Genres { get; set; }
        public string ImdbId { get; set; }
        public decimal ImdbRating { get; set; }
        public int ImdbVoteCount { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string PosterURLs { get; set; }
        public int Runtime { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public int TmdbId { get; set; }
        public decimal TmdbRating { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public string YoutubeTrailerVideoId { get; set; }
        public string YoutubeTrailerVideoLink { get; set; }
    }
}