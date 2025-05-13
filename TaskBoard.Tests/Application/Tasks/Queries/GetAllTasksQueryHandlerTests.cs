using Microsoft.EntityFrameworkCore;
using Moq;
using TaskBoard.Application.Queries;
using TaskBoard.Domain.Entities;
using TaskBoard.Infrastructure.Db;

namespace TaskBoard.Tests.Application.Tasks.Queries
{
    public class GetAllTasksQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnListOfTasks()
        {
            // Arrange
            var mockDbContext = new Mock<TaskBoardDbContext>();
            var tasks = new List<TaskItem>
            {
                new TaskItem { Id = Guid.NewGuid(), Title = "Task 1" },
                new TaskItem { Id = Guid.NewGuid(), Title = "Task 2" },
                new TaskItem { Id = Guid.NewGuid(), Title = "Task 3" }
            }.AsQueryable();

            // Mock the DbSet<TaskItem> to return the tasks list
            var mockDbSet = new Mock<DbSet<TaskItem>>();
            mockDbSet.As<IQueryable<TaskItem>>().Setup(m => m.Provider).Returns(tasks.Provider);
            mockDbSet.As<IQueryable<TaskItem>>().Setup(m => m.Expression).Returns(tasks.Expression);
            mockDbSet.As<IQueryable<TaskItem>>().Setup(m => m.ElementType).Returns(tasks.ElementType);
            mockDbSet.As<IQueryable<TaskItem>>().Setup(m => m.GetEnumerator()).Returns(tasks.GetEnumerator());

            mockDbContext.Setup(c => c.TaskItems).Returns(mockDbSet.Object);

            var handler = new GetAllTasksQueryHandler(mockDbContext.Object);

            // Act
            var result = await handler.Handle(new GetAllTasksQuery(), CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Task 1", result[0].Title);
            Assert.Equal("Task 2", result[1].Title);
            Assert.Equal("Task 3", result[1].Title);
        }
    }
}
