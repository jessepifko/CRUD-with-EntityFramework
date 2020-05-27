using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework_Crud_Practice.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework_Crud_Practice.Controllers
{
    public class MoviesController : Controller
    {

        public readonly MoviesContext _context;

        public MoviesController(MoviesContext context)
        {
            _context = context;
        }
        public IActionResult MovieIndex()
        {
            List<MoviesDb> Movies = _context.MoviesDb.ToList();
            return View();

        }
        [HttpGet]
        public IActionResult ListMovies()
        {
            List<MoviesDb> movieList = _context.MoviesDb.ToList();
            return View(movieList);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(MoviesDb newMovie)
        {
            if (ModelState.IsValid)
            {
                _context.MoviesDb.Add(newMovie);
                _context.SaveChanges();
            }
            return RedirectToAction("ListMovies");
        }
        
        public IActionResult UpdateMovie(int id)
        {
            MoviesDb movie = _context.MoviesDb.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult UpdateMovie(MoviesDb newMovie)
        {
            MoviesDb oldMovie = _context.MoviesDb.Find(newMovie.Id);

            if (ModelState.IsValid)
            {
                oldMovie.Title = newMovie.Title;
                oldMovie.Genre = newMovie.Genre;
                oldMovie.ReleaseYear = newMovie.ReleaseYear;
                oldMovie.RunTime = newMovie.RunTime;
                oldMovie.RentPrice = newMovie.RentPrice;

                _context.Entry(oldMovie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Update(oldMovie);
                _context.SaveChanges();
            }

            return RedirectToAction("ListMovies");
        }

       public IActionResult DeleteMovie(int id)
        {
            MoviesDb movie = _context.MoviesDb.Find(id);
            if (movie != null)
            {
                _context.MoviesDb.Remove(movie);
                _context.SaveChanges();

            }
            
            return RedirectToAction("ListMovies");
        }

    }
}