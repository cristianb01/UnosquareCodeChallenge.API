﻿using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallenge.Application.Features
{
    public interface IUnosquareTaskService
    {
        Task<List<UnosquareTask>> GetAll(CancellationToken cancellationToken, bool? isCompleted = null);
        Task<UnosquareTask> CreateTask(UnosquareTask task, CancellationToken cancellationToken);
        Task DeleteTask(int id, CancellationToken cancellationToken);
        Task<UnosquareTask> UpdateTask(int id, UnosquareTask task, CancellationToken cancellationToken);
    }
}