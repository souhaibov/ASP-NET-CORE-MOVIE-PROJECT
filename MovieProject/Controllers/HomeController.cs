
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
// test
namespace MovieProject.Controllers
{
	public class HomeController : Controller
	{
		private MovieContext Context { get; set; } // MovieContext has a list of movies (DbSet)... a Set of movies

		//Constructor accepts DB context object that's enabled by DI. Dependency Injections is going to allow our context to be passed to a controller
		public HomeController(MovieContext ctx)
		{
			Context = ctx;
		}
		public IActionResult Index()
		{
			var movies = Context.Movies.Include(m=>m.Genre).OrderBy(m => m.Name).ToList(); // ordering the list of movies with Name and return it to our view
			return View(movies); // after sending the list to the view, we need to recieve and display it in (views/home/Index)
		}
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
