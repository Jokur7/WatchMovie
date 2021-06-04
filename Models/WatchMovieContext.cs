using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchMovie.Models
{
    public class WatchMovieContext : DbContext
    {
        public WatchMovieContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MovieModel> Movies { get; set; }
    }
}
