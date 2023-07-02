using System.ComponentModel.DataAnnotations;

namespace FunL_backend.Models
{
    public class StreamingPlatform
    {
        [Key]
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public List<StreamingServiceInfo>? TitlesAvailable { get; set; }
        public List<UserStreamingPlatform>? UserStreamingPlatforms { get; set; }
    }
}