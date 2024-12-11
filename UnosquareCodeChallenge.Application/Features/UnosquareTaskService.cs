using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosquareCodeChallenge.Application.Interfaces;
using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallenge.Application.Features
{
    public class UnosquareTaskService(IUnosquareTaskRespository repository) : IUnosquareTaskService
    {
        public Task<List<UnosquareTask>> GetAll(CancellationToken cancellationToken, bool? isCompleted = null)
        {
            return repository.ListTasks(cancellationToken, isCompleted);
        }

        public Task<UnosquareTask> CreateTask(UnosquareTask task, CancellationToken cancellationToken)
        {
            return repository.Create(task, cancellationToken);
        }
    }
}
