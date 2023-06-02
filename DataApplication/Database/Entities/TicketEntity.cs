using DataApplication.Database.Entities;
using System;
using System.Collections.Generic;

namespace DataApplication.Database.Entities
{
    public class TicketEntity : BaseEntity
    {
        public TicketEntity()
        {
            Paid = false;
        }
        public Guid ReservationId { get; set; }
        public bool Paid { get; set; }
        public ReservationEntity Reservation { get; set; }
    }
}
