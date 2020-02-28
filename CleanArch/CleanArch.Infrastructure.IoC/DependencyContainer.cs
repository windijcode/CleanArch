using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.CommandHandlers;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Bus;
using CleanArch.Infrastructure.Data.Context;
using CleanArch.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterSerivices(IServiceCollection services)
        {
            // Domain InMemoryBus MediatR
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain Handlers
            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();

            // Application layer
            services.AddScoped<ICourseService, CourseService>();

            // Infrastructure.Data layer
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<UniversityDBContext>();
        }
    }
}
