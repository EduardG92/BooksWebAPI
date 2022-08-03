using BooksWebAPI.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "https://localhost:7268",
                        ValidAudience = "https://localhost:7268",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mySecretKey@2022")
                        
                     };
                });

            var connectionString = builder.Configuration["ConnectionStrings:MedITDBConnectionString"];
            builder.Services.AddDbContext<MedITContext>(o => o.UseSqlServer(connectionString));



            //Adding services on the container
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();

            builder.Services.AddScoped<IPatientUnitOfWork, PatientUnitOfWork>();
            builder.Services.AddScoped<ITreatmentUnitOfWork, TreatmentUnitOfWork>();


            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddControllers();
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
            app.UseAuthentication();
            app.MapControllers();

        
        }
    }
}
