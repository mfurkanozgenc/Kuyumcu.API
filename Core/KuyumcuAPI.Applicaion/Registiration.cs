using KuyumcuAPI.Applicaion.Bases;
using KuyumcuAPI.Applicaion.Exception;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Applicaion
{
    public static class Registiration
    {
        public static void AddAplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly)); ;
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var itemType in types)
            {
                services.AddTransient(itemType);
            }
            return services;
        }
    }
}
