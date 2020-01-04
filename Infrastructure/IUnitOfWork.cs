using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken token = default);
    }
}