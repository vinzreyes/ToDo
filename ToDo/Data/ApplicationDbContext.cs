using Microsoft.EntityFrameworkCore;

namespace ToDo.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDo.Models.ToDo> ToDos { get; set; }
    }

}
