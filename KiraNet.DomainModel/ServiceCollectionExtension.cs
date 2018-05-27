using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KiraNet.DomainModel
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUnitOfWork<TUnitOfWork>(this IServiceCollection services)
            where TUnitOfWork : class, IUnitOfWork
        {
            return services
                .AddScoped<IUnitOfWork, TUnitOfWork>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static IServiceCollection AddUnitOfWorkByDbContext<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork<TDbContext>>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
