using BookStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BookStore.BootStrap
{
    public static class BootStrap
    {
        public static void WireUP(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<BookStoreDbContext>(op => { op.UseSqlServer(ConnectionString); }, ServiceLifetime.Scoped);
        }
    }
}
