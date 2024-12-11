using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallenge.Application.Features
{
    public interface IUnosquareTaskService
    {
        Task<List<UnosquareTask>> GetAll(CancellationToken cancellationToken, bool? isCompleted = null);
        Task<UnosquareTask> CreateTask(UnosquareTask task, CancellationToken cancellationToken);
    }
}