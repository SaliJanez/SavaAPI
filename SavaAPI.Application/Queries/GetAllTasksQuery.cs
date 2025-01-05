using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SavaAPI.Domain.Entities;
using SavaAPI.Domain.Interfaces;

namespace SavaAPI.Application.Queries
{
    public record GetAllTasksQuery() : IRequest<IEnumerable<TasksEntity>>;
    
    public class GetAllTasksQueryHandler(ITasksRepository tasksRepository)
        : IRequestHandler<GetAllTasksQuery, IEnumerable<TasksEntity>>
    {
        public async Task<IEnumerable<TasksEntity>> Handle(GetAllTasksQuery request, CancellationToken cancellation)
        {
            return await tasksRepository.GetTasks();
        }
    }
}
