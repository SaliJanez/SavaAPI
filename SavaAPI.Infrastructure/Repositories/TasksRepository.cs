using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SavaAPI.Domain.Entities;
using SavaAPI.Domain.Interfaces;
using SavaAPI.Infrastructure.Data;

namespace SavaAPI.Infrastructure.Repositories
{
    public class TasksRepository(AppDbContext dbContext) : ITasksRepository
    {
        public async Task<IEnumerable<TasksEntity>> GetTasks()
        {
            return await dbContext.Tasks.ToListAsync();
        }

        public async Task<TasksEntity> GetTasksByIdAsync(Guid id)
        {
           return await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TasksEntity> AddTaskAsync(TasksEntity entity)
        {
            entity.Id = Guid.NewGuid();
            dbContext.Tasks.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TasksEntity> UpdateTaskAsync(Guid taskid, TasksEntity entity)
        {
            var task = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == taskid);

            if (task != null)
            {
                task.Description = entity.Description;
                task.Title = entity.Title;
                task.Priority = entity.Priority;
                task.DueDate = entity.DueDate;
                task.UpdatedDate = DateTime.Now;

                await dbContext.SaveChangesAsync();

                return task;
            }

            return entity;
        }

        public async Task<bool> DeleteTaskAsync(Guid taskid)
        {
            var task = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == taskid);

            if (task != null)
            {
                dbContext.Tasks.Remove(task);

                return await dbContext.SaveChangesAsync() > 0; 
            }

            return false;
        }
    }
}
