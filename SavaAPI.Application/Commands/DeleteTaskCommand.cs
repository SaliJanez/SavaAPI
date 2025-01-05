using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SavaAPI.Domain.Interfaces;

namespace SavaAPI.Application.Commands
{
    public record DeleteTaskCommand (Guid TaskId): IRequest<bool>;
    public class DeleteTaskCommandHandler(ITasksRepository tasksRepository)
        : IRequestHandler<DeleteTaskCommand, bool>
    { 
        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            return await tasksRepository.DeleteTaskAsync(request.TaskId);
        }
    }
}
