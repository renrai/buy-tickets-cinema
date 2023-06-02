using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.Models
{
    public class Showtime : Base
    {
        public Movie Movie { get; set; }
        public DateTime SessionDate { get; set; }
        public Guid AuditoriumId { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

    }
}
