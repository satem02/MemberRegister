using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberRegister.Business.Abstract;
using MemberRegister.Business.Concrete;
using MemberRegister.Core.DataAccess.MongoDB;
using MemberRegister.DataAccess.Abstract;
using MemberRegister.DataAccess.Concrete.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace MemberRegister.WebApi {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            AddCustomerServices (services);
            services.AddMvc ();
            services.AddCors (options => {
                options.AddPolicy ("AllowAllOrigins",
                    builder => {
                        builder.AllowAnyMethod ().AllowAnyHeader ().AllowAnyOrigin ();
                    });
            });
        }
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseSwagger ();
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Web Api v1v");
            });

            app.UseMvc ();
        }

        private void AddCustomerServices (IServiceCollection services) {
            
            services.AddScoped<IMemberService, MemberManager> ();
            services.AddScoped<IMemberDal, mdMemberDal> ();

            services.AddScoped<IUserService, UserManager> ();
            services.AddScoped<IUserDal, mdUserDal> ();

            services.AddSingleton<MongoContext, MongoHelper> ();

            var settings = GetSettings ();
            services.Configure<Settings> (options => {
                options.ConnectionString = settings.ConnectionString;
                options.Database = settings.Database;
            });
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new Info { Title = "Wep Api v1v", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        private Settings GetSettings () {
            var settings = new Settings ();
            settings.ConnectionString = Configuration.GetSection ("MongoConnection:ConnectionString").Value;
            settings.Database = Configuration.GetSection ("MongoConnection:Database").Value;

            return settings;
        }
    }
}