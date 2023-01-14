using Acelerador.Applications;
using Acelerador.Applications.Interfaces;
using Acelerador.DbContexts;
using Acelerador.DbContexts.Interfaces;

namespace Acelerador.IoC
{
    public static class IoC
    {
        public static void ConfiguraServicos(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, SqliteDbContext>();
            services.AddScoped<IClienteApplication, ClienteApplication>();
        }
    }
}
