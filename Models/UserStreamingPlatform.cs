using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Models
{
    public class UserStreamingPlatform
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int StreamingPlatformId { get; set; }
        public StreamingPlatform StreamingPlatform { get; set; }
    }
}