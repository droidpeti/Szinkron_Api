using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Szinkron_Api.Data;

namespace Szinkron_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Szinkron_ApiContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("Szinkron_ApiContext") ?? throw new InvalidOperationException("Connection string 'Szinkron_ApiContext' not found.")));

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
