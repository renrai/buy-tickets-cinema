using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApplication.Database.Entities
{
    public class MovieEntity : BaseEntity
    {
        public string Title { get; set; }
        public string ImdbId { get; set; }
        public string Stars { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<ShowtimeEntity> Showtimes { get; set; }
    }
}
