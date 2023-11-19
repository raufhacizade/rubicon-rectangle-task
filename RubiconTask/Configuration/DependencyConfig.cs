using Microsoft.Extensions.Caching.Memory;
using RubiconTask.DataAccess.Implementations;
using RubiconTask.DataAccess.Interfaces;
using RubiconTask.Services.Implementations;
using RubiconTask.Services.Interfaces;

namespace RubiconTask.Configuration
{
  public static class DependencyConfig
  {
    public static void ConfigureDependencies(this IServiceCollection services)
    {
      services.AddScoped<IRubiconUnitOfWork, RubiconUnitOfWork>();
      services.AddSingleton<IMemoryCache, MemoryCache>();

      // repositories
      services.AddScoped<IRectangleRepository, RectangleRepository>();

      // services
      services.AddScoped<IRectangleService, RectangleService>();
    }
  }
}
