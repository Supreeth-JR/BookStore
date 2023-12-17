using Book.BAL;
using Book.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce
{
    public sealed class ECommerceServices
    {
        public void EService(IServiceCollection services)//IServiceCollection -- NameSpace - Microsoft.Extensions.DependencyInjection;
        {
            services.AddSingleton<IBookRepo,BookRepo>();
            services.AddTransient<IBookDAL, BookDAL>();
        }
    }
}
