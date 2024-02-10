
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace SortedExam
{
    public static class ApplicationConfigService
    {
        public static void AddSwaggerService(this IServiceCollection service)
        {
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0",
                    Title = "Rainfall Api",
                    Description = "An API which provides rainfall reading data",
                    Contact = new OpenApiContact
                    {
                        Name = "Sorted",
                        Url = new Uri("https://www.sorted.com")
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        public static void AddRainfallService(this IServiceCollection service)
        {
            service.AddScoped<RainfallService>();
        }
    }
}