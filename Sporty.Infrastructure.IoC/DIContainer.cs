using Microsoft.Extensions.DependencyInjection;
using Sporty.Domain.IUnitOfWork;
using Sporty.Infrastructure.Data.Repositories;
using System;

namespace Sporty.Infrastructure.IoC
{
    public static class DIContainer
    {
        public static void  RegisterServices(IServiceCollection services) {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
