﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallenge.Application.Interfaces
{
    public interface IUnosquareTaskRespository
    {
        Task<UnosquareTask?> GetTaskById(int id,CancellationToken cancellationToken);
        Task<List<UnosquareTask>> ListTasks(CancellationToken cancellationToken, bool? isCompleted = null);
        
        Task<UnosquareTask> Create(UnosquareTask task, CancellationToken cancellationToken);

        Task<UnosquareTask> Update(UnosquareTask task, CancellationToken cancellationToken);
        Task Delete(UnosquareTask task, CancellationToken cancellationToken);
    }
}
