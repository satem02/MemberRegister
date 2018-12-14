using MemberRegister.Business.Abstract;
using MemberRegister.Business.Concrete;
using MemberRegister.Core.DataAccess;
using MemberRegister.Core.DataAccess.MongoDB;
using MemberRegister.DataAccess.Abstract;
using MemberRegister.DataAccess.Concrete.EntityFramework;
using MemberRegister.DataAccess.Concrete.MongoDB;
using MemberRegister.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MemberRegister.WebUI {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddScoped<IMemberService, MemberManager> ();
            services.AddScoped<IMemberDal, mdMemberDal> ();
            services.AddSingleton<MongoContext, MongoHelper> ();

            services.AddMvc ();

            var settings = GetSettings ();
            services.Configure<Settings> (options => {
                options.ConnectionString = settings.ConnectionString;
                options.Database = settings.Database;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }

            app.UseStaticFiles ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private Settings GetSettings () {
            var settings = new Settings ();
            settings.ConnectionString = Configuration.GetSection ("MongoConnection:ConnectionString").Value;
            settings.Database = Configuration.GetSection ("MongoConnection:Database").Value;

            return settings;
        }
    }
}