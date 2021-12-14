/*
 *  Creating a DB Context Class
 *  DbContext - the primary class that is responsible for interating with data as objects in the EF
 */

using Microsoft.EntityFrameworkCore;

namespace NutritionCalculator.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
