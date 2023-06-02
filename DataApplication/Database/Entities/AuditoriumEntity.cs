using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApplication.Database.Entities
{
    public class AuditoriumEntity : BaseEntity
    {
        public List<ShowtimeEntity> Showtimes { get; set; }
        public ICollection<SeatEntity> Seats { get; set; }
       
    }
}
