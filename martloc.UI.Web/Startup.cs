
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using martloc.infrastructure.Data;
using martloc.ApplicationCore.Interfaces.Services;
using martloc.ApplicationCore.Services;
using martloc.ApplicationCore.Interfaces.Repository;
using financeiro.infrastructure.Repositoty;
using martloc.ApplicationCore.Entity;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;
using martloc.infrastructure.Repositoty;
using financeiro.UI.Web.Models;
using AutoMapper;
using martloc.UI.Web.Models;
using Newtonsoft;
using Newtonsoft.Json;

namespace financeiro.UI.Web
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
             
            services.AddIdentity<Usuario, IdentityRole>(options=> {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;

            }).AddDefaultUI().AddDefaultTokenProviders().AddEntityFrameworkStores<BackendContext>();

            //services.AddDbContext<BackendContext>(options =>
            //    options.UseMySql(
            //        Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<BackendContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

    //        services.AddDbContext<BackendContext>(options =>
    //options.UseMySql(
    //    Configuration.GetConnectionString("DefaultConnection")));
    //        services.AddIdentity<Usuario, IdentityRole>()
    //        .AddRoleManager<RoleManager<IdentityRole>>()
    //        .AddDefaultUI()
    //        .AddDefaultTokenProviders()
    //        .AddEntityFrameworkStores<BackendContext>();


            services.AddControllersWithViews();
            services.AddRazorPages();

         
        services.AddAuthorization(options =>
            {
                options.AddPolicy("podeCriarMarca", policy => policy.RequireClaim("Marca.Create"));
                options.AddPolicy("podeEditarMarca", policy => policy.RequireClaim("Marca.Edit"));
                options.AddPolicy("podeDeletarMarca", policy => policy.RequireClaim("Marca.Delete"));
                options.AddPolicy("podeObterMarcaAjax", policy => policy.RequireClaim("Marca.GetMarcas"));
                options.AddPolicy("podeListarMarcas", policy => policy.RequireClaim("Marca.Index"));
                options.AddPolicy("podeEditarPerfil", policy => policy.RequireClaim("Perfis.Edit"));
                options.AddPolicy("podeListarPerfil", policy => policy.RequireClaim("Perfis.Index"));
                options.AddPolicy("precisaRealizarLogin", policy => policy.RequireAuthenticatedUser());
          




            });

          


            //services.AddDbContext<BackendContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddMvc().AddRazorPagesOptions(options =>
            //{
            //    options.Conventions.AddPageRoute("/Home/Index", "");


            //});

            services.AddMvc()
               .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);







            //services.Configure<ForwardedHeadersOptions>(options =>
            //{
            //    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
            //});

            //services.Configure<IdentityOptions>(opt =>
            //{
            //    opt.Cookies.ApplicationCookie.LoginPath = new PathString("/login");
            //});
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Proibido");

            //Identity/Account/Register

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddTransient(typeof(ILocacaoRepository), typeof(LocacaoRepository));


            services.AddTransient(typeof(IPessoaServices), typeof(PessoaServices));
            services.AddTransient(typeof(IMarcaServices), typeof(MarcaServices));
            services.AddTransient(typeof(IClienteServices), typeof(ClienteServices));
            services.AddTransient(typeof(IUsuarioServices), typeof(UsuarioServices));
            services.AddTransient(typeof(ILocacaoServices), typeof(LocacaoServices));
            services.AddTransient(typeof(IFisicaServices), typeof(FisicaServices));
            services.AddTransient(typeof(IJuridicaServices), typeof(JuridicaServices));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioViewModel, Usuario>();
                //cfg.CreateMap<List<LocacaoViewModel>, List<Locacao>>();
                cfg.CreateMap<Locacao, LocacaoViewModel>();
                cfg.CreateMap<LocacaoItens, LocacaoItensViewModel>();
                cfg.CreateMap<Pessoa, PessoaViewModel>();
                cfg.CreateMap<Contato, ContatoViewModel>();
                cfg.CreateMap<Equipamento, EquipamentoViewModel>();
                cfg.CreateMap<Marca, MarcaViewModel>();
                cfg.CreateMap<MarcaViewModel , Marca>();
                cfg.CreateMap<Categoria, CategoriaViewModel>();

                cfg.CreateMap<Pessoa, PessoaViewModel>();
                cfg.CreateMap<PessoaViewModel, Pessoa>();


                cfg.CreateMap<Fisica, FisicaViewModel>();
                cfg.CreateMap<FisicaViewModel, Fisica>();

                cfg.CreateMap<Juridica, JuridicaViewModel>();
                cfg.CreateMap<JuridicaViewModel, Juridica>();


                cfg.CreateMap<Fisica, PessoaViewModel>();
                cfg.CreateMap<PessoaViewModel, Fisica>();

                cfg.CreateMap<Juridica, PessoaViewModel>();
                cfg.CreateMap<PessoaViewModel, Juridica>();

            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }



    }
}
