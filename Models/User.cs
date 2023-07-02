using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Models
{
    public class User
    {
        public int Id { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public List<UserStreamingPlatform>? UserStreamingPlatforms { get; set; }
        public List<UserTitle>? UserTitles { get; set; }
    }
}