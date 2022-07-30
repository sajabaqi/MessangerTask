using learn.core.domian;
using learn.core.Repository;
using learn.core.service;
using learn.infra.domain;
using learn.infra.Repository;
using learn.infra.service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apimonth
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
            services.AddScoped<IDBcontext, DbContext>();
            services.AddScoped<ICategory_apirepository, category_apirepository>();
            services.AddScoped<Icategoryservice, categoryservice>();

            services.AddScoped<ICourserepository, courserepository>();
            services.AddScoped<Icourseservice, courseservice>();

            services.AddScoped<IDepartment_repository, Department_repository>();
            services.AddScoped<IDepartmentservice, Departmentservice>();

            services.AddScoped<IEmployee_repository, Employee_repository>();
            services.AddScoped<IEmployeeservice, Employeeservice>();

            services.AddScoped<ITaskservice, Taskservice>();
            services.AddScoped<ITask_repository, Task_repository>();

            services.AddScoped<ITaskemp_repository, Taskemp_repository>();
            services.AddScoped<ITaskempservice, Taskempservice>();

            services.AddScoped<IChecking_repository, Checking_repository>();
            services.AddScoped<ICheckingservice, Checkingservice>();

            services.AddScoped<IEmalservice, Emailservice>();

            services.AddScoped<IAuthenticationservice, Authenticationservice>();
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<IEmployee_apinewrepository, Employee_newrepository>();

            services.AddScoped<IUsersservice, Userservice>();
            services.AddScoped<IUser_repository, UsersRepository>();

            services.AddScoped<ICommunication_repository, Communication_repository>();
            services.AddScoped<ICommunicationservice, Communicationservice>();

            services.AddScoped<GCreate_repository, GroupCreate_repository>();
            services.AddScoped<IGroupservice, GroupCreateservice>();

            services.AddScoped<IGroupAddservice, GroupsAddservice>();
            services.AddScoped<IGroupAddRepository, GroupAdd_Repository>();

            services.AddScoped<IFreindservice, Freindservice>();
            services.AddScoped<IFreind_Repository, FreindRepository>();

            services.AddScoped<IserviceService, ServiceService>();
            services.AddScoped<IserviceRepository, ServiceRepository>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            ).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                };


            });
            services.AddControllers();
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
