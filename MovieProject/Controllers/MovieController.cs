using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
	public class MovieController : Controller
	{
		private MovieContext Context { get; set; } // MovieContext has a list of movies (DbSet)... a Set of movies

		//Constructor accepts DB context object that's enabled by DI. Dependency Injections is going to allow our context to be passed to a controller
		public MovieController(MovieContext ctx)
		{
			Context = ctx;
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			ViewBag.Action = "Delete Movie";
			var movie = Context.Movies.Find(id); // a primary key search (id)
			return View(movie);
		}
		[HttpPost]
		public IActionResult Delete(Movie movie)
		{
			Context.Movies.Remove(movie);
            Context.SaveChanges();
			return RedirectToAction("Index", "Home");
	}


		[HttpGet]
		public IActionResult Add() // it's a method that will call the Edit View... So we need to create that view
		{
			ViewBag.Action = "Add New Movie"; // called in the Edit View as a Title
			ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
			return View("Edit", new Movie());
		}

		[HttpGet]
		public IActionResult Edit(int id) 
		// an Edit action that accepts an integer id. it's going to take this id (that part of the path)
		// and pass it as an argument into this method
		{
			ViewBag.Action = "Edit Movie";
			ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
			var movie = Context.Movies.Find(id); // a primary key search (id)
			return View(movie);
		}

		[HttpPost]
		public IActionResult Edit(Movie movie) // the movie that we sent from the front-end into this Edit method need a check
		{
			if (ModelState.IsValid)
			{
				// Either add a new movie or Edit a movie
				if (movie.MovieId ==0) // if it's a new movie the Id will be 0 and than it should be added
				{
					Context.Movies.Add(movie);
				}
				else // if the movie has an id than it will be an update
				{
					Context.Movies.Update(movie);
				}

				Context.SaveChanges();
				return RedirectToAction("Index", "Home");
				
			}
			else
			{
				// this is basically to show our validation errors
				ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
				ViewBag.Genres = Context.Genres.OrderBy(g=> g.Name).ToList();
				return View(movie);
			}
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
