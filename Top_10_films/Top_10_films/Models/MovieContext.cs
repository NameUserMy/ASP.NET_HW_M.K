using Microsoft.EntityFrameworkCore;

namespace Top_10_films.Models
{
    public class MovieContext:DbContext
    {
        
        public MovieContext(DbContextOptions<MovieContext> options):base(options) {

           
        }
        public DbSet<CardMovie> CardMovies { get; set; }
    }
}
