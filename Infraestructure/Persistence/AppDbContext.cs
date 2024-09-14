﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CampaignType> CampaignTypes { get; set; }
        public DbSet<TasksStatus> TaskStatus { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<InteractionType> InteractionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(u => u.UserID);
                    entity.Property(u => u.Name)
                          .HasColumnType("nvarchar")
                          .IsRequired()
                          .HasMaxLength(255);
                    entity.Property(u => u.Email)
                          .IsRequired()
                          .HasMaxLength(255);
                    //con Task
                    entity.HasMany(u => u.Tasks)
                          .WithOne(t => t.User)
                          .HasForeignKey(t => t.AssignedTo);
                }
            );

            // Task
            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(t => t.TaskID);
                entity.Property(t => t.Name)
                      .HasColumnType("nvarchar")
                      .IsRequired();
                entity.Property(t => t.DueDate)
                      .HasColumnType("date");
                //Con TasksStatus 
                entity.HasOne(t => t.TasksStatus)
                      .WithMany(ts => ts.Tasks)
                      .HasForeignKey(t => t.Status);
                //Con User 
                entity.HasOne(t => t.User)
                      .WithMany(u => u.Tasks)
                      .HasForeignKey(t => t.AssignedTo);
                //Con Proyect
                entity.HasOne(t => t.Project)
                      .WithMany(p => p.Tasks)
                      .HasForeignKey(t => t.ProjectID);
            });
            //TasksStatus
            modelBuilder.Entity<TasksStatus>(entity =>
            {
                entity.HasKey(ts => ts.Id);
                entity.Property(ts => ts.Name)
                      .IsRequired()
                      .HasMaxLength(25);
                //Con Task
                entity.HasMany(ts => ts.Tasks)
                      .WithOne(t => t.TasksStatus)
                      .HasForeignKey(t => t.Status);
            });
            //Project
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.ProjectID);
                entity.Property(p => p.ProjectName)
                      .IsRequired()
                      .HasMaxLength(255);
                //Con CampaignType 
                entity.HasOne(p => p.CampaignType)
                      .WithMany(ct => ct.Projects)
                      .HasForeignKey(p => p.CampaignTypeID);
                //Con Client 
                entity.HasOne(p => p.Client)
                      .WithMany(c => c.Projects)
                      .HasForeignKey(p => p.ClientID);
                //Con Task
                entity.HasMany(p => p.Tasks)
                      .WithOne(c => c.Project)
                      .HasForeignKey(p => p.ProjectID);
                //Con Interaction
                entity.HasMany(p => p.Interactions)
                      .WithOne(c => c.Project)
                      .HasForeignKey(p => p.ProjectID);  
                
                entity.Property(p => p.StartDate)
                      .HasColumnType("date");
                entity.Property(p => p.EndDate)
                      .HasColumnType("date");
            });
            //Client
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.ClientID);
                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(255);
                entity.Property(c => c.Email)
                      .HasMaxLength(255);
                entity.Property(c => c.Phone)
                      .HasMaxLength(255);
                entity.Property(c => c.Company)
                      .HasMaxLength(100);
                entity.Property(c => c.Address)
                      .HasColumnType("varchar(MAX)");

                //Con Project
                entity.HasMany(c => c.Projects)
                      .WithOne(p => p.Client)
                      .HasForeignKey(p => p.ClientID);
            });
            //CampaignType
            modelBuilder.Entity<CampaignType>(entity =>
            {
                entity.HasKey(ct => ct.Id);
                entity.Property(ct => ct.Name)
                      .IsRequired()
                      .HasMaxLength(25);

                //Con Project
                entity.HasMany(ct => ct.Projects)
                      .WithOne(p => p.CampaignType)
                      .HasForeignKey(p => p.CampaignTypeID);
            });
            //Interaction 
            modelBuilder.Entity<Interaction>(entity =>
            {
                entity.HasKey(i => i.InteractionID);
                //Con Project
                entity.HasOne(i => i.Project)
                      .WithMany(p => p.Interactions)
                      .HasForeignKey(i => i.ProjectID);
                //Con InteractionType
                entity.HasOne(i => i.InteractionType)
                      .WithMany(it => it.Interactions)
                      .HasForeignKey(i => i.InteractionTypeID); 
                
                entity.Property(i => i.Date)
                      .HasColumnType("date");
                entity.Property(i => i.Notes)
                      .HasColumnType("varchar(MAX)");
            });
            //Interaction
            modelBuilder.Entity<InteractionType>(entity =>
            {
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Name)
                      .IsRequired()
                      .HasMaxLength(25);

                //Con Interaction
                entity.HasMany(it => it.Interactions)
                      .WithOne(i => i.InteractionType)
                      .HasForeignKey(i => i.InteractionTypeID);
            });
        }
    }
}
