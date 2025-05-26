using Moq;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Tests.Helpers
{
    public abstract class TestBase
    {
        protected readonly Mock<ITaskRepository> _taskRepositoryMock;

        public TestBase()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
        }
    }
}
