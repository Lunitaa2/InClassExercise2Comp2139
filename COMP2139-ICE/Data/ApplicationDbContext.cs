using COMP2139_ICE.Areas.ProjectManagement.Models;
using COMP2139_ICE.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP2139_ICE.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> ProjectTasks { get; set; }
    public DbSet<ProjectComment> ProjectComments { get; set; }

     
    //Week6
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define One-to-Many Relationship: One Project has Many ProjectTasks
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Tasks) // One Project has many ProjectTasks
            .WithOne(t => t.Project) // Each ProjectTask belongs to one Project
            .HasForeignKey(t => t.ProjectId) // Foreign key in ProjectTask table
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete ProjectTasks when a Project is deleted


        // Seeding Projects - Lab 9 ICE-2
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                ProjectId = 1,
                Name = "Student Wellness Hub",
                Description = "A web platform to help college students book wellness appointments, access mental health resources, and track their self-care habits.",
                StartDate = new DateTime(2025, 1, 10, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2025, 3, 31, 0, 0, 0, DateTimeKind.Utc),
                Status = "In Progress"
            },
            new Project
            {
                ProjectId = 2,
                Name = "E-Commerce Platform",
                Description = "An online shopping platform with product catalog, shopping cart, and secure checkout.",
                StartDate = new DateTime(2025, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2025, 5, 31, 0, 0, 0, DateTimeKind.Utc),
                Status = "New"
            },
            new Project
            {
                ProjectId = 3,
                Name = "Task Management System",
                Description = "A productivity tool for teams to manage tasks, track progress, and collaborate effectively.",
                StartDate = new DateTime(2024, 11, 1, 0, 0, 0, DateTimeKind.Utc),
                EndDate = new DateTime(2025, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                Status = "Complete"
            }
        );
    }
}
