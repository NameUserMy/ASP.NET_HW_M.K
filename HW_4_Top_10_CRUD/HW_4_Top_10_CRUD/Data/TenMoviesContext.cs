using HW_4_Top_10_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace HW_4_Top_10_CRUD.Data
{
    public class TenMoviesContext:DbContext
    {
        public TenMoviesContext(DbContextOptions<TenMoviesContext> options) : base(options)
        {

          
        }
        public DbSet<Movie> Movies { get; set; }
       
    }
}
