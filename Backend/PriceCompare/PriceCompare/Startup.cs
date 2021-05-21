using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PriceCompare.Common.Factory;
using PriceCompare.Services;
using PriceCompare.Services.Common;
using PriceCompare.Services.Scratch;
using PriceCompare.Services.SearchFilter;
using PriceCompare.Services.SearchFilter.PriceFilter;
using PriceCompare.Services.WebSiteDataAnalysis;

namespace PriceCompare
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();

            services.AddScoped<IProductScratchService, ProductScratchService>();
            services.AddScoped<IWebScratchService, WebScratchService>();

            services.AddTransient<StaticPageScratchService>();
            services.AddTransient<DynamicPageScratchService>();

            services.AddSingleton<IDataAnalysisServiceFactory, DataAnalysisServiceFactory>();
            services.AddSingleton<IPageScratchServiceFactory, PageScratchServiceFactory>();
            services.AddSingleton<IPriceFilterServiceFactory, PriceFilterServiceFactory>();
            services.AddSingleton<ISearchFilterServiceFactory, SearchFilterServiceFactory>();

            services.AddSingleton<WebSiteInitialize>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
