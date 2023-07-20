using Analytics.Portal.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Analytics.Portal.Configuration;

public static class ConfigurationIoc
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        // Data
        services.AddScoped<DataContext>();
        services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
        
        // Identity
        services.AddScoped<ApplicationDbContext>();
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));



    }
}