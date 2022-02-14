using Microsoft.Extensions.DependencyInjection;
using V8Notify.Application.Interfaces;

namespace V8Notify.Application.Services
{
    public static class DIServiceWrapper
    {
        public static void DependencyInjectionService(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
