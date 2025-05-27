
using MediatR;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Application.Tasks.Queries
{
    public class GetAllTasksQuery : IRequest<List<TaskItem>> { }
}