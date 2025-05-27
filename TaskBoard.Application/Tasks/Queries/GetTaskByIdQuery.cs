using MediatR;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Application.Tasks.Queries
{
    public class GetTaskByIdQuery : IRequest<TaskItem?>
    {
        public Guid Id { get; set; }

        public GetTaskByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}