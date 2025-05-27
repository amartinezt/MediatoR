using MediatR;
using TaskBoard.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Domain.Entities;
using TaskBoard.Application.Tasks.Queries;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskItem>>
{
    private readonly TaskBoardDbContext _context;

    public GetAllTasksQueryHandler(TaskBoardDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        return await _context.TaskItems.ToListAsync(cancellationToken);
    }
}
