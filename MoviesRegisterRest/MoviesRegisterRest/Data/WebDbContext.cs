using Microsoft.EntityFrameworkCore;
using MoviesRegisterRest.Data.Entities;

namespace MoviesRegisterRest.Data;

public class WebDbContext : DbContext
{
    public DbSet<Director> Directors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieStudio> MovieStudios { get; set; }

    public WebDbContext(DbContextOptions<WebDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=WebDb2");
    //    //optionsBuilder.UseMySQL("Data Source=127.0.0.1;port=3306;Initial Catalog=WebDb2;User Id=root;Password=root;SslMode=none;Convert Zero Datetime=True;");
    //}
}