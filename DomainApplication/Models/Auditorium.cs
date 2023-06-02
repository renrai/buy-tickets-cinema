using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.Models
{
    public class Auditorium : Base
    {
        public List<Showtime> Showtimes { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
