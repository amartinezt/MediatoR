using Moq;
using TaskBoard.Application.Commands.CreateTask;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Tests.Application.Tasks.Commands
{
    public class CreateTaskCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnCreatedTask()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();
            var handler = new CreateTaskCommandHandler(mockRepo.Object);

            var command = new CreateTaskCommand
            {
                Title = "Test Task",
                Description = "Test Description"
            };

            var expectedTask = new TaskItem { Id = Guid.NewGuid(), Title = "Test Task", Description = "Test Description", IsCompleted = false };

            // Mock AddAsync method since it's used in the handler
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<TaskItem>()))
                    .ReturnsAsync(expectedTask);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Task", result.Title);
            Assert.Equal("Test Description", result.Description);
            Assert.False(result.IsCompleted);
        }
    }
}
