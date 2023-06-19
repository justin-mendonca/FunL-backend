using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Models
{
    public class TitleStreamingPlatform
    {
        public int TitleId { get; set; } = default!;
        public Title Title { get; set; } = default!;

        public int StreamingPlatformId { get; set; } = default!;
        public StreamingPlatform StreamingPlatform { get; set; } = default!;
    }
}