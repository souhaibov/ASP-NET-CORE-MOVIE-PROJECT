using Microsoft.EntityFrameworkCore;
namespace MovieProject.Models
{
	public class MovieContext : DbContext // DbContext is the parent class
	{
		public DbSet<Movie> Movies { get; set; } = null!; // DbSet is a list of movie coming from the database. the ! is to ignore that non nullable
		public DbSet<Genre> Genres { get; set; } = null!;
		public MovieContext(DbContextOptions<MovieContext> options) : base(options) { } // a method that have the name of the class is named : constructor
																						// MovieContext is the movie constructor
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Genre>().HasData(
				new Genre() { GenreId = "C", Name = "Comedy" },
				new Genre() { GenreId = "D", Name = "Drama" },
				new Genre() { GenreId = "F", Name = "Fantastic" },
				new Genre() { GenreId = "A", Name = "Action" },
				new Genre() { GenreId = "Sc", Name = "Science Fiction" },
				new Genre() { GenreId = "S", Name = "Sport" },
				new Genre() { GenreId = "Hs", Name = "Historical" },
				new Genre() { GenreId = "H", Name = "Horror" }
				);

			modelBuilder.Entity<Movie>().HasData(
			   new Movie() { MovieId = 1, Name = "The Godfather", Year = 1972, Rating = 5, GenreId = "D" },
			   new Movie() { MovieId = 2, Name = "The Pawn Sacrifice", Year = 1942, Rating = 4, GenreId = "S" },
			   new Movie() { MovieId = 3, Name = "The Matrix", Year = 1999, Rating = 4, GenreId = "A" }
			   );
			
		}

	}
}
