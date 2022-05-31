using Microsoft.EntityFrameworkCore;
using demo_map_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace demo_map_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User>? Users { get; set; }
        public DbSet<Assistance>? Assistances { get; set; }

        public DbSet<Application>? Applications { get; set; }

        public DbSet<Applicant>? Applicants { get; set; }
    }
    
}
