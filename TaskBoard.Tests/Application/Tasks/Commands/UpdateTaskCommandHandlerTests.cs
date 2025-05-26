using Moq;
using TaskBoard.Application.Commands;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Tests.Application.Tasks.Commands
{
    public class UpdateTaskCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenUpdateSucceeds()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();
            var taskId = Guid.NewGuid();
            var handler = new UpdateTaskCommandHandler(mockRepo.Object);

            var command = new UpdateTaskCommand(taskId, "New Title", "Updated Description", true);

            // Setup repository mock to return true when update is called
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<TaskItem>())).ReturnsAsync(true);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            mockRepo.Verify(r => r.UpdateAsync(It.Is<TaskItem>(
                t => t.Id == taskId &&
                     t.Title == "New Title" &&
                     t.Description == "Updated Description" &&
                     t.IsCompleted == true
            )), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenUpdateFails()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();
            var handler = new UpdateTaskCommandHandler(mockRepo.Object);

            var command = new UpdateTaskCommand(Guid.NewGuid(), "Title", "Desc", false);

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<TaskItem>())).ReturnsAsync(false);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
        }
    }
}
