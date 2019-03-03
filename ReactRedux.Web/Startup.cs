using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReactRedux.DAL;
using System;
using System.Linq;
using System.Reflection;

[assembly: ApiController]

namespace ReactRedux.Web
{
    public class Startup
    {
        private Assembly _logicAssembly;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            InitAssemblies();
        }

        private void InitAssemblies()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            _logicAssembly = GetAssembly("ReactRedux.Logic", assemblies);
        }

        private Assembly GetAssembly(string name, Assembly[] assemblies)
        {
            return assemblies.SingleOrDefault(a => a.GetName().Name == name) ?? Assembly.Load(name);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddDbContext<ReactReduxContext>(options => options.UseSqlite(Configuration.GetConnectionString("ReactRedux")));
            RegisterLogicServices(services);
        }

        private void RegisterLogicServices(IServiceCollection services)
        {
            var servicesTypes = _logicAssembly.GetTypes()
                .Where(t => t.IsClass
                            && t.Namespace != null
                            && t.Namespace.EndsWith("Services")
                            && !t.IsNested);
            foreach (Type service in servicesTypes)
            {
                services.AddScoped(service);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                    //spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}