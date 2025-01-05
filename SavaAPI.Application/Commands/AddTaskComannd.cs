using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SavaAPI.Domain.Entities;
using SavaAPI.Domain.Interfaces;

namespace SavaAPI.Application.Commands
{
    public record AddTaskComannd (TasksEntity Task): IRequest<TasksEntity>;


    public class AddTaskComanndHandler(ITasksRepository tasksRepository)
        : IRequestHandler<AddTaskComannd, TasksEntity>
    {
        public async Task<TasksEntity> Handle(AddTaskComannd request, CancellationToken cancellationToken)
        {
           return await tasksRepository.AddTaskAsync(request.Task);
        }
    }
}
