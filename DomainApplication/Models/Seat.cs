using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainApplication.Models
{
    public class Seat : Base
    {
        public short Row { get; set; }
        public short SeatNumber { get; set; }
        public Guid AuditoriumId { get; set; }
        [JsonIgnore]
        public Auditorium Auditorium { get; set; }

    }
}
