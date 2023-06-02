using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApplication.Database.Entities
{
    public class ShowtimeEntity : BaseEntity
    {
        public MovieEntity Movie { get; set; }
        public DateTime SessionDate { get; set; }
        public Guid AuditoriumId { get; set; }
        public ICollection<TicketEntity> Tickets { get; set; }
        public ICollection<ReservationEntity> Reservations { get; set; }
    }
}
