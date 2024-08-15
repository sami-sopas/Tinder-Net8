using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {

        // Add services to the container.
        services.AddControllers();

        //Dependecy Injection
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddCors();

        //JWT Inyection Service
        /* AddSingleton crea una instancia cuando se requiere, 
           y la reutiliiza en todas las solicitudes subsiguientes.
           Este metodo es util para items que queremos mantener en memoria o en un estado

           AddScoped crea una instancia por cada solicitud HTTP,
        */
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
