using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosquareCodeChallenge.Application.Exceptions;
using UnosquareCodeChallenge.Application.Interfaces;
using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallenge.Application.Features
{
    public class UnosquareTaskService(IUnosquareTaskRespository repository) : IUnosquareTaskService
    {
        public async Task DeleteTask(int id, CancellationToken cancellationToken)
        {
            var existingTask = await repository.GetTaskById(id, cancellationToken);

            if (existingTask is null)
            {
                throw new NotFoundException("Task does not exist");
            }
            
            await repository.Delete(existingTask, cancellationToken);
        }
        public Task<List<UnosquareTask>> GetAll(CancellationToken cancellationToken, bool? isCompleted = null)
        {
            return repository.ListTasks(cancellationToken, isCompleted);
        }

        public Task<UnosquareTask> CreateTask(UnosquareTask task, CancellationToken cancellationToken)
        {
            return repository.Create(task, cancellationToken);
        }

        public async Task<UnosquareTask> UpdateTask(int id, UnosquareTask task, CancellationToken cancellationToken)
        {
            var existingTask = await repository.GetTaskById(id, cancellationToken);

            if (existingTask is null)
            {
                throw new NotFoundException("Task does not exist");
            }
            return await repository.Update(task, cancellationToken);
        }
    }
}
