using LMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<RateOfInterest> RateOfInterests { get; set; }
        public DbSet<LoanApplication> LoanApplication { get; set; }
        public DbSet<LoanEligibility> LoanEligibility { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ApplicationStatus> ApplicationStatus { get; set; }



    }
}
