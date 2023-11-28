using Microsoft.EntityFrameworkCore;

namespace AURA_ParcticalTask.models
{
        public class ApplicationDbContext : DbContext
        {
        public DbSet<ServiceModel> service { get; set; }
        public ApplicationDbContext(DbContextOptions option) : base(option)
            {

            }
        }
}
