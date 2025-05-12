using MediatR;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Application.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<TaskItem>
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}