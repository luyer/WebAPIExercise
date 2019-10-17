using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPIExercise.Services.PostService;
using WebAPIExercise.Data;
using Microsoft.EntityFrameworkCore;
using WebAPIExercise.Services.CustomerService;

// System.Threading.Tasks.Task

namespace WebAPIExercise
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
            services.AddControllers().AddXmlSerializerFormatters();
            //services.AddSingleton<IPostService, InMemoryPosts>();  // este es el mio
            services.AddScoped<IPostService, InMemoryPostDb>();  // este es el mio
            //AddSingleton por todo el siclo de vida de la app
            //AddScoped por la session de usuario?
            //AddTransient stateless, lo toma hace lo suyo y se olvida del todo 
            services.AddScoped<ICustomerService, InMemoryDatabaseService>(); // este es el ejemplo de steve
            
            services.AddDbContext<WebAPIExerciseContext>(options => {
                
                //options.UseInMemoryDatabase("WebAPIStarter"); // <-- Esto usaba la DB de InMemory
                options.UseSqlite(
                    Configuration.GetConnectionString("WebAPIExerciseDatabase"), // Conexcion string
                    m => m.MigrationsAssembly("WebAPIExercise") // Action function, toma el builder y se le especifica donde guardar las migraciones
                );

            });
        }

        private static void HandleMapHello(IApplicationBuilder app)
        {
            app.MapWhen(context => context.Request.Query.ContainsKey("name"),  HandleMapName);
        }


          private static void HandleMapName(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                string nameVar = context.Request.Query["name"];
                await context.Response.WriteAsync("Hello "+nameVar);
            });
        }      

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/hello", HandleMapHello);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
