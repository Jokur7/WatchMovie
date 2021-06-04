using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchMovie.Models;

namespace WatchMovie.Repositories
{
    public interface IMovieRepository
    {
        MovieModel Get(int movieId);
        IQueryable<MovieModel> GetAllActive();
        void Add(MovieModel movie);
        void Update(int movieId, MovieModel movie);
        void Delete(int movieId);
    }
}
