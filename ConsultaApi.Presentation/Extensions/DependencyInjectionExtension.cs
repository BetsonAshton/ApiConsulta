using ConsultaApi.Application.Interfaces;
using ConsultaApi.Application.Services;
using ConsultaApi.Data.Repositories;
using ConsultaApi.Domain.Interfaces.Repositories;
using ConsultaApi.Domain.Interfaces.Services;
using ConsultaApi.Domain.Services;

namespace ConsultaApi.Presentation.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IPacienteAppService, PacienteAppService>();
            services.AddTransient<IPacienteDomainService, PacienteDomainService>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IMedicoAppService, MedicoAppService>();
            services.AddTransient<IMedicoDomainService, MedicoDomainService>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IConsultaAppService, ConsultaAppService>();
            services.AddTransient<IConsultaDomainService, ConsultaDomainService>();
            services.AddTransient<IConsultaRepository, ConsultaRepository>();




            return services;
        }
    }
}
