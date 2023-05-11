
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Console_app
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //injected custom middleware
            services.AddTransient<CustomMiddleWare1>();
            
        }
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            //all the below are middlewares

            //Middleware 1
            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync("\n Message 1 from Middleware 1 ");
                await next();
                await context.Response.WriteAsync("\n Message 2 from Middleware 1");
            });

            //custom mapping 
            app.UseMiddleware<CustomMiddleWare1>();
           
            
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("\n Message 1 from Middleware 2 ");

                //if i don't pass the below next method then only the above msg will be displayed 
                //no other middlewares will be excuted like run,useendpoints etc...bcoz this use() method is not having
                //the next() method

                await next();

                //this will be executed after the next middleware
                await context.Response.WriteAsync("\n Message 2 from Middleware 2");
            });


            //the code after the below Run method will not work as it is a termination of middlewares 
            app.Run(async context =>
            {
                await context.Response.WriteAsync("\n Termination of middleware using Run method");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Congraaatulations on your first web api kareeeennnaa!!!");
                //});

                //endpoints.MapGet("/test", async context =>
                //{
                //    await context.Response.WriteAsync("the test page api!!!");
                //});
            });

        }

        private void CustomMethod(IApplicationBuilder obj)
        {
            throw new NotImplementedException();
        }
    }
}
