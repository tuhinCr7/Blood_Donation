using Microsoft.EntityFrameworkCore;

namespace CSproject.Models
{
    public class BloodDonationContext : DbContext
    {
        public BloodDonationContext(DbContextOptions<BloodDonationContext> options)
            : base(options) { }

        public BloodDonationContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;Database=BloodDonation;Uid=root;Pwd=;SslMode=none;");
            }
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Donor> Donors { get; set; } = null!;
        public DbSet<BloodGroup> BloodGroups { get; set; } = null!;
        public DbSet<SearchLog> SearchLogs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Explicitly map foreign keys to avoid shadow properties
    modelBuilder.Entity<Donor>()
        .Property(d => d.UserId)
        .HasColumnName("UserId");

    modelBuilder.Entity<Donor>()
        .Property(d => d.BloodGroupId)
        .HasColumnName("BloodGroupId");

    modelBuilder.Entity<Donor>()
        .HasOne(d => d.User)
        .WithMany()
        .HasForeignKey(d => d.UserId)
        .HasConstraintName("FK_Donors_Users_UserId");

    modelBuilder.Entity<Donor>()
        .HasOne(d => d.BloodGroup)
        .WithMany()
        .HasForeignKey(d => d.BloodGroupId)
        .HasConstraintName("FK_Donors_BloodGroups_BloodGroupId");
}
    }
}