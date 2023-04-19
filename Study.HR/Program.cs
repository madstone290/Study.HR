using Microsoft.EntityFrameworkCore;
using Study.HR.Core.Application.Repos;
using Study.HR.Core.Infrastructure.Data;
using Study.HR.Core.Infrastructure.Data.Repos;

namespace Study.HR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("Secrets/database.json");

            // Add services to the container.
            var dbConn1 = builder.Configuration["Postgres:ConnectionString"];
            builder.Services.AddDbContext<ApplicationDbContext>(cfg =>
            {
                var dbConn = builder.Configuration["Postgres:ConnectionString"];
                cfg.UseNpgsql(dbConn);
            });

            builder.Services.AddScoped<IEmployeeSalaryReadRepository, EmployeeSalaryReadRepository>();
            builder.Services.AddScoped(typeof(Repository<>));
            builder.Services.AddScoped(typeof(Repository<,>));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(configurePolicy => configurePolicy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
                

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}