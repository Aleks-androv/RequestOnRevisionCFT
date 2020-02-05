using System.Collections.Generic;

namespace RequestOnRevision.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Request> Requests { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}