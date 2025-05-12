using MediatR;
using System;

namespace TaskBoard.Application.Commands
{
    public class DeleteTaskCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }
    }
}
