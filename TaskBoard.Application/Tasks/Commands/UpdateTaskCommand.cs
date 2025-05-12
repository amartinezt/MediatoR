﻿using MediatR;

namespace TaskBoard.Application.Commands
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
