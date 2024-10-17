using Domain.Entities;
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
        public DbSet<Domain.Entities.TaskStatus> TaskStatus { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<InteractionType> InteractionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(u => u.UserID);
                    entity.Property(u => u.UserID).ValueGeneratedOnAdd();
                    entity.Property(u => u.Name)
                          .HasColumnType("nvarchar")
                          .IsRequired()
                          .HasMaxLength(255);
                    entity.Property(u => u.Email)
                          .HasColumnType("nvarchar")
                          .IsRequired()
                          .HasMaxLength(255);

                    entity.HasMany(u => u.Tasks)
                          .WithOne(t => t.User)
                          .HasForeignKey(t => t.AssignedTo);
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, Name = "Joe Done", Email = "jdone@marketing.com" },
                new User { UserID = 2, Name = "Nill Amstrong", Email = "namstrong@marketing.com" },
                new User { UserID = 3, Name = "Marlyn Morales", Email = "mmorales@marketing.com" },
                new User { UserID = 4, Name = "Anthony Orué", Email = "aorue@marketing.com" },
                new User { UserID = 5, Name = "Jazmin Fernandez", Email = "jfernandez@marketing.com" }

            );

            //Tasks
            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(t => t.TaskID);
                entity.Property(t => t.TaskID).ValueGeneratedOnAdd().HasColumnType("char(36)");
                entity.Property(t => t.Name)
                      .HasColumnType("nvarchar")
                      .IsRequired()
                      .HasMaxLength(255);
                entity.Property(t => t.DueDate)
                      .HasColumnType("datetime");

                entity.HasOne(t => t.TasksStatus)
                      .WithMany(ts => ts.Tasks)
                      .HasForeignKey(t => t.Status);

                entity.HasOne(t => t.User)
                      .WithMany(u => u.Tasks)
                      .HasForeignKey(t => t.AssignedTo);

                entity.HasOne(t => t.Project)
                      .WithMany(p => p.Tasks)
                      .HasForeignKey(t => t.ProjectID);
            });

            //TaskStatus
            modelBuilder.Entity<Domain.Entities.TaskStatus>(entity =>
            {
                entity.HasKey(ts => ts.Id);
                entity.Property(ts => ts.Id).ValueGeneratedOnAdd();
                entity.Property(ts => ts.Name)
                      .IsRequired()
                      .HasColumnType("varchar")
                      .HasMaxLength(25);

                entity.HasMany(ts => ts.Tasks)
                      .WithOne(t => t.TasksStatus)
                      .HasForeignKey(t => t.Status);
            });
            modelBuilder.Entity<Domain.Entities.TaskStatus>().HasData(
                new Domain.Entities.TaskStatus { Id = 1, Name = "Pending" },
                new Domain.Entities.TaskStatus { Id = 2, Name = "In Progress" },
                new Domain.Entities.TaskStatus { Id = 3, Name = "Blocked" },
                new Domain.Entities.TaskStatus { Id = 4, Name = "Done" },
                new Domain.Entities.TaskStatus { Id = 5, Name = "Cancel" }
            );

            //Projects
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.ProjectID);
                entity.Property(t => t.ProjectID).ValueGeneratedOnAdd().HasColumnType("char(36)");

                entity.Property(p => p.ProjectName)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.HasOne(p => p.CampaignType)
                      .WithMany(ct => ct.Projects)
                      .HasForeignKey(p => p.CampaignTypeID);

                entity.HasOne(p => p.Client)
                      .WithMany(c => c.Projects)
                      .HasForeignKey(p => p.ClientID);

                entity.HasMany(p => p.Tasks)
                      .WithOne(c => c.Project)
                      .HasForeignKey(p => p.ProjectID);

                entity.HasMany(p => p.Interactions)
                      .WithOne(c => c.Project)
                      .HasForeignKey(p => p.ProjectID);

                entity.Property(p => p.StartDate)
                      .HasColumnType("datetime");
                entity.Property(p => p.EndDate)
                      .HasColumnType("datetime");
            });
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Optimización SEO", CampaignTypeID = 1, ClientID = 1, StartDate = DateTime.Parse("2024-10-01"), EndDate = DateTime.Parse("2024-10-31") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Desarrollo WEB", CampaignTypeID = 2, ClientID = 1, StartDate = DateTime.Parse("2024-11-01"), EndDate = DateTime.Parse("2024-12-01") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Estrategia PPC", CampaignTypeID = 2, ClientID = 3, StartDate = DateTime.Parse("2024-10-05"), EndDate = DateTime.Parse("2024-11-05") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Campaña Redes Sociales", CampaignTypeID = 3, ClientID = 2, StartDate = DateTime.Parse("2024-09-01"), EndDate = DateTime.Parse("2024-09-30") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Campaña Email Marketing", CampaignTypeID = 4, ClientID = 4, StartDate = DateTime.Parse("2024-10-10"), EndDate = DateTime.Parse("2024-11-10") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Redesign Web", CampaignTypeID = 1, ClientID = 1, StartDate = DateTime.Parse("2024-01-10"), EndDate = DateTime.Parse("2024-02-20") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "SEO Campaign", CampaignTypeID = 2, ClientID = 2, StartDate = DateTime.Parse("2024-03-01"), EndDate = DateTime.Parse("2024-04-15") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Social Media Strategy", CampaignTypeID = 3, ClientID = 3, StartDate = DateTime.Parse("2024-05-10"), EndDate = DateTime.Parse("2024-06-10") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Email Automation", CampaignTypeID = 4, ClientID = 4, StartDate = DateTime.Parse("2024-07-15"), EndDate = DateTime.Parse("2024-08-20") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "PPC Advertising", CampaignTypeID = 2, ClientID = 5, StartDate = DateTime.Parse("2024-09-01"), EndDate = DateTime.Parse("2024-10-15") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Lead Generation Campaign", CampaignTypeID = 1, ClientID = 1, StartDate = DateTime.Parse("2024-11-10"), EndDate = DateTime.Parse("2024-12-25") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Market Research", CampaignTypeID = 3, ClientID = 2, StartDate = DateTime.Parse("2024-01-10"), EndDate = DateTime.Parse("2024-03-05") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Rebranding", CampaignTypeID = 4, ClientID = 3, StartDate = DateTime.Parse("2024-04-10"), EndDate = DateTime.Parse("2024-05-25") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Content Marketing", CampaignTypeID = 1, ClientID = 4, StartDate = DateTime.Parse("2024-06-05"), EndDate = DateTime.Parse("2024-07-30") },
                new Project { ProjectID = Guid.NewGuid(), ProjectName = "Mobile App Development", CampaignTypeID = 2, ClientID = 5, StartDate = DateTime.Parse("2024-08-15"), EndDate = DateTime.Parse("2024-09-25") }
            );

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

                entity.HasMany(c => c.Projects)
                      .WithOne(p => p.Client)
                      .HasForeignKey(p => p.ClientID);
            });
            modelBuilder.Entity<Client>().HasData(
                new Client { ClientID = 1, Name = "Ignacio García", Email = "igarcia@company.com", Phone = "123456789", Company = "Marketing Co.", Address = "Calle Falsa 123" },
                new Client { ClientID = 2, Name = "Luciana Pérez", Email = "lperez@company.com", Phone = "987654321", Company = "Redes Global", Address = "Avenida Real 456" },
                new Client { ClientID = 3, Name = "Maximiliano Sosa", Email = "msosa@company.com", Phone = "123123123", Company = "SEO Experts", Address = "Boulevard Principal 789" },
                new Client { ClientID = 4, Name = "Marta Ramírez", Email = "mramirez@company.com", Phone = "456456456", Company = "MediaPlus", Address = "Calle Secundaria 321" },
                new Client { ClientID = 5, Name = "Ramiro López", Email = "rlopez@company.com", Phone = "654654654", Company = "PPC Boosters", Address = "Camino Real 654" }
            );


            //CampaignType
            modelBuilder.Entity<CampaignType>(entity =>
            {
                entity.HasKey(ct => ct.Id);
                entity.Property(ct => ct.Name)
                      .IsRequired()
                      .HasMaxLength(25);

                entity.HasMany(ct => ct.Projects)
                      .WithOne(p => p.CampaignType)
                      .HasForeignKey(p => p.CampaignTypeID);
            });
            modelBuilder.Entity<CampaignType>().HasData(
                new CampaignType { Id = 1, Name = "SEO" },
                new CampaignType { Id = 2, Name = "PPC" },
                new CampaignType { Id = 3, Name = "Social Media" },
                new CampaignType { Id = 4, Name = "Email Marketing" }
            );

            //Interaction 
            modelBuilder.Entity<Interaction>(entity =>
            {
                entity.HasKey(i => i.InteractionID);
                entity.Property(t => t.InteractionID).ValueGeneratedOnAdd().HasColumnType("char(36)");

                entity.HasOne(i => i.Project)
                      .WithMany(p => p.Interactions)
                      .HasForeignKey(i => i.ProjectID);

                entity.HasOne(i => i.InteractionType)
                      .WithMany(it => it.Interactions)
                      .HasForeignKey(i => i.InteractionTypeID);

                entity.Property(i => i.Date)
                      .HasColumnType("date");
                entity.Property(i => i.Notes)
                      .HasColumnType("varchar(MAX)");
            });

            //InteractionType
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
            modelBuilder.Entity<InteractionType>().HasData(
                new InteractionType { Id = 1, Name = "Initial Meeting" },
                new InteractionType { Id = 2, Name = "Phone Call" },
                new InteractionType { Id = 3, Name = "Email" },
                new InteractionType { Id = 4, Name = "Presentation Of Results" }
            );
        }
    }
}
