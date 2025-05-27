using MediatR;
using TaskBoard.Domain.Entities;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Application.Tasks.Commands
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly ITaskRepository _repository;

        public UpdateTaskCommandHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted
            };

            return await _repository.UpdateAsync(task);
        }
    }
}
