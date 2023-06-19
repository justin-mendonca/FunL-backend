using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Models
{
    public class TitleStreamingService
    {
        public int TitleId { get; set; }
        public Title Title { get; set; }

        public int StreamingServiceId { get; set; }
        public StreamingService StreamingService { get; set; }
    }
}