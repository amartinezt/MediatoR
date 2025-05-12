using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Infrastructure.Db
{
    public class TaskBoardDbContext : DbContext
    {
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().ToTable("TaskItems");

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
                entity.Property(t => t.Description).HasMaxLength(1000);
                entity.Property(t => t.IsCompleted).IsRequired();
                entity.Property(t => t.CreatedAt).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
