using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Models
{
    public class TitleStreamingPlatform
    {
        public int TitleId { get; set; }
        public Title Title { get; set; }

        public int StreamingPlatformId { get; set; }
        public StreamingPlatform StreamingPlatform { get; set; }
    }
}