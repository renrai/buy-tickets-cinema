using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.Requests
{
    public class SeatPostRequest
    {
        public Guid Id{ get; set; }
        public short Row { get; set; }
        public short SeatNumber { get; set; }
    }
}
