using Academy.Application;
using Academy.Application.Interfaces;
using Academy.Domain.Interfaces;
using Academy.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
        builder.Services.AddDbContext<AcademyContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        builder.Services.AddTransient<ICourseService, CourseService>();
        builder.Services.AddTransient<ICourseRepository, CourseRepository>();
        builder.Services.AddCors();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(builder => builder.AllowAnyOrigin());
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}