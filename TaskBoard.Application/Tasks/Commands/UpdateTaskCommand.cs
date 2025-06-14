﻿using MediatR;

namespace TaskBoard.Application.Tasks.Commands
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }

        public UpdateTaskCommand(Guid id, string title, string? description, bool isCompleted)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}
