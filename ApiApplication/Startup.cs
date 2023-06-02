using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataApplication.Database;
using DataApplication.Database.Repositories.Abstractions;
using DataApplication.Database.Repositories;
using Microsoft.OpenApi.Models;
using DomainApplication.IService;
using ServiceApplication.Services;
using AutoMapper;
using DataApplication.Mapping;
using System.Text.Json.Serialization;
using DomainApplication.Models;
using DataRestApplication.Repositories.Abstraction;
using DataRestApplication.Repositories;
using ApiApplication.Filter;

namespace ApiApplication
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
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddMemoryCache();
            services.AddSingleton(mapper);
            //repositories
            services.AddTransient<IShowtimesRepository, ShowtimesRepository>();
            services.AddTransient<ITicketsRepository, TicketsRepository>();
            services.AddTransient<IAuditoriumsRepository, AuditoriumsRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IIMDBRepository, IMDBRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IReservationSeatsRepository, ReservationSeatsRepository>();

            //services
            services.AddTransient<IShowTimeService, ShowTimeService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITicketService, TicketService>();
            //logger
            services.AddScoped<LogRequestTimeFilter>();

            services.AddDbContext<CinemaContext>(options =>
            {
                options.UseInMemoryDatabase("CinemaDb")
                    .EnableSensitiveDataLogging()
                    .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });
            services.AddControllers();
            services.Configure<ConfigOption>(Configuration);

            services.AddHttpClient();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                   new OpenApiInfo
                   {
                       Title = "Lodgify Cinema",
                       Version = "v1",
                       Description = "Lodgify cinema movies API",

                   });

            });
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            });
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/swagger/swagger/{documentname}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
            });

            SampleData.Initialize(app);
        }      
    }
}
