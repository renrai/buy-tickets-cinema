using DomainApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.Requests
{
    public class ReserveSeatPostRequest
    {
        public Guid ShowTimeId { get; set; }
        public IEnumerable<SeatPostRequest> Seats{ get; set; }
    }
}
