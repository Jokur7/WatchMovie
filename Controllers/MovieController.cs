using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchMovie.Models;
using WatchMovie.Repositories;

namespace WatchMovie.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }
        // GET: MovieController
        public ActionResult Index()
        {
            return View(_movieRepository.GetAllActive());
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View(_movieRepository.Get(id));
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View(new MovieModel());
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieModel movieModel)
        {
            _movieRepository.Add(movieModel);
            return RedirectToAction(nameof(Index));

        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_movieRepository.Get(id));
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieModel movieModel)
        {
            _movieRepository.Update(id, movieModel);

                return RedirectToAction(nameof(Index));
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_movieRepository.Get(id));
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MovieModel movieModel)
        {
            _movieRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        //GET: MovieController/Done/5
        public ActionResult Done(int id)
        {
            MovieModel movie = _movieRepository.Get(id);
            movie.Done = true;
            _movieRepository.Update(id, movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
