using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosquareCodeChallenge.Application.Interfaces;
using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallege.Persistence.Repositories
{
    public class UnosquareTaskRepository : IUnosquareTaskRespository
    {
        public Task<List<UnosquareTask>> ListTasks(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
