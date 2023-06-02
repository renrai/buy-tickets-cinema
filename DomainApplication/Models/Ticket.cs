using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.Models
{
    public class Ticket : Base
    {
        public Ticket()
        {
            Paid = false;
        }

        public Guid ReservationId { get; set; }
        public bool Paid { get; set; }
        public Reservation Reservation { get; set; }
    }
}
