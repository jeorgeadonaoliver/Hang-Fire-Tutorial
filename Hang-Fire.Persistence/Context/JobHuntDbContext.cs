using Hang_Fire.Domain.JobHunt;
using Microsoft.EntityFrameworkCore;

namespace Hang_Fire.Persistence.Context;

public partial class JobHuntDbContext : DbContext
{
    public JobHuntDbContext()
    {
    }

    public JobHuntDbContext(DbContextOptions<JobHuntDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applican__3214EC07B292BBF2");

            entity.ToTable("Applicant");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PositionApplying).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
