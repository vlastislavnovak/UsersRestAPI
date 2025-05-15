using Microsoft.EntityFrameworkCore;
using UsersRestAPI.Data;

namespace UsersRestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Read the connection string from appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Register the DbContext with the connection string
            builder.Services.AddDbContext<ApiDbContext>(options =>
                options.UseMySql(
                    connectionString,
                    new MariaDbServerVersion(new Version(10, 4, 32)))
                .LogTo(msg => System.Diagnostics.Debug.WriteLine(msg), LogLevel.Information));

            // Add services to the container.

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
