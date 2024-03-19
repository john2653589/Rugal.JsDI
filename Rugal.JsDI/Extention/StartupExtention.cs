using Microsoft.Extensions.DependencyInjection;
using Rugal.JavaScriptDataInject.Service;

namespace Rugal.JavaScriptDataInject.Extention
{
    public static class StartupExtention
    {
        public static IServiceCollection AddJsDI(this IServiceCollection Services)
        {
            Services.AddScoped<JsDIService>();
            return Services;
        }
    }
}
