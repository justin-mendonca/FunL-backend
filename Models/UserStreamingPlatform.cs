using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Models
{
    public class UserStreamingPlatform
    {
        public int UserId { get; set; } = default!;
        public User User { get; set; } = default!;

        public int StreamingPlatformId { get; set; } = default!;
        public StreamingPlatform StreamingPlatform { get; set; } = default!;
    }
}