using AutoMapper;
using DataApplication.Database.Entities;
using DataApplication.Database.Repositories.Abstractions;
using DomainApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication.Database.Repositories
{
    public class MovieRepository : RepositoryBase<Movie, MovieEntity>, IMovieRepository
    {
        private readonly CinemaContext _context;

        public MovieRepository(CinemaContext context) : base(context) 
        {
            _context = context;
        }
    }
}
