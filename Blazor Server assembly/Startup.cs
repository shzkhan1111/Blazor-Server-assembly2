using Blazor_Server_assembly.Data;
using Blazor_Server_assembly.Interface;
using Blazor_Server_assembly.Store;
using Blazor_Server_assembly.Store.CounterStore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Server_assembly
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            //transient (interface , implementation)
            //The transent behavior->I register a service to
            //a container and everytime I ask for an instance the container will create a new instance of that class
            //and will inject that into out component
            
            //the num will change on screen change and reload  
            //services.AddTransient<ICustomerService, CustomerService>();


            //move away and come back the number doesn’t change or refresh
            //services.AddSingleton<ICustomerService, CustomerService>();

            //makes the service live as long as the connection
            //For state management use scope
            // move away and comeback the num doent change yet on reload it does 
            services.AddScoped<ICustomerService, CustomerService>();

            //            Services that are not thread safe(concurrency doesn’t work) like DB context or entity framework you
            //don’t wont to use singleton or scoped
            //even transient may have problems
            /*
             * Because its web assembly
            All DLL are downloaded inside the browser
            We have web assembly context , all of them hosted in that context
            Refresh a new instance is created App destroyed and recreated 
            With singleton we get different ids when you refresh the browser 

            Scoped 
            There is no connection and no request blazor web doesn’t have a scoped life time mgmt configu..
            Scoped is going to work the same way as singleon 
            Transient work the same (see it) 

             */
            //we dont to share the scope 
            //as long as connectiom is not broken it will be the same instance of the store 
            services.AddScoped<CounterStore>();
            //not singleton as it will be dispatched to different users
            services.AddScoped<IActionDispatcher , ActionDispatcher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
