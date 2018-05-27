using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace KiraNet.DomainModel
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
