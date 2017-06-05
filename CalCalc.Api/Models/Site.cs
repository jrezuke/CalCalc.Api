using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalCalc.Api.Models
{
    public class Site
    {
        public Site()
        {
            Subject = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public ICollection<Subject> Subject { get; set; }
    }
}
