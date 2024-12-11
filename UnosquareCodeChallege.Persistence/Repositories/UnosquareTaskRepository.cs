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
        public Task<List<UnosquareTask>> ListTasks(CancellationToken cancellationToken)
        {
            return context.Tasks.ToListAsync(cancellationToken);
        }
    }
}
