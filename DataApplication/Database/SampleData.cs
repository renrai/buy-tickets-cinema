using DataApplication.Database;
using DataApplication.Database.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DataApplication.Database
{
    public class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<CinemaContext>();
            context.Database.EnsureCreated();
            

            context.Auditoriums.Add(new AuditoriumEntity
            {
                Id = Guid.Parse("f10334aa-a425-414b-8bae-7d8d73b4532d"),
                Showtimes = new List<ShowtimeEntity> 
                { 
                    new ShowtimeEntity
                    {
                        Id = Guid.Parse("26daf1e3-79f0-4c2d-881e-47f7aa97886c"),
                        SessionDate = new DateTime(2023, 1, 1),
                        Movie = new MovieEntity
                        {
                            Id = Guid.Parse("23a793b2-2781-4c8c-a0ba-194288a74900"),
                            Title = "Inception",
                            ImdbId = "tt1375666",
                            ReleaseDate = new DateTime(2010, 01, 14),
                            Stars = "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page, Ken Watanabe"                            
                        },
                        AuditoriumId = Guid.Parse("f10334aa-a425-414b-8bae-7d8d73b4532d"),
                    } 
                },
                Seats = GenerateSeats(Guid.Parse("f10334aa-a425-414b-8bae-7d8d73b4532d"), 5, 10)
            });

            context.Auditoriums.Add(new AuditoriumEntity
            {
                Id = Guid.Parse("35878258-a8eb-48f0-b929-01c7b9b86b39"),
                Seats = GenerateSeats(Guid.Parse("35878258-a8eb-48f0-b929-01c7b9b86b39"), 21, 18)
            });

            context.Auditoriums.Add(new AuditoriumEntity
            {
                Id = Guid.Parse("e3dbdd93-5305-432d-9b8b-0c715c982930"),
                Seats = GenerateSeats(Guid.Parse("e3dbdd93-5305-432d-9b8b-0c715c982930"), 15, 21)
            });

            context.SaveChanges();
        }

        private static List<SeatEntity> GenerateSeats(Guid auditoriumId, short rows, short seatsPerRow)
        {
            var seats = new List<SeatEntity>();
            for (short r = 1; r <= rows; r++)
                for (short s = 1; s <= seatsPerRow; s++)
                    seats.Add(new SeatEntity {Id = Guid.NewGuid(),AuditoriumId = auditoriumId, Row = r, SeatNumber = s });

            return seats;
        }
    }
}
