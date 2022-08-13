using WebApiTest.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiTest.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Person> Person { get; set; }
}