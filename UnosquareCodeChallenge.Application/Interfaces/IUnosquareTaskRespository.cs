using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallenge.Application.Interfaces
{
    public interface IUnosquareTaskRespository
    {
        Task<List<UnosquareTask>> ListTasks(CancellationToken cancellationToken);
    }
}
