using KuyumcuAPI.Application.Interfaces.Repositories;
using KuyumcuAPI.Application.Interfaces.Services;
using KuyumcuAPI.Application.Interfaces.UnitOfWorks;
using KuyumcuAPI.Persistance.Context;
using KuyumcuAPI.Persistance.Repositories;
using KuyumcuAPI.Persistance.Services;
using KuyumcuAPI.Persistance.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Persistance
{
    public static class Registiration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICashTransactionService, CashTransactionService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
