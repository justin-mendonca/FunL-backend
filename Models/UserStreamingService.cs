using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Models
{
    public class UserStreamingService
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int StreamingServiceId { get; set; }
        public StreamingService StreamingService { get; set; }
    }
}