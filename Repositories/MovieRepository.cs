using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchMovie.Models;

namespace WatchMovie.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly WatchMovieContext _context;
        public MovieRepository(WatchMovieContext context)
        {
            _context = context;
        }
        public MovieModel Get(int movieId)
        => _context.Movies.SingleOrDefault(x => x.MovieId == movieId);
        public IQueryable<MovieModel> GetAllActive()
        => _context.Movies.Where(x => !x.Done);
        public void Add(MovieModel movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public void Update(int movieId, MovieModel movie)
        {
            var result=_context.Movies.SingleOrDefault(x => x.MovieId == movieId);
            if (result != null)
            {
                result.Name = movie.Name;
                result.Description = movie.Description;
                result.Done = movie.Done;

                _context.SaveChanges();
            }
        }

        public void Delete(int movieId)
        {
            var result= _context.Movies.SingleOrDefault(x => x.MovieId == movieId);
            if (result != null)
            {
                _context.Movies.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
