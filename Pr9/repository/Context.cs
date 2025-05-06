using Microsoft.EntityFrameworkCore;
using Pr9.entity;

namespace Pr9.repository;

public class Context : DbContext
{
    public DbSet<Member> members { get; set; }
    public DbSet<Subscription> subscriptions { get; set; }
    public DbSet<Trainer> trainers { get; set; }
    public DbSet<Training> trainings { get; set; }
    public DbSet<Session> sessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=User;" +
                                 "Password=Password;Database=DatabasePr9");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Training>().ToTable("trainings");
        modelBuilder.Entity<Training>().Property(t => t.trainer_id).HasColumnName("trainer_id");
        modelBuilder.Entity<Training>()
            .HasOne(t => t.trainer)
            .WithMany(tr => tr.trainings)
            .HasForeignKey(t => t.trainer_id);
        
        modelBuilder.Entity<Session>().ToTable("sessions");
        modelBuilder.Entity<Session>().Property(s => s.training_id).HasColumnName("training_id");
        modelBuilder.Entity<Session>()
            .HasOne(s => s.training)
            .WithMany(t => t.sessions)
            .HasForeignKey(s => s.training_id);
    }
}