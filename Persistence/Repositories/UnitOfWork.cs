using Domain.IRepositories;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SisContext _sisContext;

        public UnitOfWork(
            SisContext sisContext)
        {
            _sisContext = sisContext;
        }

        public void Dispose()
        {
            _sisContext?.Dispose();
        }

        public void SaveChanges()
        {
            _sisContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _sisContext.SaveChangesAsync();
        }
    }
}
