using System.Transactions;
using Academy.Domain;
using Academy.Domain.Unit.Tests.Builder;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Tests.Integration;

public class RealDatabaseFixture : IDisposable
{
    public AcademyContext Context;
    private readonly TransactionScope _scope;
    public RealDatabaseFixture()
    {
        var options = new DbContextOptionsBuilder<AcademyContext>()
.UseSqlServer("Server=localhost;Database=TddAcademy;User Id=sa;Password=123456;TrustServerCertificate=True;").Options;
        Context = new AcademyContext(options);
        _scope = new TransactionScope();
        var builder = new CourseTestBuilder();
        var asp = builder
                 .WithName("ASP.NET Core 5")
                 .WithTuition(780)
                 .WithInstructor("mrsd")
                 .Build();
        var git = builder
            .WithName("Git")
            .WithTuition(120)
            .WithInstructor("mrsd")
            .Build();
        var webDesign = builder
            .WithName("Web Design")
            .WithTuition(320)
            .WithInstructor("mrsd")
            .Build();

        Context.Add(asp);
        Context.Add(git);
        Context.Add(webDesign);
        Context.SaveChanges();
    }
    public void Dispose()
    {
        _scope.Dispose();
        Context.Database.ExecuteSqlRaw("TRUNCATE TABLE Courses;");
        Context.SaveChanges();
        Context.Dispose();
    }

}