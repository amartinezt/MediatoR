
using MediatR;
using TaskBoard.Infrastructure.Db;
using TaskBoard.Domain.Entities;
using TaskBoard.Application.Tasks.Queries;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskItem?>
{
    private readonly TaskBoardDbContext _context;

    public GetTaskByIdQueryHandler(TaskBoardDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItem?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);
    }
}
