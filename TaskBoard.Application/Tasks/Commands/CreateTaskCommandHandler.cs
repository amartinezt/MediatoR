using MediatR;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Application.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskItem>
    {
        private readonly ITaskRepository _repository;

        public CreateTaskCommandHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskItem> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false
            };

            return await _repository.AddAsync(task);
        }
    }
}
