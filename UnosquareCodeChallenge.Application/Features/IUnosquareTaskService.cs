using UnosquareCodeChallenge.Domain.Entities;

namespace UnosquareCodeChallenge.Application.Features
{
    public interface IUnosquareTaskService
    {
        Task<List<UnosquareTask>> GetAll(CancellationToken cancellationToken);
    }
}