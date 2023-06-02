using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.Requests
{
    public class ShowTimePostRequest
    {
        public DateTime SessionDate { get; set; }
        public Guid MovieId { get; set; }
        public Guid AuditoriumId { get; set; }
    }
}
