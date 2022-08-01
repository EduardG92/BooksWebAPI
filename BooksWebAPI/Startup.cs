using BooksWebAPI.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BooksWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration["ConnectionStrings:MedITDBConnectionString"];
            builder.Services.AddDbContext<MedITContext>(o => o.UseSqlServer(connectionString));

            builder.Services.AddControllers();

            //Adding services on the container
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();

            builder.Services.AddScoped<IPatientUnitOfWork, PatientUnitOfWork>();
            builder.Services.AddScoped<ITreatmentUnitOfWork, TreatmentUnitOfWork>();

        }

        public static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }
    }
}
