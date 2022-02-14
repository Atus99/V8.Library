using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace V8.Application.AutoMapper
{
    public static class V8AutoMapper
    {
        public static void Configure(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
