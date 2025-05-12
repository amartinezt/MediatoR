using MediatR;
using TaskBoard.Domain.Interfaces;

namespace TaskBoard.Application.Commands
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ITaskRepository _repository;

        public DeleteTaskCommandHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}
