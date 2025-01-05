using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavaAPI.Domain.Entities;

namespace SavaAPI.Domain.Interfaces
{
    public interface ITasksRepository
    {
        Task<IEnumerable<TasksEntity>> GetTasks();
        Task<TasksEntity> GetTasksByIdAsync(Guid id);
        Task<TasksEntity> AddTaskAsync(TasksEntity entity);
        Task<TasksEntity> UpdateTaskAsync(Guid taskid, TasksEntity entity);
        Task<bool> DeleteTaskAsync(Guid taskid);
    }
}
