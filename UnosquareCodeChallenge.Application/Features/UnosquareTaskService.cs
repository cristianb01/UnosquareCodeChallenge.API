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
        public Task<List<UnosquareTask>> GetAll(CancellationToken cancellationToken)
        {
            return repository.ListTasks(cancellationToken);
        }
    }
}
