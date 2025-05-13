using Moq;
using TaskBoard.Application.Commands;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Tests.Application.Tasks.Commands
{
    public class DeleteTaskCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenTaskIsDeleted()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();
            var taskId = Guid.NewGuid();

            mockRepo.Setup(r => r.DeleteAsync(taskId)).ReturnsAsync(true);

            var handler = new DeleteTaskCommandHandler(mockRepo.Object);
            var command = new DeleteTaskCommand(taskId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
        }
    }
}
