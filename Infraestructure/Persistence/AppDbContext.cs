using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base() { }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CampaignType> CampaignTypes { get; set; }
        public DbSet<Domain.Entities.TaskStatus> TaskStatuses { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<InteractionType> InteractionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(u => u.UserId);
                    entity.Property(u => u.Name)
                          .IsRequired()
                          .HasMaxLength(255);
                    entity.Property(u => u.Email)
                          .IsRequired()
                          .HasMaxLength(255);

                    entity.HasMany(u => u.Tasks)
                          .WithOne(t => t.User)
                          .HasForeignKey(t => t.AssignedTo);
                }
            );

            // Task
            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(t => t.TaskId);
                entity.Property(t => t.Name)
                      .IsRequired()
                      .HasMaxLength(255);
                entity.Property(t => t.DueDate)
                      .HasColumnType("date");

                entity.HasOne(t => t.TaskStatus)
                      .WithMany(ts => ts.Tasks)
                      .HasForeignKey(t => t.TaskId);

                entity.HasOne(t => t.User)
                      .WithMany(u => u.Tasks)
                      .HasForeignKey(t => t.AssignedTo);
            });
                

            // Task - Project (uno a muchos)
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectID)
                .OnDelete(DeleteBehavior.Cascade);

            // Interaction - Project (uno a muchos)
            modelBuilder.Entity<Interaction>()
                .HasOne(i => i.Project)
                .WithMany(p => p.Interactions)
                .HasForeignKey(i => i.ProjectID)
                .OnDelete(DeleteBehavior.Cascade);

            // Interaction - InteractionType (uno a muchos)
            modelBuilder.Entity<Interaction>()
                .HasOne(i => i.InteractionTypeNavigation)
                .WithMany(it => it.Interactions)
                .HasForeignKey(i => i.InteractionType)
                .OnDelete(DeleteBehavior.Restrict);

            // Project - CampaignType (uno a muchos)
            modelBuilder.Entity<Project>()
                .HasOne(p => p.CampaignTypeNavigation)
                .WithMany(ct => ct.Projects)
                .HasForeignKey(p => p.CampaignType)
                .OnDelete(DeleteBehavior.Restrict);

            // Project - Client (uno a muchos)
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ClientID)
                .OnDelete(DeleteBehavior.Restrict);

            // InteractionType - Interactions (uno a muchos)
            modelBuilder.Entity<InteractionType>()
                .HasMany(it => it.Interactions)
                .WithOne(i => i.InteractionTypeNavigation)
                .HasForeignKey(i => i.InteractionType);
        }
    }
}
