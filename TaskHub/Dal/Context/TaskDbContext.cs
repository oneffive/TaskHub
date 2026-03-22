using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Context;

public sealed class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

    public DbSet<TaskEntity> Tasks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TaskEntity>(cfg =>
        {
            cfg.HasKey(t => t.Id);

            cfg.Property(t => t.Title)
               .HasMaxLength(500);

            cfg.Property(t => t.CreatedUtc)
               .HasDefaultValueSql("now()");

            cfg.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.CreatedByUserId)
               .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Ignore<User>();

        base.OnModelCreating(builder);
    }
}