using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnosquareCodeChallenge.Application.Interfaces;
using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallege.Persistence.Repositories
{
    public class UnosquareTaskRepository(AppDbContext context) : IUnosquareTaskRespository
    {
        public Task<UnosquareTask?> GetTaskById(int id, CancellationToken cancellationToken)
        {
            return context.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<UnosquareTask>> ListTasks(CancellationToken cancellationToken, bool? isCompleted = null)
        {
            if (isCompleted == null)
            {
                return context.Tasks.AsNoTracking().ToListAsync(cancellationToken);
            }
            else
            {
                return context.Tasks.AsNoTracking().Where(task => task.IsCompleted == isCompleted).ToListAsync(cancellationToken);
            }
        }

        public async Task<UnosquareTask> Create(UnosquareTask task, CancellationToken cancellationToken)
        {
            var createdTask = (await context.Tasks.AddAsync(task, cancellationToken)).Entity;
            await context.SaveChangesAsync(cancellationToken);
            return createdTask;
        }

        public async Task<UnosquareTask> Update(UnosquareTask task, CancellationToken cancellationToken)
        {
            var updatedTask = context.Tasks.Update(task).Entity;
            await context.SaveChangesAsync(cancellationToken);
            return updatedTask;
        }

        public Task Delete(UnosquareTask task, CancellationToken cancellationToken)
        {
            context.Tasks.Remove(task);
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
