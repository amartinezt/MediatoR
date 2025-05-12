
using MediatR;
using TaskBoard.Domain.Entities;

namespace TaskBoard.Application.Queries
{
    public class GetAllTasksQuery : IRequest<List<TaskItem>> { }
}