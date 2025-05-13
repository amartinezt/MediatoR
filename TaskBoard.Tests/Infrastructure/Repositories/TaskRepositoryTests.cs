using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;
using TaskBoard.Infrastructure.Db;
using TaskBoard.Infrastructure.Repositories;

namespace TaskBoard.Tests.Infrastructure.Repositories
{
    public class TaskRepositoryTests
    {
        private TaskBoardDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<TaskBoardDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            return new TaskBoardDbContext(options);
        }

        [Fact]
        public async Task AddAsync_AddsTaskToDb()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repository = new TaskRepository(context);
            var task = new TaskItem { Title = "Test Task", Description = "Some description" };

            // Act
            await repository.AddAsync(task);
            var tasks = await repository.GetAllAsync();

            // Assert
            Assert.Single(tasks);
            Assert.Equal("Test Task", tasks[0].Title);
        }
    }
}
