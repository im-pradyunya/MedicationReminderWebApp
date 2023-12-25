using MedicationReminder.Controllers;
using MedicationReminder.Models;
using MedicationReminder.Models.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicationReminder.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<UserMedicationInfo> UserMedicationInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserMedicationInfo>()
            .HasOne(u => u.user)
            .WithMany(m => m.MedicinceInfo)
            .HasForeignKey(u => u.Id);
            
            
            base.OnModelCreating(builder);
        }
    }
}
