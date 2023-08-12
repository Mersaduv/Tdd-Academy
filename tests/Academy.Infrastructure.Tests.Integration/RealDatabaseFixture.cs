using System.Transactions;
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
    }
    public void Dispose()
    {
        Context.Dispose();
        _scope.Dispose();
    }

}