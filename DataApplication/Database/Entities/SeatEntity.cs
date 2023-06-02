namespace DataApplication.Database.Entities
{
    public class SeatEntity : BaseEntity
    {
        public short Row { get; set; }
        public short SeatNumber { get; set; }
        public Guid AuditoriumId { get; set; }
        public AuditoriumEntity Auditorium { get; set; }


    }
}
