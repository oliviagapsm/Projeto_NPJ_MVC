using Microsoft.EntityFrameworkCore;
using NPJ_MVC.Data;
using NPJ_MVC.Repositorios;

namespace NPJ_MVC
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
            services.AddControllersWithViews();
            services.AddDbContext<AgendaNPJContext>(options => options
            .UseSqlServer(Configuration
            .GetConnectionString("DefaultConnection")));
           // services.AddControllers();

            //services.AddDbContext<BancoContext>
              //   (options =>
               // {
                 //   options.UseSqlServer("Data Source=OLIVIA_MACEDO\\SQLEXPRESS;Initial Catalog=SistemasUsuarios;Integrated Security=True");
                //});
             //services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DataBase")));

            // services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
             //services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
