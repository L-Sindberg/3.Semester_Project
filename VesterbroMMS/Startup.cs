using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using DataLibrary;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VesterbroMMS.Data;
using VesterbroMMS.Services;

namespace VesterbroMMS
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

            services.AddSingleton<AuthService>();
            services.AddSingleton<MemberService>();
            services.AddSingleton<AuthController>();
            services.AddSingleton<MemberController>();
            services.AddAuthentication("Cookies")
                .AddCookie(opt =>
                {
                    opt.Cookie.Name = "TryingoutGoogle0Auth";
                    opt.LoginPath = "/auth/google-login";
                })
                .AddGoogle(opt =>
                {
                    opt.ClientId = Configuration["Google:Id"];
                    opt.ClientSecret = Configuration["Google:Secret"];
                    opt.Scope.Add("profile");
                    opt.Events.OnCreatingTicket = async context =>
                    {
                        AuthService authService = new AuthService(Configuration);

                        string email = context.Identity.Claims.Where(s => s.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault().Value;
                        bool result = await authService.AuthenticateLogin(email);

                        if (result)
                        {
                            // TODO: Add relevant role here
                            context.Identity.AddClaim(new Claim(ClaimTypes.Role, "Board"));
                        } else
                        {
                            context.Identity.AddClaim(new Claim(ClaimTypes.Role, "Google"));
                        }
                    };
                });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
