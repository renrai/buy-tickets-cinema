using DomainApplication.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication.Database.Entities
{
    public class ReservationEntity : BaseEntity
    {
        public Guid AuditoriumId { get; set; }
        public Guid ShowtimeId { get; set; }
        public ShowtimeEntity Showtime { get; set; }
        public ICollection<ReservationSeatsEntity> Seats { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime AvailableUntil { get; set; }

    }
}
