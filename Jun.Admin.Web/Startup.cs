using Jun.Admin.EntityFramework;
using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service;
using Jun.Admin.Service.Contract;
using Jun.Admin.Web.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Jun.Admin.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>(item =>
            {
                item.ViewLocationFormats.Clear();
                item.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");

                item.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
                item.ViewLocationFormats.Add("/Views/Right/{1}/{0}.cshtml");
            });
            services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(Configuration.
                GetConnectionString("DefaultConnection")));


            AddPlugIns(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

            //注册Cookie认证服务
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=> {
                options.LoginPath = new PathString("/Login/Index");
                options.AccessDeniedPath = new PathString("/Error/Forbidden");
            });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("/User/Index.View", policy => policy.AddRequirements(new PermissionAuthorizationRequirement("/User/Index.List")));
            //    options.AddPolicy("/User/Index.Insert", policy => policy.AddRequirements(new PermissionAuthorizationRequirement("/User/Index.Insert")));
            //    options.AddPolicy("/User/Index.Update", policy => policy.AddRequirements(new PermissionAuthorizationRequirement("/User/Index.Update")));
            //    options.AddPolicy("/User/Index.Delete", policy => policy.AddRequirements(new PermissionAuthorizationRequirement("/User/Index.Delete")));
            //    options.AddPolicy("/User/Index.Detail", policy => policy.AddRequirements(new PermissionAuthorizationRequirement("/User/Index.Detail")));
            //});

        }

        private void AddPlugIns(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IMenuFuncRepository, MenuFuncRepository>();
            services.AddScoped<IRoleMenuFuncRepository, RoleMenuFuncRepository>();
            services.AddScoped<IFunctionRepository, FunctionRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuFuncService, MenuFuncService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            //启用Authentication中间件
            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "Right",
                //    template: "Right/{ controller = Home}/{ action = Index}/{ id ?}");
            });
           // DbInitializer.Initializer(context);//生成数据库，表，添加原始数据
        }
    }
}
